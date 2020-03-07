using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Data;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using ClassSchedule.Models;
using ClassSchedule.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(
            [FromQuery]UserDtoParameters parameters)
        {
            var users = await _userRepository.GetUsersAsync(parameters);

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(userDtos);
        }

        [HttpGet("{username}", Name = nameof(GetUser))]
        public async Task<ActionResult<UserDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserAddDto user)
        {
            var entity = _mapper.Map<User>(user);
            entity.StudentId = Guid.NewGuid();
            _userRepository.AddUser(entity);
            await _userRepository.SaveAsync();

            var returnDot = _mapper.Map<UserDto>(entity);

            return CreatedAtRoute(
                nameof(GetUser),
                new
                {
                    username = returnDot.UserName
                },
                returnDot
            );
        }

        [HttpPut("{username}")]
        public async Task<ActionResult<UserDto>> UpdateUser(string username, UserUpdateDto user)
        {
            if (!await _userRepository.UserExistsAsync(user.UserName, user.OldPassword))
            {
                return NotFound();
            }

            var userEntity = await _userRepository.GetUserAsync(user.UserName);

            if (userEntity == null)
            {
                var userToAddEntity = _mapper.Map<User>(user);
                userToAddEntity.UserName = user.UserName;

                _userRepository.AddUser(userToAddEntity);
                await _userRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<UserDto>(userToAddEntity);

                return CreatedAtRoute(nameof(GetUser),
                    new
                    {
                        username = dtoToReturn.UserName
                    }, dtoToReturn);
            }

            _mapper.Map(user, userEntity);

            _userRepository.UpdateUser(userEntity);

            await _userRepository.SaveAsync();

            return NoContent();
        }

        // content-type: patch-json+json
        [HttpPatch("{username}/{password}")]
        public async Task<IActionResult> RartiallyUpdateUser(
            string username,
            string password,
            JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            if (!await _userRepository.UserExistsAsync(username, password))
            {
                return NotFound();
            }

            var userEntity = await _userRepository.GetUserAsync(username);

            if (userEntity == null)
            {
                var userDto = new UserUpdateDto();
                patchDocument.ApplyTo(userDto, ModelState);

                if (!TryValidateModel(userDto))
                {
                    return ValidationProblem(ModelState);
                }

                var userToAdd = _mapper.Map<User>(userDto);
                userToAdd.UserName = username;

                _userRepository.AddUser(userToAdd);
                await _userRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<UserDto>(userToAdd);

                return CreatedAtRoute(nameof(GetUser),
                    new
                    {
                        username = dtoToReturn.UserName
                    }, dtoToReturn
                );
            }

            var dtoToPatch = _mapper.Map<UserUpdateDto>(userEntity);

            patchDocument.ApplyTo(dtoToPatch, ModelState);

            if (!TryValidateModel(dtoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dtoToPatch, userEntity);

            _userRepository.UpdateUser(userEntity);

            await _userRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var userEntity = await _userRepository.GetUserAsync(username);

            if (userEntity == null)
            {
                return NotFound();
            }

            // await _userRepository.GetUsersAsync(new UserDtoParameters() {Name = username});

            _userRepository.DeleteUser(userEntity);
            await _userRepository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetUsersOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,PUT,PATCH,OPTIONS");
            return Ok();
        }

        public override ActionResult ValidationProblem(
            ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();

            return (ActionResult) options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}

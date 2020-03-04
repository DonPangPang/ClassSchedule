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

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/user")]
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
                }, returnDot);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser(UserUpdateDto user)
        {
            if (!await _userRepository.UserExistsAsync(user.UserName, user.OldPassword))
            {
                return NotFound();
            }

            var userEntity = await _userRepository.GetUserAsync(user.UserName);

            if (userEntity == null)
            {
                return NotFound();
            }
            throw new Exception();
        }

        [HttpPatch]
        public async Task<IActionResult> RartiallyUpdateUser(
            string username,
            JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            throw new Exception();
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
            Response.Headers.Add("Allow", "GET,POST,DELETE,OPTIONS");
            return Ok();
        }
    }
}

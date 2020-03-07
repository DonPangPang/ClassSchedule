using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Data;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.DtoParameters;
using ClassSchedule.Services;
using ClassSchedule.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassController: ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetClasses(
            [FromQuery]ClassDtoParameters parameters)
        {
            var classes = await _classRepository.GetClassesAsync(parameters);

            var classDtos = _mapper.Map<IEnumerable<ClassDto>>(classes);

            return Ok(classDtos);
        }

        [HttpGet("{classId}", Name = nameof(GetClass))]
        public async Task<ActionResult<ClassDto>> GetClass(Guid classId)
        {
            var _class = await _classRepository.GetClassAsync(classId);
            if(_class == null)
            {
                return NotFound();
            } 

            return Ok(_mapper.Map<ClassDto>(_class));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateClass([FromBody]ClassAddDto _class)
        {
            var entity = _mapper.Map<Class>(_class);
            entity.ClassId = Guid.NewGuid();
            _classRepository.AddCLass(entity);
            await _classRepository.SaveAsync();

            var returnDto = _mapper.Map<ClassDto>(entity);

            return CreatedAtRoute(
                nameof(GetClass),
                new{
                    classId = returnDto.CLassId,
                    className = returnDto.ClassName
                },
                returnDto
            );
        }

        [HttpPut("{classId}")]
        public async Task<ActionResult<ClassDto>> UpdateClass(Guid classId, ClassUpdateDto _class)
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var classEntity = await _classRepository.GetClassAsync(classId);

            if(classEntity == null)
            {
                var classToAddEntity = _mapper.Map<Class>(_class);
                classToAddEntity.ClassId = classId;

                _classRepository.AddCLass(classToAddEntity);
                await _classRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<ClassDto>(classToAddEntity);

                return CreatedAtRoute(
                    nameof(GetClass),
                    new{
                        classId = dtoToReturn.CLassId,
                        className = dtoToReturn.ClassName
                    },
                    dtoToReturn
                );
            }

            _mapper.Map(_class, classEntity);

            _classRepository.UpdateClass(classEntity);

            await _classRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> RartiallyUpdateClass(
            Guid classId,
            JsonPatchDocument<ClassUpdateDto> patchDocument
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var classEntity = await _classRepository.GetClassAsync(classId);

            if(classEntity == null)
            {
                var classDto = new ClassUpdateDto();
                patchDocument.ApplyTo(classDto, ModelState);

                if(!TryValidateModel(classDto))
                {
                    return ValidationProblem(ModelState);
                }

                var classToAdd = _mapper.Map<Class>(classDto);
                classToAdd.ClassId = classId;

                _classRepository.AddCLass(classToAdd);
                await _classRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<ClassDto>(classToAdd);

                return CreatedAtRoute(
                    nameof(GetClass),
                    new{
                        classId = dtoToReturn.CLassId,
                        className = dtoToReturn.ClassName
                    }, dtoToReturn
                );
            }

            var dtoToPatch = _mapper.Map<ClassUpdateDto>(classEntity);

            patchDocument.ApplyTo(dtoToPatch, ModelState);

            if(!TryValidateModel(dtoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dtoToPatch, classEntity);

            _classRepository.UpdateClass(classEntity);

            await _classRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{classId}")]
        public async Task<IActionResult> DeleteClass(Guid classId)
        {
            var classEntity = await _classRepository.GetClassAsync(classId);

            if(classEntity == null)
            {
                return NotFound();
            }

            _classRepository.DeleteClass(classEntity);
            await _classRepository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetClassOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PUT, PATCH, OPTIONS");
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
using System.Security.Cryptography;
using AutoMapper;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using ClassSchedule.Models;
using ClassSchedule.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/classes/{classId}/students")]
    public class StudentController: ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IClassRepository classRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _classRepository = classRepository ?? throw new ArgumentNullException(nameof(ClassRepository));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(
            Guid classId,
            [FromBody]StudentDtoParameters parameters
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var students = await _studentRepository.GetStudentsAsync(parameters);

            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet("{studentId}", Name = nameof(GetStudent))]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid classId, Guid studentId)
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentAsync(classId, studentId);

            var studentDto = _mapper.Map<IEnumerable<StudentDto>>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(Guid classId, [FromBody]StudentAddDto student)
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var entity = _mapper.Map<Student>(student);

            _studentRepository.AddStudent(classId, entity);
            await _studentRepository.SaveAsync();

            var dtoToReturn = _mapper.Map<StudentDto>(entity);

            return CreatedAtRoute(
                nameof(GetStudent),
                new{
                    classId = classId,
                    studentId = dtoToReturn.StudentId
                }, dtoToReturn
            );
        }

        [HttpPut("studentId")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(
            Guid classId,
            Guid studentId,
            StudentUpdateDto student
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository.GetStudentAsync(classId, studentId);

            if(studentEntity == null)
            {
                var studentToAddEntity = _mapper.Map<Student>(student);
                studentToAddEntity.StudentId = studentId;

                _studentRepository.AddStudent(classId, studentToAddEntity);

                await _studentRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<StudentDto>(studentToAddEntity);

                return CreatedAtRoute(
                    nameof(GetStudent),
                    new{
                        classId = classId,
                        studentId = dtoToReturn.StudentId
                    }, dtoToReturn
                );
            }

            _mapper.Map(student, studentEntity);

            _studentRepository.UpdateStudent(studentEntity);

            await _studentRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("studentId")]
        public async Task<IActionResult> PartiallyUpdateStudent(
            Guid classId, 
            Guid studentId,
            JsonPatchDocument<StudentUpdateDto> patchDocument
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository.GetStudentAsync(classId, studentId);

            if(studentEntity == null)
            {
                var studentDto = new StudentUpdateDto();
                patchDocument.ApplyTo(studentDto, ModelState);

                if(!TryValidateModel(studentDto))
                {
                    return ValidationProblem(ModelState);
                }

                var studentToAdd = _mapper.Map<Student>(studentDto);
                studentToAdd.StudentId = studentId;

                _studentRepository.AddStudent(classId, studentToAdd);
                await _studentRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<StudentDto>(studentEntity);

                return CreatedAtRoute(
                    nameof(GetStudent),
                    new{
                        classId = classId,
                        studentId = dtoToReturn.StudentId
                    }, dtoToReturn
                );
            }

            var dtoToPatch = _mapper.Map<StudentUpdateDto>(studentEntity);

            patchDocument.ApplyTo(dtoToPatch, ModelState);

            if(!TryValidateModel(dtoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dtoToPatch, studentEntity);

            _studentRepository.UpdateStudent(studentEntity);

            await _studentRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(
            Guid classId, 
            Guid studentId
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository.GetStudentAsync(classId, studentId);

            if(studentEntity == null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(studentEntity);

            await _studentRepository.SaveAsync();

            return NoContent();
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

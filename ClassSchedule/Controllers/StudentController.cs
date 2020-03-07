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
using Microsoft.AspNetCore.Mvc;

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
    }
}

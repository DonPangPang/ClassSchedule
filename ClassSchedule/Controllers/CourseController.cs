using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Data;
using ClassSchedule.Services;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.DtoParameters;
using ClassSchedule.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/classes/{classId}/students/{studentId}/courses")]
    public class CourseController: ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(
            IClassRepository classRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository, 
            IMapper mapper)
        {
            _classRepository = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(
            Guid classId,
            Guid studentId,
            [FromQuery]CourseDtoParameters parameters
        )
        {
            if(!await _classRepository.ClassExitAsync(classId))
            {
                NotFound();
            }

            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                NotFound();
            }

            var courses = await _courseRepository.GetCoursesAsync(parameters);

            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return Ok(courseDtos);
        }

        [HttpGet("{courseId}", Name = nameof(GetCourse))]
        public async Task<ActionResult<CourseDto>> GetCourse(
            Guid studentId,
            Guid courseId
        )
        {

            if(! await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            if(! await _courseRepository.CourseExitAsync(courseId))
            {
                return NotFound();
            }

            var course = await _courseRepository.GetCourseAsync(studentId, courseId);

            var courseDtos = _mapper.Map<CourseDto>(course);

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(
            Guid classId,
            Guid studentId,
            [FromBody]CourseAddDto course
        )
        {
            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            var entity = _mapper.Map<Course>(course);
            entity.CourseId = Guid.NewGuid();
            entity.StudentId = studentId;

            _courseRepository.AddCourse(studentId, entity);
            await _courseRepository.SaveAsync();

            var dtoToReturn = _mapper.Map<CourseDto>(entity);

            return CreatedAtRoute(
                nameof(GetCourse),
                new{
                    classId = classId,
                    studentId = studentId,
                    courseId = dtoToReturn.CourseId
                }, dtoToReturn
            );
        }
        
        [HttpPut("{courseId}")]
        public async Task<ActionResult<CourseDto>> UpdateCourse(
            Guid classId,
            Guid studentId,
            Guid courseId,
            [FromBody]CourseUpdateDto course
        )
        {
            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            var courseEntity = await _courseRepository.GetCourseAsync(studentId, courseId);

            if(courseEntity == null)
            {
                var courseToAddEntity = _mapper.Map<Course>(course);
                courseToAddEntity.CourseId = courseId;

                _courseRepository.AddCourse(studentId, courseToAddEntity);

                await _courseRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<CourseDto>(courseToAddEntity);

                return CreatedAtRoute(
                    nameof(GetCourse),
                    new{
                        classId = classId,
                        courseId = dtoToReturn.CourseId
                    }, dtoToReturn
                );
            }

            _mapper.Map(course, courseEntity);

            _courseRepository.UpdateCourse(courseEntity);

            await _courseRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{courseId}")]
        public async Task<IActionResult> PartiallyUpdateCourse(
            Guid classId,
            Guid studentId,
            Guid courseId,
            JsonPatchDocument<CourseUpdateDto> patchDocument
        )
        {
            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            var courseEntity = await _courseRepository.GetCourseAsync(studentId, courseId);

            if(courseEntity == null)
            {
                var courseDto = new CourseUpdateDto();
                patchDocument.ApplyTo(courseDto, ModelState);

                if(!TryValidateModel(courseDto))
                {
                    return ValidationProblem(ModelState);
                }

                var courseToAdd = _mapper.Map<Course>(courseDto);
                courseToAdd.CourseId = courseId;
                courseToAdd.StudentId = studentId;

                _courseRepository.AddCourse(courseId, courseToAdd);
                await _courseRepository.SaveAsync();

                var dtoToReturn = _mapper.Map<CourseDto>(courseEntity);

                return CreatedAtRoute(
                    nameof(GetCourse),
                    new{
                        classId = classId,
                        studentId = studentId,
                        courseId = dtoToReturn.CourseId
                    }, dtoToReturn
                );
            }

            var dtoToPatch = _mapper.Map<CourseUpdateDto>(courseEntity);

            patchDocument.ApplyTo(dtoToPatch, ModelState);

            if(!TryValidateModel(dtoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dtoToPatch, courseEntity);

            _courseRepository.UpdateCourse(courseEntity);

            await _courseRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(
            Guid studentId,
            Guid courseId
        )
        {
            if(!await _studentRepository.StudentExitAsync(studentId))
            {
                return NotFound();
            }

            var courseEntity = await _courseRepository.GetCourseAsync(studentId, courseId);

            if(courseEntity == null)
            {
                return NotFound();
            }

            _courseRepository.DeleteCourse(courseEntity);

            await _courseRepository.SaveAsync();

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
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

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/classed/{classId}/students/{studentId}")]
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
            [FromBody]CourseDtoParameters parameters
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
    }
}
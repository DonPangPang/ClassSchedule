using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassSchedule.Data;
using ClassSchedule.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassSchedule.Controllers
{
    [ApiController]
    [Route("api/classed/{classId}/students/{studentId}")]
    public class CourseController: ControllerBase
    {
        private readonly ClassScheduleDbContext _context;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(_courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}

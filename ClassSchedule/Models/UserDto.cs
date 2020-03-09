using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Models
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid ClassId{get; set;}
        public Guid StudentId { get; set; }
    }
}

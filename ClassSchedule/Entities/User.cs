﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClassSchedule.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid ClassId{get; set;}
        public Guid StudentId { get; set; }
    }
}

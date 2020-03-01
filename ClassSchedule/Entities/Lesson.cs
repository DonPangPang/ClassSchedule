using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Entities
{
    [Flags]
    public enum Lesson
    {
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
        Five = 16,
        Six = 32,
        Seven = 64,
        Eight = 128,
        Nine = 256,
        Ten = 512
    }
}

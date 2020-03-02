using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.DtoParameters
{
    public class DtoPatameters
    {
        private const int MaxPageSize = 20;
        public string Name { get; set; }
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;

        public int PageSize
        {
            get => _pageSize = 5;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}

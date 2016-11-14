using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class PeriodHelper
    {
        public PeriodHelper() { }

        public PeriodHelper(DateTime start, DateTime end, string name)
        {
            StartPeriod = start;
            EndPeriod = end;
            Name = name;
        }

        public DateTime StartPeriod { get; set; }

        public DateTime EndPeriod { get; set; }

        public string Name { get; set; }
    }
}

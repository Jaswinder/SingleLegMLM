using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class LevelMaster
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int Income { get; set; }
        public int ForDays { get; set; }
        public int Team { get; set; }
        public int Direct { get; set; }
        public int TimePeriod { get; set; }
        public decimal PerDayIncome { get; set; }


    }
}
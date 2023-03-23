using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Models.Stages
{
    public class VideoInterviewQuestion
    {
        public string Question { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MaxDuration { get; set; } = string.Empty ;
        public long VideoDuration { get; set; }
        public long DeadlineInNumberOfDays { get; set; }
    }
}

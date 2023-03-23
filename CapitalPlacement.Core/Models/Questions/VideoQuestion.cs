using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Models.Questions
{
    public class VideoQuestion
    {

        public string Description { get; set; } = string.Empty;
        public string MaxDuration { get; set; } = string.Empty;
        public long Time { get; set; } = 0;
    }

}

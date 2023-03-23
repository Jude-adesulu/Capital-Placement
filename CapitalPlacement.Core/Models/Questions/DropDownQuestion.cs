using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Models.Questions
{
    public class DropDownQuestion
    {
        public List<DropDown> DropDowns { get; set; } = new List<DropDown>();
    }

    public class DropDown
    {
        public string Choice { get; set; } = "";
        public bool OtherOption { get; set; }

    }
}

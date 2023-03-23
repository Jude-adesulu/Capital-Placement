using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Models.Questions
{
    public class MultichoiceQuestion
    {
        public List<Choice> Choices { get; set; } = new List<Choice>();
        public int MaximumChoiceAllowed { get; set; }

    }

    public class Choice
    {
        public string Choices { get; set; } = "";
        public bool OtherOption { get; set; }
    }
}

using CapitalPlacement.Core.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.DTOs.Requests
{
    public class AdditionalQuestionRequest
    {
        public string Content { get; set; } = "";
        public Question QuestionsType { get; set; } = new Question();
    }

    public class Question
    {
        public DateQuestion? DateQuestion { get; set; }
        public YesOrNoQuestion? YesOrNoQuestion { get; set; }
        public ParagraphQuestion? ParagraphQuestion { get; set; }
        public FileUploadQuestion? FileUploadQuestion { get; set; }
        public NumberQuestion? NumberQuestion { get; set; }
        public MultichoiceQuestion? MultipleChoiceQuestion { get; set; }
        public DropDownQuestion? DropdownQuestion { get; set; }
        public VideoQuestion? VideoBasedQuestion { get; set; }
    }
}

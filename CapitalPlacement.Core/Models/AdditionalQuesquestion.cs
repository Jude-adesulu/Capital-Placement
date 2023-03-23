using CapitalPlacement.Core.Models.Questions;
using System;

namespace CapitalPlacement.Core.Models
{
    public class AdditionalQuestion : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public string Content { get; set; } = "";
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

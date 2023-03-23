using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.DTOs.Responses
{
    public class AddtionalQuestionResponseModal
    {
        public Guid Id { get; set; }
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

        public static implicit operator AddtionalQuestionResponseModal(AdditionalQuestion _)
        {
            return new AddtionalQuestionResponseModal
            {
                Id = _.Id,
                ApplicationId = _.ApplicationId,
                Content = _.Content,
                DateQuestion = _.DateQuestion,
                YesOrNoQuestion = _.YesOrNoQuestion,
                ParagraphQuestion = _.ParagraphQuestion,
                FileUploadQuestion = _.FileUploadQuestion,
                NumberQuestion = _.NumberQuestion,
                MultipleChoiceQuestion = _.MultipleChoiceQuestion,
                DropdownQuestion = _.DropdownQuestion,
                VideoBasedQuestion = _.VideoBasedQuestion
            };
        }
    }
}

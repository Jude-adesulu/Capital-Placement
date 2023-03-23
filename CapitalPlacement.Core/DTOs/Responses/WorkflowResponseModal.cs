using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Models.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Responses
{
    public class WorkflowResponseModal
    {
        public Guid Id { get; set; }
        public string StageName { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StageType StageType { get; set; }
        public List<VideoInterviewQuestion> VideoInterviews { get; set; } = new List<VideoInterviewQuestion>();
        public DateTime CreatedOn { get; set; }

        public static implicit operator WorkflowResponseModal(Stage _)
        {
            return new WorkflowResponseModal
            {
                Id = _.Id,
                StageName = _.StageName,
                StageType = _.StageType,
                VideoInterviews = _.VideoInterviews.ToList(),
                CreatedOn = _.CreatedOn

            };
        }
    }
}

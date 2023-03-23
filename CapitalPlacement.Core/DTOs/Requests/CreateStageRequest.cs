using CapitalPlacement.Core.Models.Stages;
using CapitalPlacement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Requests
{
    public class CreateStageRequest
    {
        public string StageName { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StageType StageType { get; set; } = StageType.Applied;
        public List<VideoInterviewQuestion> VideoInterviews { get; set; } = new List<VideoInterviewQuestion>();
    }

    public class UpdateStageRequest
    {
        public string? StageName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StageType? StageType { get; set; }
        public List<VideoInterviewQuestion>? VideoInterviews { get; set; }
    }
}

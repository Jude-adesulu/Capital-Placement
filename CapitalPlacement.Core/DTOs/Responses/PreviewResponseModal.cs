using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Responses
{
    public class PreviewResponseModal
    {
        public string CoverImage { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public string Benefit { get; set; } = string.Empty;
        public string Criteria { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProgramType ProgramType { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Open { get; set; }
        public DateTime? Close { get; set; }
        public int Duration { get; set; }
        public string? Location { get; set; }
    }
}

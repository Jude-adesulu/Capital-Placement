using CapitalPlacement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Responses
{
    public class ProgramResponseModal
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public List<Skill> Skills { get; set; }
        public string Benefit { get; set; } = string.Empty;
        public string Criteria { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProgramType ProgramType { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Open { get; set; }
        public DateTime? Close { get; set; }
        public int Duration { get; set; }
        public string? Location { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Qualification MinQualification { get; set; }
        public long MaximumNumberOfApplication { get; set; }
        public DateTime CreatedOn { get; set; }

        public static implicit operator ProgramResponseModal(Program _)
        {
            return new ProgramResponseModal
            {
                Id = _.Id,
                Title = _.Title,
                Summary = _.Summary,
                Description = _.Description,
                Skills = _.Skill.ToList(),
                Benefit = _.Benefit,
                Criteria = _.Criteria,
                ProgramType = _.ProgramType,
                Start = _.Start,
                Open = _.Open,
                Close = _.Close,
                Location = _.Location,
                MinQualification = _.MinQualification,
                MaximumNumberOfApplication = _.MaximumNumberOfApplication,
                CreatedOn = _.CreatedOn

            };
        }
    }
}

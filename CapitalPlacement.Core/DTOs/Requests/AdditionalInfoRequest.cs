using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Requests
{
    public class AdditionalInfoRequest
    {
        [Required(ErrorMessage = "Program type required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProgramType ProgramType { get; set; }
        public DateTime? Start { get; set; }
        [Required(ErrorMessage = "Open date required")]
        public DateTime? Open { get; set; }
        [Required(ErrorMessage = "Close date required")]
        public DateTime? Close { get; set; }
        public int Duration { get; set; }
        [Required(ErrorMessage = "Program Location required")]
        public string? Location { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Qualification MinQualification { get; set; }
        public long MaximumNumberOfApplication { get; set; }
    }
}

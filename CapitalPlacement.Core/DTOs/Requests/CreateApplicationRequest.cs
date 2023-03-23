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
    public class CreateApplicationRequest
    {
        [Required(ErrorMessage = "Image is required")]
        public string CoverImage { get; set; } = "";
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = "";
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Nationality { get; set; } = "";
        public string CurrentResidence { get; set; } = "";
        public long IdNumber { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
    }

    public class UpdateApplicationRequest
    {
        public string? CoverImage { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CurrentResidence { get; set; }
    }
}

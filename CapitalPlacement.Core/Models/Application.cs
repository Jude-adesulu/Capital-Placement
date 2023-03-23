using CapitalPlacement.Core.Models.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.Models
{
    public class Application : BaseEntity
    {
        public string CoverImage { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = ""; 
        public string EmailAddress { get; set; } = ""; 
        public string PhoneNumber { get; set; } = ""; 
        public string Nationality { get; set; } = "";
        public string CurrentResidence { get; set; } = "";
        public long IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        public ICollection<Stage> Workflows { get; set; } = new HashSet<Stage>();
        public Guid ProgramId { get; set; }
        public Profile Profile { get; set; } = new Profile();
    }
}

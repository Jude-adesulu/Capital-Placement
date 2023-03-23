using CapitalPlacement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.DTOs.Responses
{
    public class ApplicationResponseModal
    {
        public Guid Id { get; set; }
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
        public DateTime CreatedOn { get; set; }

        public static implicit operator ApplicationResponseModal(Application _)
        {
            return new ApplicationResponseModal
            {
                Id = _.Id,
                CoverImage = _.CoverImage,
                FirstName = _.FirstName,
                LastName = _.LastName,
                EmailAddress = _.EmailAddress,
                PhoneNumber = _.PhoneNumber,
                Nationality = _.Nationality,
                CurrentResidence = _.CurrentResidence,
                CreatedOn = _.CreatedOn,
                DateOfBirth = _.DateOfBirth,
                Gender = _.Gender,
                IdNumber = _.IdNumber,
            };
        }
    }
}

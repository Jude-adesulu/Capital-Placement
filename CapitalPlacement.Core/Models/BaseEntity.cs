using Abp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = SequentialGuidGenerator.Instance.Create(databaseType: SequentialGuidGenerator.SequentialGuidDatabaseType.SqlServer);
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}

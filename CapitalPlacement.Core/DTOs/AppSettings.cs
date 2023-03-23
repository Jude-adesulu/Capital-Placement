using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.DTOs
{
    public class AppSettings
    {
        /// <summary>
        /// DB Connection String
        /// </summary>
        public string DB { get; set; } = "";
        public string DBName { get; set; } = "";
    }
}

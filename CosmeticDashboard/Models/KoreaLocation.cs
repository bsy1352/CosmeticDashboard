using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticDashboard.Models
{
    public class KoreaLocation
    {
        [Key]  // -> Primary Key 설정
        public string LocationCode { get; set; }

        public string LocationName { get; set; }
    }
}

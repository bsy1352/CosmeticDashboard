using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticDashboard.Models
{
    public class Factory
    {
        [Key]  // -> Primary Key 설정
        public int FactoryCode { get; set; }

        public string FactoryName { get; set; }

        public string LocationCode { get; set; }

        [ForeignKey("LocationCode")]
        public virtual KoreaLocation KoreaLocation { get; set; }
    }
}

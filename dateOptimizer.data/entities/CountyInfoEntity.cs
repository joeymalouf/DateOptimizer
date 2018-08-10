using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dateOptimizer.data.entities
{
    public class CountyInfoEntity
    {
        [Key]
        public int Fip { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }
}
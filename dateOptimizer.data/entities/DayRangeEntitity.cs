using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dateOptimizer.data.entities

{
    public class DayRangeEntitity
    {
        [Key]

        public int Fip { get; set; }

        public double Day0 { get; set; }

        public double Day1 { get; set; }

        public double Day2 { get; set; }

        public double Day3 { get; set; }

        public double Day4 { get; set; }

        public double Day5 { get; set; }

        public double Day6 { get; set; }

        public double Day7 { get; set; }

        public double Day8 { get; set; }

        public double Day9 { get; set; }

        public double Day10 { get; set; }


    }    
}
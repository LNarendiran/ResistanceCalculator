using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCodeCalculator.Core.Models
{
    public class Resistance
    {
        [Required]
        public string MinResistance { get; set; }

        [Required]
        public string NormalResistance { get; set; }

        [Required]
        public string MaxResistance { get; set; }

        public Resistance() { }

        public Resistance(string strMinResistance, string strNormalResistance,string strMaxResistance)
        {
            this.MinResistance = strMinResistance;
            this.NormalResistance = strNormalResistance;
            this.MaxResistance = strMaxResistance;
        }
    }
}

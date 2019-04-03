using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.UI;

namespace ElectronicCodeCalculator.Core.Models
{
    public class Multiplier
    {
        [Required(ErrorMessage = "Please select Multiplier.")]
        public string Color { get; set; }

        [Required]
        public double Base { get; set; }

        [Required]
        public double Exponent { get; set; }

        public Multiplier()
        {
            Base = 10;
        }

        public string ColorValue {
            get {
                return Color + " - " + Base.ToString() + " ^ " + Exponent.ToString();
            }
        }      
    }
}
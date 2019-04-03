using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCodeCalculator.Core.Models
{
    public class SignificantFigure
    {
        [Required(ErrorMessage ="Please select Significant Figure.")]
        public string Color { get; set; }

        [Required]
        public int Value { get; set; }   
        
        public string ColorValue {
            get {
                return Color + " - " + Value.ToString();
            }
        }     
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCodeCalculator.Core.Models
{
    public class Tolerance
    {
        [Required(ErrorMessage = "Please select Tolerance.")]
        public string Color { get; set; }

        [Required]
        public bool IsPositiveTolerance { get; set; }

        [Required]
        public bool IsNegativeTolerance { get; set; }

        [Required]
        public double Value { get; set; }

        public string ColorValue { get; set; }

        public Tolerance()
        {
            IsPositiveTolerance = true;
            IsNegativeTolerance = true;
        }
    }
}

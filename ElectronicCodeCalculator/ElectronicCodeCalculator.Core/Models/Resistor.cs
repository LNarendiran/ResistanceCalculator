using ElectronicCodeCalculator.Core.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCodeCalculator.Core.Models
{
    public class Resistor
    {
        [Required]
        public SignificantFigure FirstBand { get; set; }

        [Required]
        public SignificantFigure SecondBand { get; set; }

        [Required]
        public Multiplier ThirdBand { get; set; }

        [Required]
        public Tolerance FourthBand { get; set; } 
        
        public Resistance Value { get; set; }    
        public Resistor() { }
        public Resistor(string strBandAColor, string strBandBColor, string strBandCColor, string strBandDColor)
        {
            this.FirstBand = ResistorConstants.SignificantMaster.Find(x => strBandAColor.Length > 0 && x.Color.Contains(strBandAColor));
            this.SecondBand = ResistorConstants.SignificantMaster.Find(x => strBandBColor.Length > 0 && x.Color.Contains(strBandBColor));
            this.ThirdBand = ResistorConstants.MultiplierMaster.Find(x => strBandCColor.Length > 0 && x.Color.Contains(strBandCColor));
            this.FourthBand = ResistorConstants.ToleranceMaster.Find(x => strBandDColor.Length > 0 && x.Color.Contains(strBandDColor));
        }
    }
}

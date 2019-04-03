using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicCodeCalculator.Core.Models;

namespace ElectronicCodeCalculator.Core.Interfaces
{
    public interface IResistanceCalculator
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="strBandAColor">The color of the first figure of component value band.</param>
        /// <param name="strBandBColor">The color of the second significant figure band.</param>
        /// <param name="strBandCColor">The color of the decimal multiplier band.</param>
        /// <param name="strBandDColor">The color of the tolerance value band.</param>
        Resistance CalculateOhmValue(string strBandAColor, string strBandBColor, string strBandCColor, string strBandDColor);

    }
}

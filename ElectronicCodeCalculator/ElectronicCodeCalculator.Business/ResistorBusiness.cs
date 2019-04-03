using System;
using ElectronicCodeCalculator.Core.Interfaces;
using ElectronicCodeCalculator.Core.Models;
using ElectronicCodeCalculator.Core.Constants;

namespace ElectronicCodeCalculator.Business
{
    public class ResistorBusiness: IResistanceCalculator
    {
        /// <summary>
        /// Calculates the ResistanceValues.
        /// </summary>
        /// <param name="strBandAColor"></param>
        /// <param name="strBandBColor"></param>
        /// <param name="strBandCColor"></param>
        /// <param name="strBandDColor"></param>
        /// <returns></returns>
        public Resistance CalculateOhmValue(string strBandAColor, string strBandBColor, string strBandCColor, string strBandDColor)
        {
            double dblFirstBand, dblSecondBand, dblMulitplierBase, dblMultiplierExponent, dblTolerance;   
            double dblNormalResistance, dblMinResistance, dblMaxResistance;
            Resistor objResistor;        
            Resistance objResistance;            
            try
            {
                objResistance = new Resistance();
                if (strBandAColor?.Length > 0 && strBandBColor?.Length > 0 && strBandCColor?.Length > 0 && strBandDColor?.Length > 0)
                {
                    objResistor = new Resistor(strBandAColor, strBandBColor, strBandCColor, strBandDColor);

                    //Get the Resistor property values
                    dblFirstBand = Convert.ToDouble(objResistor?.FirstBand?.Value);
                    dblSecondBand = Convert.ToDouble(objResistor?.SecondBand?.Value);
                    dblMulitplierBase = Convert.ToDouble(objResistor?.ThirdBand?.Base);
                    dblMultiplierExponent = Convert.ToDouble(objResistor?.ThirdBand?.Exponent);
                    dblTolerance = Convert.ToDouble(objResistor?.FourthBand?.Value);

                    //Calculates all three resistance values - Normal, Min & Max Resistances                    
                    dblNormalResistance = Convert.ToDouble(string.Format("{0}{1}",dblFirstBand, dblSecondBand));
                    dblNormalResistance = dblNormalResistance * Math.Pow(dblMulitplierBase, dblMultiplierExponent);
                    dblMinResistance = dblNormalResistance * (1 - dblTolerance / 100);
                    dblMaxResistance = dblNormalResistance * (1 + dblTolerance / 100);

                    //Sets the formatted Resistance Values in the Resistance Object
                    objResistance.NormalResistance = FormatResistance(dblNormalResistance);
                    objResistance.MinResistance = FormatResistance(dblMinResistance);
                    objResistance.MaxResistance = FormatResistance(dblMaxResistance);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objResistance;
        }

        /// <summary>
        /// Used to format large resistance values
        /// </summary>
        /// <param name="num"> resistance value </param>
        /// <returns>formatted string of a resistance value</returns>
        public string FormatResistance(double num)
        {
            try
            {
                //to show in Mega format 
                if (num >= 100000000)
                    return (num / 1000000).ToString("#,0M");

                else if (num >= 10000000)
                    return (num / 1000000).ToString("0.#") + "M";
                //to show in Kilo format
                else if (num >= 100000)
                    return (num / 1000).ToString("#,0K");

                else if (num >= 10000)
                    return (num / 1000).ToString("0.#") + "K";

                else
                    return num.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

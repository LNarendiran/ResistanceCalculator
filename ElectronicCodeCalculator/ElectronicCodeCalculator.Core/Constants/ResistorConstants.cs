using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicCodeCalculator.Core.Models;

namespace ElectronicCodeCalculator.Core.Constants
{
    public class ResistorConstants
    {
        public static List<SignificantFigure> SignificantMaster = new List<SignificantFigure>
         {
             new SignificantFigure() { Color = "black", Value = 0},
             new SignificantFigure() { Color="brown", Value=1} ,
             new SignificantFigure() { Color="red", Value=2},
             new SignificantFigure() { Color="orange",Value= 3},
             new SignificantFigure() { Color="yellow", Value=4},
             new SignificantFigure() { Color="green", Value=5},
             new SignificantFigure() { Color="blue",Value= 6},
             new SignificantFigure() { Color="violet", Value=7},
             new SignificantFigure() { Color="gray",Value= 8},
             new SignificantFigure() { Color="white", Value=9}
         };

        public static List<Multiplier> MultiplierMaster = new List<Multiplier>
         {
             new Multiplier() { Color = "pink", Exponent=-3},
             new Multiplier() { Color="silver", Exponent=-2},
             new Multiplier() { Color="gold",Exponent=-1},
             new Multiplier() { Color="black", Exponent=-0},
             new Multiplier() { Color="brown", Exponent=1},
             new Multiplier() { Color="red", Exponent=2},
             new Multiplier() { Color="orange", Exponent=3},
             new Multiplier() { Color="yellow", Exponent=4},
             new Multiplier() { Color="green", Exponent=5},
             new Multiplier() { Color="blue", Exponent=6},
             new Multiplier() { Color="violet", Exponent=7},
             new Multiplier() { Color="gray", Exponent=8},
             new Multiplier() { Color="white",Exponent=9}
         };

        public static List<Tolerance> ToleranceMaster = new List<Tolerance>
         {
             new Tolerance() { Color="silver", Value=10, ColorValue ="silver ± 10%"},
             new Tolerance() { Color="gold", Value=5, ColorValue ="gold ± 5%"},             
             new Tolerance() { Color="brown", Value=1, ColorValue ="brown ± 1%"},
             new Tolerance() { Color="red",  Value=2, ColorValue ="red ± 2%"},            
             new Tolerance() { Color="orange", Value=0.05, ColorValue ="orange ± 0.05%"},
             new Tolerance() { Color="yellow", Value=0.02, ColorValue ="yellow ± 0.02%"},
             new Tolerance() { Color="green",  Value=0.5, ColorValue ="green ± 0.5%"},
             new Tolerance() { Color="blue", Value=0.25, ColorValue ="blue ± 0.25%"},
             new Tolerance() { Color="violet", Value=0.1, ColorValue ="violet ± 0.1%"},
             new Tolerance() { Color="gray", Value=0.01, ColorValue ="gray ± 0.01%"}            
         };
    }
}



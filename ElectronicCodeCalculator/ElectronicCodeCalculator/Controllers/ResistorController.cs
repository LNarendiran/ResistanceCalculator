using ElectronicCodeCalculator.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicCodeCalculator.Core.Models;
using ElectronicCodeCalculator.Core.Interfaces;
using ElectronicCodeCalculator.Business;

namespace ElectronicCodeCalculator.Controllers
{
    public class ResistorController : Controller
    {
        private IResistanceCalculator m_ResistanceCalculator;

        //Constructor - Dependency injection (Loosely Coupled)
        public ResistorController(IResistanceCalculator ICalculator)
        {
            m_ResistanceCalculator = ICalculator;
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Calls the resistance calculation method in Business layer
        /// </summary>
        /// <param name="objResistor"></param>
        /// <returns></returns>
        [HttpPost]
        //public ActionResult CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        public ActionResult CalculateOhmValue(Resistor objResistor)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { error = GetModelStateErrors() });
                }              
                    // Invoke CalculateOhmValue in the Business Layer.                
                    Resistance objResistance = m_ResistanceCalculator.CalculateOhmValue(objResistor?.FirstBand?.Color, objResistor?.SecondBand?.Color, objResistor?.ThirdBand?.Color, objResistor?.FourthBand?.Color);

                    /// JSON response
                    return Json(new { min = objResistance?.MinResistance, normal = objResistance?.NormalResistance, max = objResistance?.MaxResistance });
               
            }
            catch (Exception ex)
            {               
                return Json(new { error = "Exception ocurred during resistance calculation: " + ex.Message });
            }                
        }

        private string GetModelStateErrors()
        {
            var modelQuery = (from kvp in ModelState
                              let field = kvp.Key
                              let state = kvp.Value
                              where state.Errors.Count > 0
                              let val = state.Value.AttemptedValue ?? "[NULL]"

                              let errors = string.Join(";", state.Errors.Select(err => err.ErrorMessage))
                              select string.Format("{0}:[{1}] (ERRORS: {2})", field, val, errors));

           return string.Join(Environment.NewLine, modelQuery);
        }
      
    }
}
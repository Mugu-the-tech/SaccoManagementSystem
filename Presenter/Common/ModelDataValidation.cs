using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Presenter.Common
{
    public class ModelDataValidation
    {
        public void Validate(object Model)
        {
            string errorMessage = "";
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(Model);
            bool isValid = Validator.TryValidateObject(Model, context, validationResults, true);
            if (!isValid)
            {
                foreach(var item  in validationResults)
                    errorMessage += "_" +item.ErrorMessage+ "\n";
                throw new Exception(errorMessage);
            }
        }
    }
}

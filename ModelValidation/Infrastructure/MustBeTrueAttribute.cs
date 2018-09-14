using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Infrastructure
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {        
        public string ErrorMessage { get; set; } = "This value must be true";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            bool? value = context.Model as bool?;
            if (!value.HasValue || value.Value == false)
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}

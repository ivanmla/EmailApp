using System.Collections.Generic;

namespace API.Helpers
{
    public class ValidationResult
    {
        public List<string> Errors { get; set; }

        public ValidationResult(List<string> errors)
        {
            Errors = errors;
        }
    }
}
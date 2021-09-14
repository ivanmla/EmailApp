using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ErrorInfo
    {
        public string PropNaziv { get; set; }
        public List<string> ErrorMessages { get; set; }

        public ErrorInfo(string propNaziv, List<string> errorMessages)
        {
            PropNaziv = propNaziv;
            ErrorMessages = errorMessages;
        }
    }
}

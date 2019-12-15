using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.BL.Settings
{
    public class ValidException: Exception
    {
        public string Property { get; protected set; }

        public ValidException(string ErrorMessage, string property) : base(ErrorMessage)
        {
            Property = property;
        }
    }
}

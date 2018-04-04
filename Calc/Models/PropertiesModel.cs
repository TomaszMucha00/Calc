using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    class PropertiesModel
    {
        public static bool IsShiftOn { get; set; }
        public static string MathExpression { get; set; }
        public static string Number { get; set; }
        public static bool IsCleared { get; set; }

        static PropertiesModel()
        {
            Number = ""; 
        }
    }
}

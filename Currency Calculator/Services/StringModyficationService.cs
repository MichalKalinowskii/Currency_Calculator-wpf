using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Currency_Calculator.Services
{
    public class StringModyficationService
    {
        public double ModifyCorrectStringToDouble(string input)
        {
            input = Regex.Replace(input, @"\s+", "");
            input = Regex.Replace(input, @",", ".");
            double value;
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
            return value;
        }

    }
}

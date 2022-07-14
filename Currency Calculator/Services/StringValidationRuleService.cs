using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Currency_Calculator.InputRules
{
    public class StringValidationRuleService
    {
        public bool Validate(string input)
        {
            if (input != null)
            {
                bool rt = Regex.IsMatch(input, "^( *[0-9] *)+((,|.){1}( *[0-9] *)+)?$");
                if (rt)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Calculations
{
    public class MakeCalculationService
    {
        public double Calculate(double selectedCurrencyConvertFrom, double selectedCurrencyConvertTo, double givenValue)
        {
            try
            {
                double result = Math.Round( (selectedCurrencyConvertFrom / selectedCurrencyConvertTo * givenValue), 4, MidpointRounding.AwayFromZero);
                return result;
            }
            catch
            {
                return 0;
            }
        }

    }
}

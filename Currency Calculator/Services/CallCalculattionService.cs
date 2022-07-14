using Currency_Calculator.Calculations;
using Currency_Calculator.InputRules;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Services
{
    public class CallCalculattionService

    {
        private StringValidationRuleService rule = new();

        private StringModyficationService modifaction = new();

        private MakeCalculationService result = new();


        public void CallCalculattion(CalculatorViewModel calculator)
        {
            if (calculator.SelectedCurrencyConvertFrom != null && calculator.GivenValue != null && calculator.SelectedCurrencyConvertTo != null)
            {
                try
                {
                    if (rule.Validate(calculator.GivenValue))
                    {
                        calculator.DisplayResult = result.Calculate(
                            calculator.SelectedCurrencyConvertFrom.ExchangeRate,
                            calculator.SelectedCurrencyConvertTo.ExchangeRate,
                            modifaction.ModifyCorrectStringToDouble(calculator.GivenValue));
                    }
                    else throw new Exception();

                }
                catch(Exception)
                {
                    calculator.DisplayResult = 0;
                }

            }
        }

    }
}

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


        public void CallCalculattionForFirstInput(CalculatorViewModel calculator)
        {
            if (calculator.SelectedCurrencyConvertFrom != null && calculator.GivenValueByUser != null
                && calculator.SelectedCurrencyConvertTo != null)
            {
                try
                {
                    if (rule.Validate(calculator.GivenValueByUser))
                    {
                        calculator.DisplayResult = GetCalculationResult(
                            calculator.SelectedCurrencyConvertFrom.ExchangeRate, 
                            calculator.SelectedCurrencyConvertTo.ExchangeRate,
                            calculator.GivenValueByUser);
                    }
                    else throw new Exception();

                }
                catch (Exception)
                {
                    calculator.DisplayResult = "";
                }

            }
        }

        public void CallCalculattionForSecondInput(CalculatorViewModel calculator)
        {
            if (calculator.SelectedCurrencyConvertFrom != null && calculator.DisplayResult != null
                && calculator.SelectedCurrencyConvertTo != null)
            {
                try
                {
                    if (rule.Validate(calculator.DisplayResult))
                    {
                        calculator.GivenValueByUser = GetCalculationResult(
                            calculator.SelectedCurrencyConvertTo.ExchangeRate,
                            calculator.SelectedCurrencyConvertFrom.ExchangeRate,
                            calculator.DisplayResult);
                    }
                    else throw new Exception();

                }
                catch (Exception)
                {
                    calculator.GivenValueByUser = "";
                }
            }
        }

        private string GetCalculationResult(double ExchangeRateFrom, double ExchangeRateTo, string givenValue)
        {
            return result.Calculate(
                            ExchangeRateFrom,
                            ExchangeRateTo,
                            modifaction.ModifyCorrectStringToDouble(givenValue))
                .ToString();
        }

    }
}

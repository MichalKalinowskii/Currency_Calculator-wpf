using Currency_Calculator.Domain.Models;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Services
{
    public class LoadCurrencyService
    {
        public static void LoadCurrency(List<CurrencyModel> currencyList,DateTime effectiveDate ,CalculatorViewModel calculatorViewModel)
        {
            calculatorViewModel.CurrenciesCode.Clear();
            foreach( var currency in currencyList)
            {
                calculatorViewModel.CurrenciesCode.Add(new CurrencyModel( currency.Name,currency.Code,currency.ExchangeRate));
            }
            
            calculatorViewModel.EffectiveDate = effectiveDate;
            calculatorViewModel.DisplayResult = 0;
        }

    }
}

using Currency_Calculator.Api;
using Currency_Calculator.Domain.Models;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Services
{
    public static class CallApiService
    {

        public static async void CallApi(CalculatorViewModel calculatorViewModel)
        {
            try
            {
                ApiHelper.InitializeClinet();
                CurrencyRatesJsonModel currencyInfo = await CurrencyProcesor.LoadCurrencyInformation(calculatorViewModel);

                List<CurrencyModel> listOfCurrencyFromApi = new();

                listOfCurrencyFromApi.Add(new CurrencyModel("polski złoty", "PLN", 1.0));
                foreach (var currency in currencyInfo.Rates)
                {
                    listOfCurrencyFromApi.Add(new CurrencyModel(currency.Currency, currency.Code, currency.Mid));
                }
                LoadCurrencyService.LoadCurrency(listOfCurrencyFromApi, DateTime.Parse(currencyInfo.EffectiveDate), calculatorViewModel);
                
                calculatorViewModel.GivenDate = DateTime.Parse(currencyInfo.EffectiveDate);
            }
            catch (Exception)
            {
                MessageBox.Show("Table at this date you selected is not existing. Valid date are those between monday and friday (excluding holidays).", "Date", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

    }
}

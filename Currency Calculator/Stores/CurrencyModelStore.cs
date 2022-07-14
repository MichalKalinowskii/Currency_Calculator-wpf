using Currency_Calculator.Domain.Commands;
using Currency_Calculator.Domain.Models;
using Currency_Calculator.Domain.Queries;
using Currency_Calculator.EntityFramework.Commands;
using Currency_Calculator.EntityFramework.Queries;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Stores
{
    public class CurrencyModelStore
    {

        public event Action<CalculatorViewModel> CurrecnyModelSaved;

        private readonly ISaveCurrencyCommand _saveCurrencyCommand;
        private readonly IGetAllCurrienciesQuery _getAllCurrienciesQuery;
        private readonly Dictionary<DateTime, List<CurrencyModel>> _currencyStore;


        public CurrencyModelStore( Dictionary<DateTime, List<CurrencyModel>> currencyStore, 
            ISaveCurrencyCommand saveCurrencyCommand, 
            IGetAllCurrienciesQuery getAllCurrienciesQuery)
        {
            _currencyStore = currencyStore;
            _saveCurrencyCommand = saveCurrencyCommand;
            _getAllCurrienciesQuery = getAllCurrienciesQuery;
        }

        private async void StoreCurrency(CalculatorViewModel calculatorViewModel)
        {
            if (!_currencyStore.ContainsKey(calculatorViewModel.EffectiveDate))
            {
                List<CurrencyModel> listOfCurrency = new();
                foreach(var rates in calculatorViewModel.CurrenciesCode)
                {
                    listOfCurrency.Add(new CurrencyModel(rates.Name, rates.Code, rates.ExchangeRate));
                }

                _currencyStore.Add(calculatorViewModel.EffectiveDate, listOfCurrency);
                await Saved(calculatorViewModel);
                await _saveCurrencyCommand.Execute(new CurrecnyRatesAndEffectiveDateModel(calculatorViewModel.EffectiveDate, _currencyStore[calculatorViewModel.EffectiveDate]));
            }

            else
            {
                MessageBox.Show("This table is already saved!", "Table", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }   

        public async Task Load(CalculatorViewModel calculatorViewModel)
        {
            List<CurrecnyRatesAndEffectiveDateModel> currecnyRatesAndEffectiveDateModel = await _getAllCurrienciesQuery.Execute();
            
            foreach (var item in currecnyRatesAndEffectiveDateModel)
            {
                _currencyStore.Add(item.EffectiveDate, item.Rates);
            }
            List<DateTime> keyList = new List<DateTime>(this._currencyStore.Keys);
            foreach (DateTime date in keyList)
            {
                calculatorViewModel.ListOfSavedDates.Add(date);
            }
            CurrecnyModelSaved?.Invoke(calculatorViewModel);
            
        }

        public void OnSave(CalculatorViewModel calculatorViewModel)
        {
            StoreCurrency(calculatorViewModel);          
        }

        private async Task Saved(CalculatorViewModel calculatorViewModel)
        {
            CurrecnyModelSaved?.Invoke(calculatorViewModel);
        }

        public List<CurrencyModel> ReturnListOfCurrency(DateTime date)
        {
            return _currencyStore[date];
        }



    }
}

using Currency_Calculator.Domain.Models;
using Currency_Calculator.Services;
using Currency_Calculator.Stores;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Commands
{
    public class CalculatorLoadCommand : CommandBase
    {
        private CalculatorViewModel _calculatorViewModel;

        private CurrencyModelStore _currencyModelStore;

        public CalculatorLoadCommand(CalculatorViewModel calculatorViewModel, CurrencyModelStore currencyStore)
        {
            _calculatorViewModel = calculatorViewModel;
            _currencyModelStore = currencyStore;

            _calculatorViewModel.PropertyChanged += OnDateToLoadChanged;
        }

        public override void Execute(object parameter)
        {
            List<CurrencyModel> listOfCurrency = _currencyModelStore.ReturnListOfCurrency(DateTime.Parse(_calculatorViewModel.DateToLoad));

            LoadCurrencyService.LoadCurrency(listOfCurrency, DateTime.Parse(_calculatorViewModel.DateToLoad), _calculatorViewModel);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_calculatorViewModel.DateToLoad) && base.CanExecute(parameter);
        }
        private void OnDateToLoadChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CalculatorViewModel.DateToLoad))
            {
                OnCanExecutedChanged();
            }
        }
    }
}

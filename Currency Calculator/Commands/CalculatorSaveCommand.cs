using Currency_Calculator.Stores;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Commands
{
    class CalculatorSaveCommand : CommandBase
    {
        private CurrencyModelStore _currencyModelStore;
        private CalculatorViewModel _calculatorViewModel;

        public CalculatorSaveCommand(CalculatorViewModel calculatorViewModel, CurrencyModelStore currencyModelStore)
        {
            _calculatorViewModel = calculatorViewModel;
            _currencyModelStore = currencyModelStore;
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (_calculatorViewModel.EffectiveDate != DateTime.MinValue)
                {
                    _currencyModelStore.OnSave(_calculatorViewModel);
                }
                else throw new Exception(); 
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save this table!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

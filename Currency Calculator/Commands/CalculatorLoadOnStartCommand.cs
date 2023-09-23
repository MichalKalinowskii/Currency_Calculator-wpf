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
    public class CalculatorLoadOnStartCommand : CommandBase
    {
        private readonly CurrencyModelStore _currencyModelStore;
        private readonly CalculatorViewModel _calculatorViewModel;


        public CalculatorLoadOnStartCommand(CalculatorViewModel calculatorViewModel, CurrencyModelStore currencyModelStore)
        {
            _currencyModelStore = currencyModelStore;
            _calculatorViewModel = calculatorViewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _currencyModelStore.Load(_calculatorViewModel);
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to load saved data!", "Table", MessageBoxButton.OK, MessageBoxImage.Error);               
            }
            
        }
    }
}

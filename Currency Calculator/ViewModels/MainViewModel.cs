using Currency_Calculator.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Currency_Calculator.ViewModels
{
    public class MainViewModel : Window
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(CurrencyModelStore currencyStore)
        {
            CurrentViewModel = new CalculatorViewModel(currencyStore);
        }
    }
}

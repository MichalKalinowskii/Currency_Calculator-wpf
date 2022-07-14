using Currency_Calculator.Services;
using Currency_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator.Commands
{

    class CalculatorSelectCommand : CommandBase
    {

        private readonly CalculatorViewModel _calculatorViewModel;

        public CalculatorSelectCommand(CalculatorViewModel calculatorViewModel)
        {
            _calculatorViewModel = calculatorViewModel;
        }

        public override void Execute(object parameter)
        {
            CallApiService.CallApi(_calculatorViewModel);
        }
    }
}

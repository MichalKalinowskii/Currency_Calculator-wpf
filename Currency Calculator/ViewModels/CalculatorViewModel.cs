using Currency_Calculator.Commands;
using Currency_Calculator.Domain.Models;
using Currency_Calculator.Services;
using Currency_Calculator.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Currency_Calculator.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {

        public bool CallucationAlreadMade { get; set; }

        private string _givenValue;
        public string GivenValueByUser
        {
            get { return _givenValue; }
            set 
            {
                _givenValue = value;
                OnPropertyChanged(nameof(GivenValueByUser));
                if(!CallucationAlreadMade)
                    GetCalculattion(nameof(GivenValueByUser));
            }
        }

        private string _displayResult;
        public string DisplayResult
        {
            get { return _displayResult; }
            set
            {
                _displayResult = value;
                OnPropertyChanged(nameof(DisplayResult));
                if (!CallucationAlreadMade)
                    GetCalculattion(nameof(DisplayResult));
            }
        }


        private DateTime _givenDate=DateTime.Today;
        public DateTime GivenDate
        {
            get { return _givenDate; }
            set
            {
                _givenDate = value;
                OnPropertyChanged(nameof(GivenDate));
            }
        }


        private DateTime _effectiveDate = DateTime.MinValue;
        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set
            {
                _effectiveDate = value;
                OnPropertyChanged(nameof(EffectiveDate));
            }
        }


        private ObservableCollection<CurrencyModel> _currenciesCode;
        public ObservableCollection<CurrencyModel> CurrenciesCode
        {
            get => _currenciesCode;
            set 
            { 
                _currenciesCode = value;
                OnPropertyChanged(nameof(CurrenciesCode));
            }
        }


        private ObservableCollection<DateTime> _coolectionOfSavedDates; 
        public ObservableCollection<DateTime> CoolectionOfSavedDates
        {
            get { return _coolectionOfSavedDates; }
            set 
            {
                _coolectionOfSavedDates = value;  
                OnPropertyChanged(nameof(ListOfSavedDates));
            }
        }

        private List<DateTime> _listOfSavedDates;
        public List<DateTime> ListOfSavedDates
        {
            get { return _listOfSavedDates; }
            set
            {
                _listOfSavedDates = value;
                OnPropertyChanged(nameof(ListOfSavedDates));
            }
        }


        private string _dateToLoad;
        public string DateToLoad
        {
            get { return _dateToLoad; }
            set 
            { 
                _dateToLoad = value;
                OnPropertyChanged(nameof(DateToLoad));
            }
        }


        private CurrencyModel _selectedCurrencyConvertFrom;
        public CurrencyModel SelectedCurrencyConvertFrom
        {
            get => _selectedCurrencyConvertFrom;
            set
            {
                _selectedCurrencyConvertFrom = value;
                OnPropertyChanged(nameof(SelectedCurrencyConvertFrom));
                if(GivenValueByUser != null && GivenValueByUser != string.Empty && !CallucationAlreadMade)
                    GetCalculattion(nameof(GivenValueByUser));
            }
        }


        private CurrencyModel _selectedCurrencyConvertTo;
        public CurrencyModel SelectedCurrencyConvertTo
        {
            get => _selectedCurrencyConvertTo;
            set
            {
                _selectedCurrencyConvertTo = value;
                OnPropertyChanged(nameof(SelectedCurrencyConvertTo));
                if (DisplayResult != null && DisplayResult != string.Empty && !CallucationAlreadMade)
                    GetCalculattion(nameof(DisplayResult));
            }
        }


        public ICommand SelectCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand LoadOnStartCommand { get; }


        private readonly CallCalculattionService _call = new();
        private readonly CurrencyModelStore _currencyModelStore;

        public CalculatorViewModel(CurrencyModelStore currencyModelStore)
        {
            _currencyModelStore = currencyModelStore;

            CurrenciesCode = new ObservableCollection<CurrencyModel>();
            CoolectionOfSavedDates = new ObservableCollection<DateTime>();
            ListOfSavedDates = new List<DateTime>();
            LoadOnStartCommand = new CalculatorLoadOnStartCommand(this,_currencyModelStore);

            
            _currencyModelStore.CurrecnyModelSaved += OnCurrencySaved;

            LoadOnStartCommand.Execute(null);
            CallApiService.CallApi(this);

            SelectCommand = new CalculatorSelectCommand(this);
            SaveCommand = new CalculatorSaveCommand(this, _currencyModelStore);
            LoadCommand = new CalculatorLoadCommand(this, _currencyModelStore);
        }

        public override void Dispose()
        {

            _currencyModelStore.CurrecnyModelSaved -= OnCurrencySaved;
            base.Dispose();
        }

        private void OnCurrencySaved(CalculatorViewModel obj)
        {
            if (EffectiveDate != DateTime.MinValue)
            {
                ListOfSavedDates.Add(EffectiveDate);
            }          
            ListOfSavedDates.Sort((x, y) => y.CompareTo(x));

            CoolectionOfSavedDates.Clear();
            foreach(var item in ListOfSavedDates)
            {
                CoolectionOfSavedDates.Add(item);
            }
        }

        private void GetCalculattion(string propertName)
        {
            CallucationAlreadMade = true;
            if (nameof(GivenValueByUser).Equals(propertName))
            {
                _call.CallCalculattionForFirstInput(this);                
            }
            else
            {               
                _call.CallCalculattionForSecondInput(this);
            }
            CallucationAlreadMade = false;
        }
    }
}

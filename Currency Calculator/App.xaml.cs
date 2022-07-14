using Currency_Calculator.Domain.Commands;
using Currency_Calculator.Domain.Models;
using Currency_Calculator.Domain.Queries;
using Currency_Calculator.EntityFramework;
using Currency_Calculator.EntityFramework.Commands;
using Currency_Calculator.EntityFramework.Queries;
using Currency_Calculator.Stores;
using Currency_Calculator.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private  ISaveCurrencyCommand _saveCurrencyCommand;
        private  IGetAllCurrienciesQuery _getAllCurrienciesQuery;
        private  CurrencyDbContextFactory _currencyDbContextFactory;

        private Dictionary<DateTime, List<CurrencyModel>> store;
        private CurrencyModelStore _currencyModelStore;

        protected override void OnStartup(StartupEventArgs e)
        {
            string connectionString = "Data Source=Currency.db";
            _currencyDbContextFactory = new CurrencyDbContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            store = new();
            _saveCurrencyCommand = new SaveCurrencyCommand(_currencyDbContextFactory);
            _getAllCurrienciesQuery = new GetAllCurrienciesQuery(_currencyDbContextFactory);

            _currencyModelStore = new(store, _saveCurrencyCommand, _getAllCurrienciesQuery);

            using(CurrencyDbContext context = _currencyDbContextFactory.Create())
            {
                context.Database.Migrate();
            }


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_currencyModelStore)
            };
            MainWindow.Show();    

            base.OnStartup(e);
        }

    }
}

//first date for table A : 2002-01-02 (data are available from monday to friday, there may be problems on holidays in these days)
//first date for table B : 2006-02-01 (data are available only on wednesday, there may be problems on holidays on wednesday)
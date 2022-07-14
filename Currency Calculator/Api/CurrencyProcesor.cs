using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Currency_Calculator.Services;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Currency_Calculator.ViewModels;

namespace Currency_Calculator.Api
{
    public class CurrencyProcesor
    {

        public static async Task<CurrencyRatesJsonModel> LoadCurrencyInformation(CalculatorViewModel calculatorViewModel)
        {
            string url;

            if (calculatorViewModel.GivenDate == DateTime.Today)
            {
                url = "http://api.nbp.pl/api/exchangerates/tables/a?format=json";
            }
            else
            {
                string date = DateToStringService.DateToString(calculatorViewModel.GivenDate);
                url = $"http://api.nbp.pl/api/exchangerates/tables/a/{date}?format=json";  
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    CurrencyRatesJsonModel currency = JsonConvert.DeserializeObject<CurrencyRatesJsonModel>(result.Substring(1,result.Length-2));

                    return currency;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }
    }
}

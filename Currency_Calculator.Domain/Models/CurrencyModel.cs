using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Domain.Models
{
    public class CurrencyModel
    {
        public string Name { get; }
        public string Code { get; }
        public double ExchangeRate { get;}

        public CurrencyModel(string Name, string Code, double ExchangeRate)
        {
            this.Name = Name;
            this.Code = Code;
            this.ExchangeRate = ExchangeRate;
        }
    }
}

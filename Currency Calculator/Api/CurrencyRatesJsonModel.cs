using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Api
{
    public class CurrencyRatesJsonModel
    {
        public List<CurrencyJsonModel> Rates { get; set; }

        public string EffectiveDate { get; set; }
    }
}

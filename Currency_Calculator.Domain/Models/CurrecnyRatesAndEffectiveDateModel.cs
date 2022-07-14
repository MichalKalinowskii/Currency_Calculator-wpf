using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Domain.Models
{
    public class CurrecnyRatesAndEffectiveDateModel
    {
        public DateTime EffectiveDate { get; }
        public List<CurrencyModel> Rates { get; }

        public CurrecnyRatesAndEffectiveDateModel(DateTime effectiveDate, List<CurrencyModel> rates)
        {
            EffectiveDate = effectiveDate;
            Rates = rates;
        }
    }
}

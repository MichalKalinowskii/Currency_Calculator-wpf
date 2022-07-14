using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Api
{
    public class CurrencyJsonModel
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework.DTOs
{
    public class CurrencyRatesAndEffectiveDateDto
    {
        public Guid Id { get; set;  }
        public DateTime EffectiveDate { get; set; }
        public List<CurrencyDto> Rates 
        {
            get; set;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework.DTOs
{
    public class CurrencyDto
    {   
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Code { get; set; }
        public double ExchangeRate { get; set; }       
        public Guid CurrencyRatesAndEffectiveDateDtoId { get; set; }


    }
}

using Currency_Calculator.Domain.Commands;
using Currency_Calculator.Domain.Models;
using Currency_Calculator.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework.Commands
{
    public class SaveCurrencyCommand : ISaveCurrencyCommand
    {
        private readonly CurrencyDbContextFactory _contextFactory;

        public SaveCurrencyCommand(CurrencyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(CurrecnyRatesAndEffectiveDateModel currecnyRatesAndEffectiveDateModel)
        {
            using (CurrencyDbContext context = _contextFactory.Create())
            {
                List<CurrencyDto> list = new();
                foreach (var rates in currecnyRatesAndEffectiveDateModel.Rates)
                {
                    list.Add(new CurrencyDto()
                    {
                        Name = rates.Name,
                        Code = rates.Code,
                        ExchangeRate = rates.ExchangeRate,
                        Id = new Guid()
                    });
                }
                CurrencyRatesAndEffectiveDateDto currency = new()
                {
                    Id=new Guid(),
                    EffectiveDate= currecnyRatesAndEffectiveDateModel.EffectiveDate,
                    Rates = list 
                };
                context.CurrencyRatesAndEffectiveDate.Add(currency);
                
                
                await context.SaveChangesAsync();
            }
        }
    }
}

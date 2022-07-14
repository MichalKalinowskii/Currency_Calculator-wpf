using Currency_Calculator.Domain.Models;
using Currency_Calculator.Domain.Queries;
using Currency_Calculator.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework.Queries
{
    public class GetAllCurrienciesQuery : IGetAllCurrienciesQuery
    {
        private readonly CurrencyDbContextFactory _contextFactory;
        public GetAllCurrienciesQuery(CurrencyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<CurrecnyRatesAndEffectiveDateModel>> Execute()
        {
            using (CurrencyDbContext context = _contextFactory.Create())
            {
                List<CurrencyRatesAndEffectiveDateDto> currecnyRatesAndEffectiveDateDto = await context.CurrencyRatesAndEffectiveDate.ToListAsync();
               
                List<CurrecnyRatesAndEffectiveDateModel> listOfRatesAndEffectiveDates= new();
                foreach (var item in currecnyRatesAndEffectiveDateDto)
                {
                    IEnumerable<CurrencyDto> currencyDto = await context.CurrencyDto.Where(x => x.CurrencyRatesAndEffectiveDateDtoId.Equals(item.Id)).ToListAsync();
                    List<CurrencyModel> list = new();
                    foreach (var rates in currencyDto)
                    {
                        list.Add(new CurrencyModel(rates.Name, rates.Code, rates.ExchangeRate));
                    }
                    listOfRatesAndEffectiveDates.Add(new CurrecnyRatesAndEffectiveDateModel(item.EffectiveDate,list));
                }
                return listOfRatesAndEffectiveDates;
            }
        }
    }
}

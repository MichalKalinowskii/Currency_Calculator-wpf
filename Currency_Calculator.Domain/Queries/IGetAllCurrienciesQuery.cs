using Currency_Calculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Domain.Queries
{
    public interface IGetAllCurrienciesQuery
    {
        Task<List<CurrecnyRatesAndEffectiveDateModel>> Execute();
    }
}

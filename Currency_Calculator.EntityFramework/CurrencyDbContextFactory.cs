using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework
{
    public class CurrencyDbContextFactory
    {
        private readonly DbContextOptions _options;
        public CurrencyDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public CurrencyDbContext Create()
        {
            return new CurrencyDbContext(_options);
        }
    }
}

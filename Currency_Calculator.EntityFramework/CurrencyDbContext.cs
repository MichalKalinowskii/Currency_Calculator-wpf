using Currency_Calculator.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.EntityFramework
{
    public class CurrencyDbContext : DbContext 
    {
        public CurrencyDbContext(DbContextOptions options) : base(options) {}
        
        public DbSet<CurrencyRatesAndEffectiveDateDto> CurrencyRatesAndEffectiveDate { get; set; }
        public DbSet<CurrencyDto> CurrencyDto { get; set; }
       
    }
}

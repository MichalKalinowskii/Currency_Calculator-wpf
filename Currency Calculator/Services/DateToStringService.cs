using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.Services
{
    public class DateToStringService
    {
        public static string DateToString(DateTime? givenDate)
        {
            string date= givenDate?.ToString("yyyy-MM-dd");
            return date;
        }
    }
}

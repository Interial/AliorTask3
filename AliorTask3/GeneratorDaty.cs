using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliorTask3
{
    class GeneratorDaty
    {
        //Generator Daty daje nam Rok , Miesiąc i Dzień
        public static DateTime RandomDay()
        {
            Random generateDate = new Random();
            DateTime start = new DateTime(1900, 1, 1);
            DateTime end = new DateTime(1999, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(generateDate.Next(range));

        }
    }
}

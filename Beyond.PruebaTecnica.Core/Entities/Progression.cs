using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.PruebaTecnica.Core.Entities
{
    public class Progression
    {
        public DateTime Date { get; set; }
        public decimal Percent { get; set; }

        public Progression(DateTime date, decimal percent)
        {
            Date = date;
            Percent = percent;
        }
    }
}

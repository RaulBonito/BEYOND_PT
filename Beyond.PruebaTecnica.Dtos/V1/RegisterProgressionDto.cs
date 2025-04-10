using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.PruebaTecnica.Dtos.V1
{
    public class RegisterProgressionDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Percent { get; set; }
    }
}

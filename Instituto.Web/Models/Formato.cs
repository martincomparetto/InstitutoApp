using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Models
{
    public abstract class Formato
    {
        public Guid Id { get; set; }
        public string Denominacion { get; set; }
        public DateTime FechaPublicacion { get; set; }

    }
}

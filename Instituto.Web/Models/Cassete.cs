using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Models
{
    public class Cassete : Formato
    {
        public double Duracion { get; set; }
    }
}

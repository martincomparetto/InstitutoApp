using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Models
{
    public class Vinilo : Formato
    {
        public string Tamanio { get; set; }
    }
}

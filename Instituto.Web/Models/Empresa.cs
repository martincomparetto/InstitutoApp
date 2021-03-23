using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Models
{
    [Index(nameof(CUIT), IsUnique = true, Name = "IX_CUIT")]
    public class Empresa
    {
        [Key]
        public int ID { get; set; }

        public string RazonSocial { get; set; }

        public string CUIT { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Models
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<IdentityRole> AccessRoles { get; set; }
    }
}

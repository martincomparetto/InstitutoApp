using Instituto.Web.Data;
using Instituto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.Web.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public EmpresaController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> Guardar(string razonSocial, string cuit)
        {
            Empresa newEmpresa = new Empresa()
            {
                RazonSocial = razonSocial,
                CUIT = cuit
            };
            newEmpresa.UsuarioId = _userManager.GetUserId(HttpContext.User);
            //newEmpresa.Usuario = await _userManager.GetUserAsync(HttpContext.User);

            _context.Empresas.Add(newEmpresa);
            await _context.SaveChangesAsync();

            return "OK";
        }

        public async Task<List<EmpresaResponse>> GetEmpresas()
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<Empresa> empresasOld = _context.Empresas
                .Include(x => x.Usuario)
                .Where(u => u.UsuarioId == usuarioId).ToList();

            List<EmpresaResponse> empresas = (from e in _context.Empresas
                                              join u in _context.Users on e.UsuarioId equals u.Id
                                              join ur in _context.UserRoles on u.Id equals ur.UserId
                                              join r in _context.Roles on ur.RoleId equals r.Id
                                              where e.UsuarioId == usuarioId
                                              select new EmpresaResponse()
                                              {
                                                  ID = e.ID,
                                                  RazonSocial = e.RazonSocial,
                                                  CUIT = e.CUIT,
                                                  UserName = u.UserName,
                                                  Email = u.Email,
                                                  PhoneNumber = u.PhoneNumber,
                                                  UserRole = r.Name
                                              }).ToList();

            //List<EmpresaResponse> empresas = new List<EmpresaResponse>();
            //List<Empresa> emp = _context.Empresas
            //    .Include(x => x.Usuario)
            //    .Where(u => u.UsuarioId == usuarioId).ToList();


            //foreach (var item in emp)
            //{
            //    empresas.Add(new EmpresaResponse()
            //    {
            //        ID = item.ID,
            //        RazonSocial = item.RazonSocial,
            //        CUIT = item.CUIT,
            //        UserName = item.Usuario.UserName,
            //        Email = item.Usuario.Email,
            //        PhoneNumber = item.Usuario.PhoneNumber
            //    });
            //}

            return empresas;
        }

        public async Task<List<CountEmpresaUsuarioResponse>> CountEmpresasPorUsuario()
        {
            List<CountEmpresaUsuarioResponse> count = (from e in _context.Empresas
                                                       join u in _context.Users on e.UsuarioId equals u.Id
                                                       group new { e, u } by new { e.UsuarioId, u.UserName } into userGroup
                                                       select new CountEmpresaUsuarioResponse()
                                                       {
                                                           Usuario = userGroup.Key.UserName,
                                                           Cantidad = userGroup.Count()
                                                       }
                                                       ).ToList();

            return count;
        }
    }

    public class EmpresaResponse
    {
        public int ID { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; }
    }

    public class CountEmpresaUsuarioResponse
    {
        public string Usuario { get; set; }
        public int Cantidad { get; set; }
    }
}

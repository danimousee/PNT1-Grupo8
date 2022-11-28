using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurneroMVC.Context;
using TurneroMVC.Models;

namespace TurneroMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurneroDatabaseContext _context;

        public LoginController(TurneroDatabaseContext context)
        {  
            _context = context;
        }

        public IActionResult Index()
        {
            //Recuperar valor de la variable de sesión
            string nomusuario = HttpContext.Session.GetString("Usuario");
            return View(model: nomusuario);
        }

        public async Task<IActionResult> Login(string usuario, string contra)
        {
            //Validar usuario y contraseña contra la tabla correspondiente en la BD
            //Si está OK, asignar el valor a la variable de sesion
            var cuentaPorEmail = await _context.Cuentas.FirstOrDefaultAsync(c => c.Email == usuario && c.Contrasenia == contra);

            //Usuario correcto
            if(cuentaPorEmail != null)
            {
                HttpContext.Session.SetString("NombreCompleto", cuentaPorEmail.NombreCompleto);
                HttpContext.Session.SetString("CuentaId", cuentaPorEmail.Id.ToString());
                HttpContext.Session.SetString("Rol", cuentaPorEmail.Rol.ToString());
                return RedirectToAction("Index", "Home");
            }
            //Usuario incorrecto
            else
            {
                ViewData["ErrorMessage"] = "Usuario o contraseña incorrecta. Reintente por favor.";
                return View("Index");

            }
        }
    }
}
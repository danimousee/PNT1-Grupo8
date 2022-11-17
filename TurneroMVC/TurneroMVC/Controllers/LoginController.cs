using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurneroMVC.Models;

namespace TurneroMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //Recuperar valor de la variable de sesión
            string nomusuario = HttpContext.Session.GetString("Usuario"); //o Session["Usuario"]
            return View(model: nomusuario);
        }

        public IActionResult Login(string usuario, string contra)
        {
            //Validar usuario y contraseña contra la tabla correspondiente en la BD
            //Si está OK, asignar el valor a la variable de sesion
            int cuentaId = 0;


            HttpContext.Session.SetString("Usuario", cuentaId.ToString()); 
            //Session["Usuario"] = cuentaId;
            return RedirectToAction("Index");
        }
    }
}
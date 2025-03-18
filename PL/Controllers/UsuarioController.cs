using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Formulario(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            if (IdUsuario != null)
            {
                result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
            }

            return View(usuario);
        }
        [HttpPost]
        public ActionResult Formulario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            if (usuario.IdUsuario > 0)
            {
                result = BL.Usuario.Update(usuario);
            }
            else
            {
                result = BL.Usuario.Add(usuario);
            }

            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            if (IdUsuario > 0)
            {
                result = BL.Usuario.Delete(IdUsuario);
            }
            return RedirectToAction("GetAll");
        }
    }
}
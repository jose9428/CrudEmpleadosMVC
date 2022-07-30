using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.DAO;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private EmpleadoDAO empDAO = new EmpleadoDAO();

        public ActionResult Index()
        {
            List<Empleado> lista = empDAO.ListarTodos();
            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View(new Empleado());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(Empleado obj)
        {
            if (ModelState.IsValid)
            {
                string msg = empDAO.Agregar(obj);

                if (msg == "OK")
                {
                    TempData["mensaje"] = "Los datos se guardaron de forma correcta.";
                    return RedirectToAction("Index");
                }
                TempData["mensaje"] = msg;
            }

            return View(obj);
        }

        public ActionResult Editar(int? id)
        {
            Empleado obj = empDAO.Buscar(id == null ? 0: id.Value);

            if (obj !=null)
            {
                return View(obj);
            }
            else
            {
                TempData["mensaje"] = "No se encontro empleado con el id "+id;

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Empleado obj)
        {
            if (ModelState.IsValid)
            {
                string msg = empDAO.Editar(obj);

                if (msg == "OK")
                {
                    TempData["mensaje"] = "Los datos se editaron de forma correcta.";
                    return RedirectToAction("Index");
                }
                TempData["mensaje"] = msg;
            }

            return View(obj);
        }

        public ActionResult Eliminar(int id)
        {
            string msg = empDAO.Eliminar(id);

            if (msg == "OK")
            {
                TempData["mensaje"] = "Los datos del empleado se eliminaron de forma correcta.";
            }
            else
            {
                TempData["mensaje"] = msg;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Consultar()
        {
            return View(new Empleado());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class FornadasController : Controller
    {
        private ApplicationDbContext _context;

        public FornadasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Fornadas
        public ActionResult Index()
        {
            if (User.IsInRole("GerenciaFornadas"))
            {
                var ultimaFornada = _context.Fornadas.OrderByDescending(f => f.Id).First();

                var viewModel = new FornadaIndexViewModel
                {
                    Id = ultimaFornada.Id,
                    Descricao = ultimaFornada.Descricao,
                    Hora = ultimaFornada.DataHora.TimeOfDay.ToString()
                };

                return View("Lista", viewModel);
            }

            return View("Index");
        }

        // GET: Fornadas/Nova
        [Authorize(Roles = "GerenciaFornadas")]
        public ActionResult Nova()
        {
            var viewModel = new FornadaFormViewModel();

            return View("FornadaForm", viewModel);
        }

        // GET: Fornadas/Editar/{id}
        [Authorize(Roles = "GerenciaFornadas")]
        public ActionResult Editar(int id)
        {
            var fornada = _context.Fornadas.SingleOrDefault(f => f.Id == id);

            if (fornada == null)
                return HttpNotFound();
            
            var viewModel = new FornadaFormViewModel(fornada);

            return View("FornadaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "GerenciaFornadas")]
        public ActionResult Save(FornadaFormViewModel fornadaVm)
        {
            if (!@ModelState.IsValid)
            {
                return View("FornadaForm", fornadaVm);
            }


            if (fornadaVm.Id == 0)
            {
                var fornada = new Fornada
                {
                    Descricao = fornadaVm.Descricao,
                    DataHora =
                        new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                        fornadaVm.Hora, fornadaVm.Minuto, 0)
                };

                _context.Fornadas.Add(fornada);
            }
            else
            {
                var fornadaInDb = _context.Fornadas.Single(f => f.Id == fornadaVm.Id);

                fornadaInDb.Descricao = fornadaVm.Descricao;
                fornadaInDb.DataHora = new DateTime
                    (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    fornadaVm.Hora, fornadaVm.Minuto, 0);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Fornadas");
        }

        [Authorize(Roles = "GerenciaFornadas")]
        public ActionResult Delete(int id)
        {
            var fornada = _context.Fornadas.SingleOrDefault(f => f.Id == id);

            if (fornada == null)
                return HttpNotFound();

            _context.Fornadas.Remove(fornada);
            _context.SaveChanges();

            return View("Removido");
        }
    }
}
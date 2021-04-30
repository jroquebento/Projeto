using Projeto.Models;
using Projeto.Repositorio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class SaidaController : Controller
    {
        private RepositorioSaida repositorioSaida = new RepositorioSaida();
        private RepositorioLoja repositorioLoja = new RepositorioLoja();
        private RepositorioTransportadora repositorioTransportadora = new RepositorioTransportadora();
        public ActionResult Index() 
        {
            List<Saida> listaSaida = repositorioSaida.FindAll();
            return View(listaSaida);
        }

        [HttpGet]
        public ActionResult Insert() 
        {
            Saida saida = new Saida();
            saida.ListaLoja = repositorioLoja.FindAll();
            saida.ListaTransportadora = repositorioTransportadora.FindAll();
            return View(saida);
        }

        [HttpPost]
        public ActionResult Insert(Saida saida)
        {
            if (ModelState.IsValid) 
            {
                repositorioSaida.Insert(saida);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            Saida saida = repositorioSaida.FindById(id);
            saida.ListaLoja = repositorioLoja.FindAll();
            saida.ListaTransportadora = repositorioTransportadora.FindAll();
            return View(saida);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Saida saida) 
        {
            if (ModelState.IsValid) 
            {
                repositorioSaida.Update(id, saida);
            }

            return RedirectToAction("Index");
        }
    }
}

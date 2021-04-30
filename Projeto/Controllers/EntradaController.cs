using Projeto.Models;
using Projeto.Repositorio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class EntradaController: Controller
    {
        private RepositorioEntrada repositorioEntrada = new RepositorioEntrada();

        private RepositorioTransportadora repositorioTransportadora = new RepositorioTransportadora();
        public ActionResult Index()
        {
            List<Entrada> lista = repositorioEntrada.FindAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Insert() 
        {
            Entrada entrada = new Entrada();            
            entrada.ListaTransportadora = repositorioTransportadora.FindAll();
            return View(entrada);
        }

        [HttpPost]
        public ActionResult Insert(Entrada entrada)
        {
            if (ModelState.IsValid) 
            {
                repositorioEntrada.Insert(entrada);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            Entrada entrada = repositorioEntrada.FindById(id);
            entrada.ListaTransportadora = repositorioTransportadora.FindAll();
            return View(entrada);
        }

        [HttpPost] 
        public ActionResult Edit(int? id, Entrada entrada) 
        {
            if (ModelState.IsValid) 
            {
                repositorioEntrada.Update(id,entrada);
            }
            return RedirectToAction("Index");
        }
    }
}

using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class TransportadoraController : Controller
    {
        private RepositorioTransportadora repositorioTransportadora = new RepositorioTransportadora();

        private RepositorioCidade repositorioCidade = new RepositorioCidade();
        
        [HttpGet]
        public ActionResult Index() 
        {
            BuscarTransportadoraViewModel buscar = new BuscarTransportadoraViewModel();
            buscar.ListaTransportadoras = repositorioTransportadora.FindAll();           
            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarTransportadoraViewModel transportadora)
        {
            transportadora.ListaTransportadoras = repositorioTransportadora.FindByNome(transportadora.Nome);
            return View(transportadora);
        }

        [HttpGet]
        public ActionResult ListaTransportadoras() 
        {
            return View(repositorioTransportadora.FindAll());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            Transportadora transportadora = new Transportadora();
            transportadora.ListaCidade = repositorioCidade.FindAll();
            return View(transportadora);
        }

        [HttpPost]
        public ActionResult Insert(Transportadora transportadora) 
        {
            if (ModelState.IsValid) 
            {
                repositorioTransportadora.Insert(transportadora);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            Transportadora transportadora = repositorioTransportadora.FindById(id);
            transportadora.ListaCidade = repositorioCidade.FindAll();
            return View(transportadora);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Transportadora transportadora)
        {
            if (ModelState.IsValid) 
            {
                repositorioTransportadora.Update(id, transportadora);
            }

            return RedirectToAction("Index");
        }

    }
}

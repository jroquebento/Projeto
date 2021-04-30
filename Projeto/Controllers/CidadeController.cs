using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class CidadeController : Controller
    {
        private RepositorioCidade repositorioCidade = new RepositorioCidade();
        
        [HttpGet]
        public ActionResult Index() 
        {
            BuscarCidadeViewModel buscar = new BuscarCidadeViewModel();
            buscar.ListaCidades = repositorioCidade.FindAll();

            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarCidadeViewModel cidade)
        {
            cidade.ListaCidades = repositorioCidade.FindByNome(cidade.Nome);

            return View(cidade);
        }

        [HttpGet]
        public ActionResult ListaCidades()
        {
            return View(repositorioCidade.FindAll());
        }

        [HttpGet]
        public ActionResult Insert() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Cidade cidade)
        {
            if (ModelState.IsValid) 
            {
                repositorioCidade.Insert(cidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View(repositorioCidade.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(int? id, Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                repositorioCidade.Update(id,cidade);
            }
            return RedirectToAction("Index");
        }
    }
}

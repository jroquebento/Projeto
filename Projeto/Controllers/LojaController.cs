using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class LojaController : Controller
    {
        private RepositorioLoja repositorioLoja = new RepositorioLoja();
        private RepositorioCidade repositorioCidade = new RepositorioCidade();

        [HttpGet]
        public ActionResult Index() 
        {
            BuscarLojaViewModel buscar = new BuscarLojaViewModel();
            buscar.ListaLojas = repositorioLoja.FindAll();
              
            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarLojaViewModel loja)
        {
            loja.ListaLojas = repositorioLoja.FindByNome(loja.Nome);

            return View(loja);
        }

        [HttpGet]
        public ActionResult ListaLojas()
        {
            return View(repositorioCidade.FindAll());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            Loja loja = new Loja();
            loja.ListaCidade = repositorioCidade.FindAll();
            return View(loja);
        }

        [HttpPost]
        public ActionResult Insert(Loja loja)
        {
            if (ModelState.IsValid) 
            {                
                repositorioLoja.Insert(loja);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Loja loja = repositorioLoja.FindById(id);
            loja.ListaCidade = repositorioCidade.FindAll();
            return View(loja);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Loja loja) 
        {
            if (ModelState.IsValid) 
            {
                repositorioLoja.Update(id, loja);
            }

            return RedirectToAction("Index");
        }

    }
}

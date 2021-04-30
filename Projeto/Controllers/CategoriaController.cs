using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class CategoriaController : Controller
    {
        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        [HttpGet]
        public ActionResult Index()
        {
            BuscarCategoriaViewModel buscar = new BuscarCategoriaViewModel();
            buscar.ListaCategorias = repositorioCategoria.FindAll();

            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarCategoriaViewModel categoria)
        {
            categoria.ListaCategorias = repositorioCategoria.FindByNome(categoria.Nome);

            return View(categoria);
        }


        [HttpGet]
        public ActionResult ListaCategorias()
        {   
            return View(repositorioCategoria.FindAll());
        }

        [HttpGet]
        public ActionResult Insert() {          
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                repositorioCategoria.Insert(categoria);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
           
            return View(repositorioCategoria.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(int? id,Categoria categoria)
        {
            if (ModelState.IsValid) 
            {
                repositorioCategoria.Update(id,categoria);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FindByNome() {

            return View();
        }

        [HttpPost]
        public ActionResult FindByNome(string nome) 
        {
            return View();
        }
    }
}

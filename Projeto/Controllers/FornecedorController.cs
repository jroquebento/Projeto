using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class FornecedorController : Controller
    {
        private RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();

        private RepositorioCidade repositorioCidade = new RepositorioCidade();
        
        [HttpGet]
        public ActionResult Index() 
        {
            BuscarFornecedorViewModel buscar = new BuscarFornecedorViewModel();
            buscar.ListaFornecedores = repositorioFornecedor.FindAll();
            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarFornecedorViewModel fornecedor)
        {
            fornecedor.ListaFornecedores = repositorioFornecedor.FindByNome(fornecedor.Nome);
            return View(fornecedor);
        }

        [HttpGet]
        public ActionResult ListaFornecedores() 
        {
            return View(repositorioFornecedor.FindAll());
        }

        [HttpGet]
        public ActionResult Insert() 
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ListaCidade = repositorioCidade.FindAll();
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Insert(Fornecedor fornecedor)
        {
            if (ModelState.IsValid) 
            {
                repositorioFornecedor.Insert(fornecedor);               
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Fornecedor fornecedor = repositorioFornecedor.FindById(id);
            fornecedor.ListaCidade = repositorioCidade.FindAll();
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Fornecedor fornecedor)
        {
            if (ModelState.IsValid) 
            {
                repositorioFornecedor.Update(id, fornecedor);
            }
            return RedirectToAction("Index");
        }
    }
}

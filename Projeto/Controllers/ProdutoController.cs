using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class ProdutoController : Controller
    {
        private RepositorioProduto repositorioProduto = new RepositorioProduto();

        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        private RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
       
        [HttpGet]
        public ActionResult Index()
        {
            BuscarProdutoViewModel buscar = new BuscarProdutoViewModel();
            buscar.ListaProdutos = repositorioProduto.FindAll(); 
            return View(buscar);
        }

        [HttpPost]
        public ActionResult Index(BuscarProdutoViewModel produto)
        {
            produto.ListaProdutos = repositorioProduto.FindByDescricao(produto.Descricao);
            return View(produto);
        }

        [HttpGet]
        public ActionResult ListaProdutos() 
        {
            return View(repositorioProduto.FindAll());
        }


        [HttpGet]
        public ActionResult Insert()
        {
            Produto produto = new Produto();
            produto.ListaCategoria = repositorioCategoria.FindAll();
            produto.ListaFornecedor = repositorioFornecedor.FindAll();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Insert(Produto produto)
        {
            if (ModelState.IsValid)
            {
                repositorioProduto.Insert(produto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Produto produto = repositorioProduto.FindById(id);
            produto.ListaCategoria = repositorioCategoria.FindAll();
            produto.ListaFornecedor = repositorioFornecedor.FindAll();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Produto produto)
        {
            if (ModelState.IsValid) 
            {
                repositorioProduto.Update(id,produto);
            }
            return RedirectToAction("Index");
        }
    }
}

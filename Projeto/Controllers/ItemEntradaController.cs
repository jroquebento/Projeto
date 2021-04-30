using Projeto.Models;
using Projeto.Repositorio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class ItemEntradaController : Controller
    {
        private RepositorioItemEntrada repositorioItemEntrada = new RepositorioItemEntrada();
        private RepositorioProduto repositorioProduto = new RepositorioProduto();
        private RepositorioEntrada repositorioEntrada = new RepositorioEntrada();

        public ActionResult Index() 
        {
            List<ItemEntrada> itemEntrada = repositorioItemEntrada.FindAll();
            return View(itemEntrada);
        }

        [HttpGet]
        public ActionResult Insert() 
        {
            ItemEntrada itemEntrada = new ItemEntrada();
            itemEntrada.ListaProduto = repositorioProduto.FindAll();
            itemEntrada.ListaEntrada = repositorioEntrada.FindAll();
            return View(itemEntrada);
        }

        [HttpPost]
        public ActionResult Insert(ItemEntrada itemEntrada) 
        {
            if (ModelState.IsValid) 
            {
                repositorioItemEntrada.Insert(itemEntrada);
            }
            return RedirectToAction("Index");
        }
    }
}

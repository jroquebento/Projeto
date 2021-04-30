using Projeto.Models;
using Projeto.Repositorio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class ItemSaidaController : Controller
    {
        private RepositorioItemSaida repositorioItemSaida = new RepositorioItemSaida();

        private RepositorioSaida repositorioSaida = new RepositorioSaida();

        private RepositorioProduto repositorioProduto = new RepositorioProduto();

        public ActionResult Index() 
        {
            List<ItemSaida> itemSaida = repositorioItemSaida.FindAll();
            return View(itemSaida);
        }


        [HttpGet]
        public ActionResult Insert() 
        {
            ItemSaida itemSaida = new ItemSaida();
            itemSaida.ListaSaida = repositorioSaida.FindAll();
            itemSaida.ListaProduto = repositorioProduto.FindAll();    
            return View(itemSaida);
        }

        [HttpPost]
        public ActionResult Insert(ItemSaida itemSaida) 
        {
            if (ModelState.IsValid)
            {
                repositorioItemSaida.Insert(itemSaida);
            }
            return RedirectToAction("Index");
        }
    }
}

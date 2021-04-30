using Projeto.Models;
using Projeto.Repositorio;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // INSERT

            //RepositorioCategoria incluir = new RepositorioCategoria();            
            //incluir.Insert(new Categoria { Nome = "Limpeza" });
            //RepositorioCidade cidade = new RepositorioCidade();
            //cidade.Insert(new Cidade  { Nome = "Santo André", Uf = "SP" });  

            /*RepositorioFornecedor fornecedor = new RepositorioFornecedor();
            fornecedor.Insert(new Fornecedor
            {                
                Nome = "Americanas",
                Endereco = "Rua Oliveira",
                Num = 204,
                Bairro = "Jardim",
                Cep = "09591800",
                Contato = "americanas@gmail.com",
                Cnpj = "565762548555560",
                Insc = "96637415289",
                Tel = "1129450754",
                Cidade = new Models.Cidade
                {
                    CodCidade = 1
                }
            });*/

            /*RepositorioProduto produto = new RepositorioProduto();
            produto.Insert(new Produto { 
                Categoria = new Categoria { CodCategoria = 1 },
                Fornecedor = new Fornecedor { CodFornecedor = 1},
                Descricao = "Pasta de Dente",
                Peso = 3,
                Controlado = true,
                QtdeMin = 50
            });*/

            /*RepositorioLoja loja = new RepositorioLoja();
            loja.Insert(new Loja
            {               
                Cidade = new Cidade
                {
                    CodCidade = 1
                },
                Nome = "Magazine Luiza",
                Endereco = "Rua dos Alváres",
                Num = 340,
                Bairro = "Baeta Neves",
                Tel = "1173518572",
                Insc = "66837573542",
                Cnpj = "347364560458786"  
            });*/

            /*RepositorioTransportadora transportadora = new RepositorioTransportadora();
            transportadora.Insert(new Transportadora
            {
                Cidade = new Cidade
                {
                    CodCidade = 1
                },
                Nome = "Mercado Livre",
                Endereco = "Rua Dom Pedro",
                Num = 102,
                Bairro = "Saúde",
                Cep = "09286644",
                Cnpj = "864583475603647",
                Insc = "72354657683",
                Contato = "mercadolivre@gmail.com",           
                Tel = "1185751273", 
            });*/

            /* RepositorioEntrada incluir = new RepositorioEntrada();
            incluir.Insert(new Entrada
            {
                Transportadora = new Transportadora { CodTransportadora = 1 },
                DataPed = DateTime.ParseExact("02-04-2000", "dd-MM-yyyy",CultureInfo.InvariantCulture),
                DataEntr = DateTime.ParseExact("05-04-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                Total = 200.0m,
                Frete = 20.0m,
                NumNf = 23,
                Imposto = 0
            });*/

            /*RepositorioItemEntrada repositorioItemEntrada = new RepositorioItemEntrada();
            repositorioItemEntrada.Insert(new ItemEntrada
            {
                Produto = new Produto { CodProduto = 1 },
                Entrada = new Entrada { CodEntrada = 1 },
                Lote = "520b",
                Qtde = 1,
                Valor = 200
            });*/

            /*RepositorioSaida repositorioSaida = new RepositorioSaida();
            repositorioSaida.Insert(new Saida { 
                Loja = new Loja { CodLoja = 1 },
                Trasportadora = new Transportadora { CodTransportadora = 1 },
                Total = 100,
                Frete = 20,
                Imposto = 2
            });*/

            /*RepositorioItemSaida repositorioItemSaida = new RepositorioItemSaida();
            repositorioItemSaida.Insert(new ItemSaida { 
                Saida = new Saida { CodSaida = 2 },
                Produto = new Produto { CodProduto = 1},
                Lote = "520b",
                Qtde = 2,
                Valor = 300
           });*/

            // UPDATE

            //RepositorioCategoria update = new RepositorioCategoria();
            //update.Update(new Categoria { CodCategoria = 2, Nome = "Bebidas" });
            //RepositorioCidade update = new RepositorioCidade();
            //update.Update(new Cidade { CodCidade = 3, Nome = "Belo Horizonte", Uf = "MG" });

            /*RepositorioLoja repositorioLoja = new RepositorioLoja();
            repositorioLoja.Update(new Loja { 
                CodLoja = 1,
                Cidade = new Cidade {CodCidade = 1 },
                Nome = "Casas Bahia",
                Endereco = "Rua dos Limoeiros",
                Num = 800,
                Bairro = "Vila Nova",
                Tel = "1185215773",
                Insc = "35457372686",
                Cnpj = "607863457364458"
            });*/

            /*RepositorioTransportadora transportadora = new RepositorioTransportadora();
            transportadora.Update(new Transportadora
            {
                CodTransportadora = 1,
                Cidade = new Cidade
                {
                    CodCidade = 1
                },
                Nome = "BeatU37",
                Endereco = "Rua Tamarindo",
                Num = 75,
                Bairro = "Assunção",
                Cep = "09845676",
                Cnpj = "643458648356707",
                Insc = "78353724665",
                Contato = "beat@gmail.com",
                Tel = "1151757823",
            });*/

            /*RepositorioFornecedor fornecedor = new RepositorioFornecedor();
            fornecedor.Update(new Fornecedor
            {
                CodFornecedor = 1,
                Cidade = new Cidade
                {
                    CodCidade = 1
                },             
                Nome = "Submarino",
                Endereco = "Rua das Laranjeiras",
                Num = 89,
                Bairro = "Nova Petrópolis",
                Cep = "09198500",
                Contato = "submarino@gmail.com",
                Cnpj = "265755565565480",
                Insc = "63997418652",
                Tel = "1129475450",
               
            });*/

            /*RepositorioEntrada repositorioEntrada = new RepositorioEntrada();
            repositorioEntrada.Update(new Entrada
            {
                CodEntrada = 1,
                Transportadora = new Transportadora { CodTransportadora = 1 },
                DataPed = DateTime.ParseExact("10-12-2020", "dd-MM-yyyy",CultureInfo.InvariantCulture),
                DataEntr = DateTime.ParseExact("17-12-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                Total = 750.0m,
                Frete = 45.0m,
                NumNf = 90,
                Imposto = 5
            });*/

            /*RepositorioProduto produto = new RepositorioProduto();
            produto.Update(new Produto { 
                CodProduto = 1,
                Categoria = new Categoria { CodCategoria = 1 },
                Fornecedor = new Fornecedor { CodFornecedor = 1},
                Descricao = "Papel Higiênico",
                Peso = 1.4m,
                Controlado = false,
                QtdeMin = 800
            });*/


            /*RepositorioSaida repositorioSaida = new RepositorioSaida();
            repositorioSaida.Update(new Saida { 
                CodSaida = 2,
                Loja = new Loja { CodLoja = 1 },
                Trasportadora = new Transportadora { CodTransportadora = 1 },
                Total = 650,
                Frete = 25,
                Imposto = 25
            });*/

            /*RepositorioItemEntrada repositorioItemEntrada = new RepositorioItemEntrada();
            repositorioItemEntrada.Update(new ItemEntrada
            {
                CodItemEntrada = 1,
                Produto = new Produto { CodProduto = 1 },
                Entrada = new Entrada { CodEntrada = 1 },
                Lote = "23a",
                Qtde = 100,
                Valor = 520
            }) ;*/

            RepositorioItemSaida repositorioItemSaida = new RepositorioItemSaida();
            repositorioItemSaida.Update(new ItemSaida
            {
                CodItemSaida = 4,
                Saida = new Saida { CodSaida = 2 },
                Produto = new Produto { CodProduto = 1 },
                Lote = "902C",
                Qtde = 90,
                Valor = 653
            });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
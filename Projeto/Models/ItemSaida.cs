using System.Collections.Generic;

namespace Projeto.Models
{
    public class ItemSaida
    {
        public int CodItemSaida { get; set; }
        public int Saida_CodSaida { get; set; }
        public int Produto_CodProduto { get; set; }
        public string Lote { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }

        public virtual Saida Saida { get; set; }
        public virtual Produto Produto { get; set; }

        public List<Saida> ListaSaida { get; set; }
        public List<Produto> ListaProduto { get; set; }
    }
}

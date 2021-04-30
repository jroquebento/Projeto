using System.Collections.Generic;

namespace Projeto.Models
{
    public class ItemEntrada
    {
        public int CodItemEntrada { get; set; }
        public int Produto_CodProduto { get; set; }
        public int Entrada_CodEntrada { get; set; }
        public string Lote { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Entrada Entrada { get; set; }

        public List<Produto> ListaProduto { get; set; }

        public List<Entrada> ListaEntrada { get; set; }
    }
}

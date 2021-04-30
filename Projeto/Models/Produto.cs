using System.Collections.Generic;

namespace Projeto.Models
{
    public class Produto
    {
        public int CodProduto { get; set; }
        public int Categoria_CodCategoria { get; set; }
        public int Fornecedor_CodFornecedor { get; set; }
        public string Descricao { get; set; }
        public decimal Peso { get; set; }
        public bool Controlado { get; set; }
        public int QtdeMin { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public List<Categoria> ListaCategoria { get; set; }

        public List<Fornecedor> ListaFornecedor { get; set; }
    }
}

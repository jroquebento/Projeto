using System.Collections.Generic;

namespace Projeto.Models
{
    public class Fornecedor
    {
        public int CodFornecedor { get; set; }
        public int Cidade_CodCidade { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Num { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Contato { get; set; }
        public string Cnpj { get; set; }
        public string Insc { get; set; }
        public string Tel { get; set; }
        public virtual Cidade Cidade { get; set; }

        public List<Cidade> ListaCidade { get; set; }
    }
}

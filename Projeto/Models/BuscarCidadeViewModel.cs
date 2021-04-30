using System.Collections.Generic;

namespace Projeto.Models
{
    public class BuscarCidadeViewModel
    {
        public string Nome { get; set; }

        public string Uf { get; set; }
        public List<Cidade> ListaCidades { get; set; }
    }
}

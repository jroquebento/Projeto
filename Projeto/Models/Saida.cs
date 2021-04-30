using System.Collections.Generic;

namespace Projeto.Models
{
    public class Saida
    {
        public int CodSaida { get; set; }
        public int Loja_CodLoja { get; set; }
        public int Transportadora_CodTransportadora { get; set; }
        public decimal Total { get; set; }
        public decimal Frete { get; set; }
        public decimal Imposto { get; set; }

        public virtual Loja Loja { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        public List<Loja> ListaLoja { get; set; }

        public List<Transportadora> ListaTransportadora { get; set; }

    }
}

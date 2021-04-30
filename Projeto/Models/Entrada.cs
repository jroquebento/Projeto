using System;
using System.Collections.Generic;

namespace Projeto.Models
{
    public class Entrada
    {
        public int CodEntrada { get; set; }
        public int Transportadora_CodTransportadora { get; set; }
        public DateTime DataPed { get; set; }
        public DateTime DataEntr { get; set; }
        public decimal Total { get; set; }
        public decimal Frete { get; set; }
        public int NumNf { get; set; }
        public decimal Imposto { get; set; }

        public virtual Transportadora Transportadora { get; set; }

        public List<Transportadora> ListaTransportadora { get; set; }

        public List<ItemEntrada> ListaItemEntrada { get; set; }
    }
}

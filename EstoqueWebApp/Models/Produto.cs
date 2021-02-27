using System;
using System.Collections.Generic;

#nullable disable

namespace EstoqueWebApp.Models
{
    public partial class Produto
    {
        public int CodProduto { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataLancamento { get; set; }
        public int CodTipoProduto { get; set; }

        public virtual TipoProduto TipoProduto { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EstoqueWebApp.Models
{
    public partial class TipoProduto
    {
        /*public TipoProduto()
        {
            Produtos = new HashSet<Produto>();
        }*/

        public int CodTipoProduto { get; set; }
        public string Descricao { get; set; }

        //public virtual ICollection<Produto> Produtos { get; set; }
    }
}

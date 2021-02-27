using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

#nullable disable

namespace EstoqueWebApp.Models
{
    public partial class Usuario
    {
        public int CodCliente { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}

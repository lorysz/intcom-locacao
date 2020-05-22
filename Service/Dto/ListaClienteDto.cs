using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class ListaClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}

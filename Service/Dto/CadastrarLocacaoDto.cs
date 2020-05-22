using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class CadastrarLocacaoDto
    {
        public int IdFilme { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}

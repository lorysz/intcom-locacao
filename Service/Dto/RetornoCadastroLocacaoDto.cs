using Service.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class RetornoCadastroLocacaoDto
    {
        public string Msg { get; set; }
        public int Erro { get; set; }
        public int? IdLocacao { get; set; }
    }
}

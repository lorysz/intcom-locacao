using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class ListaLocacaoDto
    {
        public int IdLocacao { get; set; }
        public string Cliente { get; set; }
        public string Filme { get; set; }
        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
    }
}

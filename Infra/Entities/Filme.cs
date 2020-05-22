using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infra.Entities
{
    [Table("tb_filme")]
    public class Filme
    {
        [Key]
        public int Idfilme { get; set; }
        public string Nome { get; set; }
        
        public List<Locacao> Locacoes { get; set; }
    }
}

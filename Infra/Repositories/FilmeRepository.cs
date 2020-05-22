using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        public List<Filme> GetAll()
        {
            using (var _con = new Context())
            {
                return _con.Filme.ToList();                
            }
        }
    }
}

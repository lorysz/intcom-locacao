using Infra.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            using (var _con = new Context())
            {
                return _con.Cliente.ToList();
            }
        }
    }
}

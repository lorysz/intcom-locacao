using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        public void CadastrarLocacao(Locacao locacao)
        {
            using (var _con = new Context())
            {
                _con.Add(locacao);
                _con.SaveChanges();
            }
        }

        public void DevolverLocacao(Locacao locacao)
        {
            using (var _con = new Context())
            {
                _con.Update(locacao);
                _con.SaveChanges();
            }
        }

        public List<Locacao> GetAll()
        {
            using (var _con = new Context())
            {
                return _con.Locacao
                            .Include(x => x.Cliente)
                            .Include(x => x.Filme)
                            .ToList();
            }
        }

        public Locacao GetLocacaoById(int idLocacao)
        {
            using (var _con = new Context())
            {
                return _con.Locacao
                            .Include(x => x.Cliente)
                            .Include(x => x.Filme)
                            .Where(x => x.IdLocacao == idLocacao)
                            .FirstOrDefault();
            }
        }

        public Locacao GetLocacaoByFilme(int idFilme)
        {
            using (var _con = new Context())
            {
                return _con.Locacao.Where(x => x.DataDevolucao == null && x.IdFilme == idFilme).FirstOrDefault();
            }
        }

        public void AlterarLocacao(Locacao locacao)
        {
            using (var _con = new Context())
            {
                _con.Update(locacao);
                _con.SaveChanges();
            }
        }
    }
}

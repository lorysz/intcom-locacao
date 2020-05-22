using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Interfaces
{
    public interface ILocacaoRepository
    {
        void CadastrarLocacao(Locacao locacao);
        void AlterarLocacao(Locacao locacao);
        void DevolverLocacao(Locacao locacao);
        Locacao GetLocacaoById(int idLocacao);
        List<Locacao> GetAll();
        Locacao GetLocacaoByFilme(int idFilme);
    }
}

using Service.Dto;
using Service.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ILocacaoService
    {
        RetornoCadastroLocacaoDto CadastrarLocacao(CadastrarLocacaoDto locacao);
        void DevolverLocacao(DevolverLocacaoDto locacao);
        VisualizarLocacaoDto GetById(int idLocacao);
        List<ListaLocacaoDto> GetAll();
    }
}

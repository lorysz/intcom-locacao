using AutoMapper;
using Infra.Entities;
using Infra.Interfaces;
using Service.Dto;
using Service.Enums;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _repo;
        private readonly IMapper _map;
        public LocacaoService(ILocacaoRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public RetornoCadastroLocacaoDto CadastrarLocacao(CadastrarLocacaoDto locacao)
        {
            var loca = _repo.GetLocacaoByFilme(locacao.IdFilme);
            RetornoCadastroLocacaoDto obj = new RetornoCadastroLocacaoDto();
            if (loca == null)
            {
                var resultMap = _map.Map<Locacao>(locacao);
                _repo.CadastrarLocacao(resultMap);
                obj.Erro = 0;
                obj.Msg = EnumCadastroLocacao.Sucesso.GetDescription();
            }
            else if(loca.DataDevolucao == null && loca.IdCliente != locacao.IdCliente)
            {
                obj.Erro = 1;
                obj.Msg = EnumCadastroLocacao.LocadoOutroCliente.GetDescription();

            } else if(loca.IdCliente == locacao.IdCliente)
            {
                obj.Erro = 2;
                obj.Msg = EnumCadastroLocacao.LocadoMesmoCliente.GetDescription();
                obj.IdLocacao = loca.IdLocacao;
            }

            return obj;
        }

        public void DevolverLocacao(DevolverLocacaoDto locacao)
        {
            var loca = _repo.GetLocacaoById(locacao.IdLocacao);
            if (loca != null)
            {

                loca.DataDevolucao = locacao.DataDevolucao == null ? DateTime.Now : locacao.DataDevolucao;
                _repo.DevolverLocacao(loca);
            }
        }

        public List<ListaLocacaoDto> GetAll()
        {
            var result = _repo.GetAll();
            var resultMap = _map.Map<List<ListaLocacaoDto>>(result);
            return resultMap;
        }

        public VisualizarLocacaoDto GetById(int idLocacao)
        {
            var result = _repo.GetLocacaoById(idLocacao);
            var resultMap = _map.Map<VisualizarLocacaoDto>(result);
            return resultMap;
        }
    }
}

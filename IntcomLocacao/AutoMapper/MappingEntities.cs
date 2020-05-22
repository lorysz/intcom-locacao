using AutoMapper;
using Infra.Entities;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntcomLocacao.AutoMapper
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Cliente, VisualizarLocacaoDto>().ReverseMap();
            CreateMap<Cliente, ListaClienteDto>().ReverseMap();
            CreateMap<Locacao, CadastrarLocacaoDto>().ReverseMap();
            CreateMap<Filme, ListaFilmeDto>().ReverseMap();

            CreateMap<Locacao, VisualizarLocacaoDto>()
                .ForMember(x => x.DataLocacao, o => o.MapFrom(x => x.DataLocacao.Date.ToString()))
                .ForMember(x => x.Cliente, o => o.MapFrom(x => x.Cliente.Nome))
                .ForMember(x => x.Filme, o => o.MapFrom(x => x.Filme.Nome));

            CreateMap<Locacao, ListaLocacaoDto>()
                .ForMember(x => x.Cliente, o => o.MapFrom(x => x.Cliente.Nome))
                .ForMember(x => x.Filme, o => o.MapFrom(x => x.Filme.Nome))
                .ForMember(x => x.DataLocacao, o => o.MapFrom(x => x.DataLocacao.Date.ToString()))
                .ForMember(x => x.DataDevolucao, o => o.MapFrom(x => x.DataDevolucao != null ? Convert.ToDateTime(x.DataDevolucao).Date.ToString() : "")); ;


            //CreateMap<Usuario, CadastrarUsuarioDto>().ReverseMap();
            //CreateMap<Usuario, AlterarUsuarioDto>().ReverseMap();

            //CreateMap<Cliente, ListaClienteDto>().ReverseMap();
            //CreateMap<CadastroClienteDto, Cliente>().ReverseMap();
            //CreateMap<Cliente, CadastroClienteDto>()
            //    .ForMember(x => x.IdEstado, o => o.MapFrom(o => o.Cidade.IdEstado));

            //CreateMap<Estado, ComboEstadoDto>().ReverseMap();
            //CreateMap<Estado, CadastroEstadoDto>().ReverseMap();

            //CreateMap<Cidade, CadastroCidadeDto>().ReverseMap();
            //CreateMap<Cidade, ComboCidadeDto>().ReverseMap();

            //CreateMap<Processo, CadastroProcessoDto>()
            //    .ForMember(x => x.IdEstado, o => o.MapFrom(o => o.Cidade.IdEstado))
            //    .ForMember(x => x.Clientes, o => o.MapFrom(o => o.Clientes));
            //CreateMap<CadastroProcessoDto, Processo>();
            //CreateMap<Processo, AlterarProcessoDto>().ReverseMap();
            //CreateMap<Processo, ListaProcessoDto>()
            //    .ForMember(x => x.status, o => o.MapFrom(o => o.StatusProcesso.Nome));


            //CreateMap<Processo, VisualizarProcessoDto>()
            //    .ForMember(x => x.Uf, o => o.MapFrom(o => o.Cidade.Estado.Uf))
            //    .ForMember(x => x.Cidade, o => o.MapFrom(o => o.Cidade.Nome))
            //    .ForMember(x => x.Status, o => o.MapFrom(o => o.StatusProcesso.Nome))
            //    .ForMember(x => x.IdEstado, o => o.MapFrom(o => o.Cidade.IdEstado))
            //    .ForMember(x => x.DataDistribuicao, o => o.MapFrom(o => o.DataDistribuicao.ToString()))
            //    .ForMember(x => x.DataJulgamentoRecurso, o => o.MapFrom(o => o.DataJulgamentoRecurso.Date.ToString()))
            //    .ForMember(x => x.DataJulgamentoSentenca, o => o.MapFrom(o => o.DataJulgamentoSentenca.Date.ToString()))
            //    .AfterMap((p, vp) => vp.Clientes = new List<string>(p.Clientes.Select(c => c.Cliente.Nome)));

            //CreateMap<StatusProcesso, ComboStatusProcessoDto>();
            //CreateMap<CadastroProcessoClienteDto, ProcessoCliente>().ReverseMap();
            //CreateMap<CadastroAndamentoProcessoDto, AndamentoProcessual>();
            //CreateMap<AlterarAndamentoProcessoDto, AndamentoProcessual>().ReverseMap();
            //CreateMap<AndamentoProcessual, ListaAndamentoProcessoDto>();
            //CreateMap<PrazoProcessual, ListaPrazoDto>()
            //    .ForMember(x => x.NumeroProcesso, o => o.MapFrom(o => o.Processo.NumeroProcesso))
            //    .ForMember(x => x.DataInicial, o => o.MapFrom(o => o.DataInicial.Date.ToString()))
            //    .ForMember(x => x.DataFinal, o => o.MapFrom(o => o.DataFinal.Date.ToString()));

            //CreateMap<CadastrarPrazoDto, PrazoProcessual>();
        }
    }
}

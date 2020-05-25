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

        }
    }
}

using AutoMapper;
using Infra.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _map;
        public ClienteService(IClienteRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public List<ListaClienteDto> GetAll()
        {
            var result = _repo.GetAll();
            var resultMap = _map.Map<List<ListaClienteDto>>(result);

            return resultMap;
        }
    }
}

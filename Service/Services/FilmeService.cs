using AutoMapper;
using Infra.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _repo;
        private readonly IMapper _map;

        public FilmeService(IFilmeRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public List<ListaFilmeDto> GetAll()
        {
            var result = _repo.GetAll();
            var resultMap = _map.Map<List<ListaFilmeDto>>(result);
            return resultMap;
        }

    }
}

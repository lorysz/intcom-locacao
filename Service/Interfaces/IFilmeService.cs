using Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IFilmeService
    {
        List<ListaFilmeDto> GetAll();
    }
}

using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Interfaces
{
    public interface IFilmeRepository
    {        List<Filme> GetAll();
    }
}

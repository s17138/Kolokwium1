using Kolokwium.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Task<DtoAlbum?> GetAlbum(int id);
        Task<bool> RemoveMusician(int id);
    }
}

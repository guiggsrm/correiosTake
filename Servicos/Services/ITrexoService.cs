using Contracts.Repository;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface ITrexoService : ITrexoRepository
    {
        Task<IEnumerable<Trexo>> UploadAsync(string siglaEstado, IFormFile file);
    }
}

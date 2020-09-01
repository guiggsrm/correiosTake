using Entidades.Models;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IEstadoRepository : IRepository<Estado, int>
    {
        /// <summary>
        /// Obtem o estado pela sigla
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        Estado ObterPorSigla(string sigla);
        /// <summary>
        /// Obtem o estado pela sigla
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        Task<Estado> ObterPorSiglaAsync(string sigla);
    }
}

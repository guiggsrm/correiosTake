using Entidades.Models;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface ICidadeRepository : IRepository<Cidade, int>
    {
        /// <summary>
        /// Obtem a cidade pela sigla
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        Cidade ObterPorSigla(string siglaEstado, string siglaCidade);
        /// <summary>
        /// Obtem a cidade pela sigla
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        Task<Cidade> ObterPorSiglaAsync(string siglaEstado, string siglaCidade);
    }
}

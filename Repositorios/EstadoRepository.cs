using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Repositorios.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class EstadoRepository : RepositorioBase<Estado, int>, IEstadoRepository
    {
        public EstadoRepository(CorreiosContext correiosContext) : base(correiosContext) { }

        public Estado ObterPorSigla(string sigla)
        {
            return ObterQueryPorSigla(sigla).FirstOrDefault();
        }

        public async Task<Estado> ObterPorSiglaAsync(string sigla)
        {
            return await ObterQueryPorSigla(sigla).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Obtem a query para execução da pesquisa por sigla
        /// </summary>
        /// <param name="siglaEstado"></param>
        /// <returns></returns>
        private IQueryable<Estado> ObterQueryPorSigla(string siglaEstado)
        {
            return ObterPorCondicao(e => e.Sigla == siglaEstado);
        }
    }
}

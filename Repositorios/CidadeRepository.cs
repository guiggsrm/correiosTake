using Contracts.Repository;
using Entidades.Context;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Repositorios.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CidadeRepository : RepositorioBase<Cidade, int>, ICidadeRepository
    {
        public CidadeRepository(CorreiosContext correiosContext) : base(correiosContext) { }

        public Cidade ObterPorSigla(string siglaEstado, string siglaCidade)
        {
            return ObterQueryPorSigla(siglaEstado, siglaCidade).FirstOrDefault();
        }

        public async Task<Cidade> ObterPorSiglaAsync(string siglaEstado, string siglaCidade)
        {
            return await ObterQueryPorSigla(siglaEstado, siglaCidade).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Obtem a query para execução da pesquisa por sigla
        /// </summary>
        /// <param name="siglaEstado"></param>
        /// <param name="siglaCidade"></param>
        /// <returns></returns>
        private IQueryable<Cidade> ObterQueryPorSigla(string siglaEstado, string siglaCidade)
        {
            return ObterPorCondicao(c => c.Sigla == siglaCidade && c.Estado.Sigla == siglaEstado);
        }
    }
}

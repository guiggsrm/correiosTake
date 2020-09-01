using Contracts.Repository;
using Entidades.Context;
using Entidades.Models;
using Repositorios.Base;

namespace Repository
{
    public class TrexoRepository : RepositorioBase<Trexo, long>, ITrexoRepository
    {
        public TrexoRepository(CorreiosContext correiosContext) : base(correiosContext) { }
    }
}

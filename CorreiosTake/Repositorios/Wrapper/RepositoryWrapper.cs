using Contracts.Repository;
using Entidades.Context;

namespace Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected CorreiosContext Context;

        protected IEstadoRepository _estadoRepository;

        protected ICidadeRepository _cidadeRepository;

        protected ITrexoRepository _trexoRepository;

        public RepositoryWrapper(CorreiosContext correiosContext)
        {
            this.Context = correiosContext;
        }

        public IEstadoRepository EstadoRepository
        {
            get{
                if (_estadoRepository == null)
                    _estadoRepository = new EstadoRepository(Context);
                return _estadoRepository;
            }
        }

        public ICidadeRepository CidadeRepository
        {
            get
            {
                if (_cidadeRepository == null)
                    _cidadeRepository = new CidadeRepository(Context);
                return _cidadeRepository;
            }
        }

        public ITrexoRepository TrexoRepository
        {
            get
            {
                if (_trexoRepository == null)
                    _trexoRepository = new TrexoRepository(Context);
                return _trexoRepository;
            }
        }
    }
}

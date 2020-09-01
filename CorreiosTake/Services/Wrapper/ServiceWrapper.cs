using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using Repository.Wrapper;
using System.Threading.Tasks;

namespace Services.Wrapper
{
    public class ServiceWrapper : IServiceWrapper
    {
        protected CorreiosContext Context;

        public ServiceWrapper(CorreiosContext correiosContext)
        {
            this.Context = correiosContext;
        }

        private IRepositoryWrapper _repositoryWrapper;

        private IEstadoService _estadoService;

        private ICidadeService _cidadeService;

        private ITrexoService _trexoService;

        public IEstadoService EstadoService
        {
            get
            {
                if (_estadoService == null)
                    _estadoService = new EstadoService(Context, this, RepositoryWrapper);
                return _estadoService;
            }
        }

        public ICidadeService CidadeService
        {
            get
            {
                if (_cidadeService == null)
                    _cidadeService = new CidadeService(Context, this, RepositoryWrapper);
                return _cidadeService;
            }
        }

        public IRepositoryWrapper RepositoryWrapper
        {
            get
            {
                if (_repositoryWrapper == null)
                    _repositoryWrapper = new RepositoryWrapper(Context);
                return _repositoryWrapper;
            }
        }

        public ITrexoService TrexoService
        {
            get
            {
                if (_trexoService == null)
                    _trexoService = new TrexoService(Context, this, RepositoryWrapper);
                return _trexoService;
            }
        }
    }
}

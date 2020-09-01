using Contracts.Repository;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IServiceWrapper
    {
        IRepositoryWrapper RepositoryWrapper { get; }
        /// <summary>
        /// Servicços para trabalhar com o model de estado
        /// </summary>
        IEstadoService EstadoService { get; }
        /// <summary>
        /// Servicços para trabalhar com o model de cidade
        /// </summary>
        ICidadeService CidadeService { get; }
        /// <summary>
        /// Servicços para trabalhar com o model de trexos
        /// </summary>
        ITrexoService TrexoService { get; }
    }
}

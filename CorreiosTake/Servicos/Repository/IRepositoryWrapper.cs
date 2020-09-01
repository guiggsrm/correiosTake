namespace Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IEstadoRepository EstadoRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        ITrexoRepository TrexoRepository { get; }
    }
}

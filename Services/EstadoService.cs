using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using Entidades.Models;
using Repositorios.Base;
using Repository;
using Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class EstadoService : ServiceBase, IEstadoService
    {
        public EstadoService(CorreiosContext correiosContext, IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper) : base(correiosContext, serviceWrapper, repositoryWrapper) { }
        
        public void Atualizar(Estado model)
        {
            RepositoryWrapper.EstadoRepository.Atualizar(model);
            Save();
        }

        public void Deletar(Estado model)
        {
            RepositoryWrapper.EstadoRepository.Deletar(model);
            Save();
        }

        public void Incluir(Estado model)
        {
            RepositoryWrapper.EstadoRepository.Incluir(model);
            Save();
        }

        public async Task IncluirAsync(Estado model)
        {
            await RepositoryWrapper.EstadoRepository.IncluirAsync(model);
            await SaveAsync();
        }

        public Estado ObterPorId(int id)
        {
            return RepositoryWrapper.EstadoRepository.ObterPorId(id);
        }

        public async Task<Estado> ObterPorIdAsync(int id)
        {
            return await RepositoryWrapper.EstadoRepository.ObterPorIdAsync(id);
        }

        public Estado ObterPorSigla(string sigla)
        {
            return RepositoryWrapper.EstadoRepository.ObterPorSigla(sigla);
        }

        public async Task<Estado> ObterPorSiglaAsync(string sigla)
        {
            return await RepositoryWrapper.EstadoRepository.ObterPorSiglaAsync(sigla);
        }

        public IEnumerable<Estado> ObterTodos()
        {
            return RepositoryWrapper.EstadoRepository.ObterTodos();
        }

        public async Task<IEnumerable<Estado>> ObterTodosAsync()
        {
            return await RepositoryWrapper.EstadoRepository.ObterTodosAsync();
        }

        public void Save()
        {
            RepositoryWrapper.EstadoRepository.Save();
        }

        public void Save(Estado model)
        {
            RepositoryWrapper.EstadoRepository.Save(model);
        }

        public async Task SaveAsync()
        {
            await RepositoryWrapper.EstadoRepository.SaveAsync();
        }

        public async Task SaveAsync(Estado model)
        {
            await RepositoryWrapper.EstadoRepository.SaveAsync(model);
        }
    }
}

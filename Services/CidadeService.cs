using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using Entidades.Models;
using Repository;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CidadeService : ServiceBase, ICidadeService
    {
        public CidadeService(CorreiosContext correiosContext, IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper) : base(correiosContext, serviceWrapper, repositoryWrapper) { }

        public void Atualizar(Cidade model)
        {
            RepositoryWrapper.CidadeRepository.Atualizar(model);
        }

        public void Deletar(Cidade model)
        {
            RepositoryWrapper.CidadeRepository.Deletar(model);
        }

        public void Incluir(Cidade model)
        {
            RepositoryWrapper.CidadeRepository.Incluir(model);
        }

        public async Task IncluirAsync(Cidade model)
        {
            await RepositoryWrapper.CidadeRepository.IncluirAsync(model);
        }

        public Cidade ObterPorId(int id)
        {
            return RepositoryWrapper.CidadeRepository.ObterPorId(id);
        }

        public async Task<Cidade> ObterPorIdAsync(int id)
        {
            return await RepositoryWrapper.CidadeRepository.ObterPorIdAsync(id);
        }

        public Cidade ObterPorSigla(string siglaEstado, string siglaCidade)
        {
            return RepositoryWrapper.CidadeRepository.ObterPorSigla(siglaEstado, siglaCidade);
        }

        public async Task<Cidade> ObterPorSiglaAsync(string siglaEstado, string siglaCidade)
        {
            return await RepositoryWrapper.CidadeRepository.ObterPorSiglaAsync(siglaEstado, siglaCidade);
        }

        public IEnumerable<Cidade> ObterTodos()
        {
            return RepositoryWrapper.CidadeRepository.ObterTodos();
        }

        public async Task<IEnumerable<Cidade>> ObterTodosAsync()
        {
            return await RepositoryWrapper.CidadeRepository.ObterTodosAsync();
        }

        public void Save()
        {
            RepositoryWrapper.CidadeRepository.Save();
        }

        public void Save(Cidade model)
        {
            RepositoryWrapper.CidadeRepository.Save(model);
        }

        public async Task SaveAsync()
        {
            await RepositoryWrapper.CidadeRepository.SaveAsync();
        }

        public async Task SaveAsync(Cidade model)
        {
            await RepositoryWrapper.CidadeRepository.SaveAsync(model);
        }
    }
}

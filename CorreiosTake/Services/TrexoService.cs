using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Repository;
using Services.Base;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
    class TrexoService : ServiceBase, ITrexoService
    {
        public TrexoService(CorreiosContext correiosContext, IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper) : base(correiosContext, serviceWrapper, repositoryWrapper) { }

        public void Atualizar(Trexo model)
        {
            RepositoryWrapper.TrexoRepository.Atualizar(model);
        }

        public void Deletar(Trexo model)
        {
            model.IsDeleted = true;
            Atualizar(model);
        }

        public void Incluir(Trexo model)
        {
            RepositoryWrapper.TrexoRepository.Incluir(model);
        }

        public async Task IncluirAsync(Trexo model)
        {
            await RepositoryWrapper.TrexoRepository.IncluirAsync(model);
        }

        public Trexo ObterPorId(long id)
        {
            return RepositoryWrapper.TrexoRepository.ObterPorId(id);
        }

        public async Task<Trexo> ObterPorIdAsync(long id)
        {
            return await RepositoryWrapper.TrexoRepository.ObterPorIdAsync(id);
        }

        public IEnumerable<Trexo> ObterTodos()
        {
            return RepositoryWrapper.TrexoRepository.ObterTodos();
        }

        public async Task<IEnumerable<Trexo>> ObterTodosAsync()
        {
            return await RepositoryWrapper.TrexoRepository.ObterTodosAsync();
        }

        public void Save()
        {
            RepositoryWrapper.TrexoRepository.Save();
        }

        public void Save(Trexo model)
        {
            RepositoryWrapper.TrexoRepository.Save(model);
        }

        public async Task SaveAsync()
        {
            await RepositoryWrapper.TrexoRepository.SaveAsync();
        }

        public async Task SaveAsync(Trexo model)
        {
            await RepositoryWrapper.TrexoRepository.SaveAsync(model);
        }

        public async Task<IEnumerable<Trexo>> IncluirAsync(string siglaEstado, IFormFile file)
        {
            IEnumerable<Trexo> trexosIncluidos = new List<Trexo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    await DesativarTrexosAtuaisAsync();
                    Trexo trexo = null;
                    foreach (string linha in await file.ToListAsync())
                    {
                        trexo = await LerLinhaDeTrexoAtiva(siglaEstado, linha);
                        await IncluirAsync(trexo);
                        trexosIncluidos.Append(trexo);
                    }

                    scope.Complete();
                }
                return trexosIncluidos;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        /// <summary>
        /// Faz a leitura da linha e trasforma em trexos
        /// </summary>
        /// <param name="siglaEstado"></param>
        /// <param name="linha"></param>
        /// <returns></returns>
        private async Task<Trexo> LerLinhaDeTrexoAtiva(string siglaEstado, string linha)
        {
            var splitLinha = linha.Split(" ");
            Cidade cidadePartida = await RepositoryWrapper.CidadeRepository.ObterPorSiglaAsync(siglaEstado, splitLinha[0]);
            Cidade cidadeDestino = await RepositoryWrapper.CidadeRepository.ObterPorSiglaAsync(siglaEstado, splitLinha[1]);
            int dias = int.Parse(splitLinha[1]);
            Trexo trexo = new Trexo(cidadePartida.Id, cidadeDestino.Id, dias);
            return trexo;
        }
        /// <summary>
        /// Destaiva todos os trexos ativos
        /// </summary>
        /// <returns></returns>
        private async Task DesativarTrexosAtuaisAsync()
        {
            IEnumerable<Trexo> trexosAtivos = await ObterTodosAsync();
            trexosAtivos.ToList().ForEach(t => t.IsDeleted = true);
            await SaveAsync();
        }
    }
}

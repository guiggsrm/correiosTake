using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepository<TEntity, IdType>
    {
        /// <summary>
        /// Inclui o objeto na base de dados
        /// </summary>
        /// <param name=""></param>
        Task IncluirAsync(TEntity model);
        /// <summary>
        /// Inclui o objeto na base de dados
        /// </summary>
        /// <param name=""></param>
        void Incluir(TEntity model);
        /// <summary>
        /// Atualiza o objeto na base de dados
        /// </summary>
        /// <param name=""></param>
        void Atualizar(TEntity model);
        /// <summary>
        /// Deleta o objeto da base de dados
        /// </summary>
        /// <param name=""></param>
        void Deletar(TEntity model);
        /// <summary>
        /// Obtem todos os registros da tabela
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        /// <summary>
        /// Obtem todos os registros da tabela
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> ObterTodos();
        /// <summary>
        /// Obtem pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity ObterPorId(IdType id);
        /// <summary>
        /// Obptem pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> ObterPorIdAsync(IdType id);
        /// <summary>
        /// Salva todas as alterações na base de dados
        /// </summary>
        void Save();
        /// <summary>
        /// Salva todas as alterações na base de dados
        /// </summary>
        Task SaveAsync();
        /// <summary>
        /// Salva todas as alterações na base de dados
        /// </summary>
        void Save(TEntity model);
        /// <summary>
        /// Salva todas as alterações na base de dados
        /// </summary>
        Task SaveAsync(TEntity model);
    }
}

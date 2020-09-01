using System;
using System.Linq;
using System.Linq.Expressions;
using Entidades.Context;
using Microsoft.EntityFrameworkCore;
using Contracts.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Repository.Extensions;
using Microsoft.Data.SqlClient;

namespace Repositorios.Base
{
    public abstract class RepositorioBase<TEntity, IdType> : IRepository<TEntity, IdType> 
        where TEntity : class 
        where IdType : struct
    {
        protected CorreiosContext Context;

        protected RepositorioBase(CorreiosContext correiosContext)
        {
            this.Context = correiosContext;
        }

        public virtual void Atualizar(TEntity model)
        {
            Context.Entry(model).State = EntityState.Modified;
            Save(model);
        }

        public virtual void Deletar(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
            Save(model);
        }

        public virtual void Incluir(TEntity model)
        { 
            Context.Set<TEntity>().Add(model);
            Save(model);
        }

        public virtual async Task IncluirAsync(TEntity model)
        {
            await Context.Set<TEntity>().AddAsync(model);
            await SaveAsync(model);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public TEntity ObterPorId(IdType id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> ObterPorIdAsync(IdType id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public void Save(TEntity model)
        {
            try
            {
                Save();
            }
            catch (DbUpdateException e)
            {
                Context.Entry(model).State = EntityState.Unchanged;
                throw e.HandleDbUpdateException();
            }
            catch (Exception e)
            {
                Context.Entry(model).State = EntityState.Unchanged;
                throw e;
            }
        }

        public async Task SaveAsync(TEntity model)
        {
            try
            {
                await SaveAsync();
            }
            catch (DbUpdateException e)
            {
                Context.Entry(model).State = EntityState.Unchanged;
                throw e.HandleDbUpdateException();
            }
            catch (Exception e)
            {
                Context.Entry(model).State = EntityState.Unchanged;
                throw e;
            }
        }
        /// <summary>
        /// Obtem registros por condição
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> ObterPorCondicao(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Where(expression);

        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

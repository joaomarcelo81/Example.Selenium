using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using DesafioTecnicoArtycs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Infra.Repository.Base
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity.DataCadastro == DateTime.MinValue)
                entity.DataCadastro = DateTime.Now;
                

            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity.DataCadastro == DateTime.MinValue)
                entity.DataCadastro = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Entities;

namespace Waxy.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //Dependency injection => o singura instanta de context, sa nu mai instantiez de fiecare data contextul
        protected readonly WaxyContext _context; 
        //readonly = nu vrem sa modif contextul, il consideram ca pe un serviciu
        public GenericRepository(WaxyContext context)
        {
            _context = context;
        }


        public void Create(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity); //din context iau un set de entitati, unde imi mapeaza tabela
        }
        
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
            //ma joc cu datele in program, le modific doar local, nu si in db
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;

        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
//Colectii

//IQueryable - tine minte query-ul spre baza de date;
//accesarea lui se face prin query la db
//nu tine minte datele, ci cum le luam

//IEnumerable - acelasi, in memory
//nu face query catre db de fiecare data, le are deja acolo

//List - tine minte datele propriu zise
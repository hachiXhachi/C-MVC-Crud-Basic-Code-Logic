using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.DataAccess.Data;
using Crud.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Crud.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }
        public void add(T entitites)
        {
            dbset.Add(entitites);
        }

        public void delete(T entities)
        {
            dbset.Remove(entities);
        }

        public void deleteRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public T GetEntitiy(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}

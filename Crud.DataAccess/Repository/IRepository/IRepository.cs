using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetEntitiy(Expression<Func<T, bool>> filter);
        void add(T entitites);
        void delete(T entities);
        void deleteRange(IEnumerable<T> entities);
    }
}

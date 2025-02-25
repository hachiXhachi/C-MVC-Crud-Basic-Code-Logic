using Crud.DataAccess.Data;
using Crud.DataAccess.Repository.IRepository;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {

        private ApplicationDbContext _db;
        public SalaryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(Salary obj)
        {
            _db.sal.Update(obj);
        }
    }
}

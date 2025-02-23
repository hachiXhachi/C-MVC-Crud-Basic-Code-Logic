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
    public class EmployeeRepository :Repository<Employee>, IEmployee
    {

        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
  

        public void update(Employee emp)
        {
            _db.Emp.Update(emp);
        }
    }
}

using Crud.DataAccess.Data;
using Crud.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _db;
        public IEmployee empRepo { get; private set; }

        public ISalaryRepository salaRepo { get; private set; }

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            empRepo = new EmployeeRepository(_db);
            salaRepo = new SalaryRepository(_db);
        }
       

        public void save()
        {
            _db.SaveChanges();
        }
    }
}

using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Repository.IRepository
{
     public interface IEmployee : IRepository<Employee>
    {
        void update(Employee emp);
      
    }
}

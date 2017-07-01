using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDepartment.Models;

namespace EmployeeDepartment.Repositories
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        Department Add(Department item);
        bool Update(Department item);
        bool Delete(int id);
    }
}

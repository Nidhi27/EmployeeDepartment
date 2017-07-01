using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDepartment.Repositories;
using System.Collections;
using EmployeeDepartment.Models;

namespace EmployeeDepartment.Controllers
{
    public class DepartmentController : ApiController
    {
       
        static readonly IDepartmentRepository repository = new DepartmentRepository();
       
        public IEnumerable GetAllDepartments()
        {
            return repository.GetAll();
        }

        public Department PostDepartment(Department item)
        {
            return repository.Add(item);
        }

        public IEnumerable PutDepartment(int id, Department department)
        {
            department.Id = id;
            if (repository.Update(department))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteDepartment(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

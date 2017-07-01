using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDepartment.Repositories;
using EmployeeDepartment.Models;
using System.Collections;


namespace EmployeeDepartment.Controllers
{
    public class EmployeeController : ApiController
    {
        // static readonly IEmployeeRepository repository = new EmployeeRepository();

        private static IEmployeeRepository repository = new EmployeeRepository();

        public IEnumerable GetAllEmployees()
        {
           
            return repository.GetAll();
        }

        public Employee PostEmployee(Employee item)
        {
            
             return repository.Add(item);
        }

        public IEnumerable PutEmployee(int id, Employee employee)
        {
            employee.Id = id;
            if (repository.Update(employee))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteEmployee(int id)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDepartment.Models;

namespace EmployeeDepartment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDepartmentContext db = new EmployeeDepartmentContext();
       

        public IEnumerable<Employee> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            
            return db.Employees;
        }

        public Employee Get(int id)
        {
            // TO DO : Code to find a record in database
            return db.Employees.Find(id);
        }

        //public Employee Add(Employee item)
        //{
        //    if (item == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }

        //    // TO DO : Code to save record into database
        //    db.Employees.Add(item);
        //    db.SaveChanges();
        //    return item;
        //}

            public Employee Add(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            db.Employees.Add(item);
            db.SaveChanges();
            return item;
        }
        public bool Update(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            var employees = db.Employees.Single(a => a.Id == item.Id);
            employees.Name = item.Name;
            employees.City = item.City;
            employees.DepartmentId = item.DepartmentId;

            db.SaveChanges();

            return true;
        }


        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Employee employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
            db.SaveChanges();
            return true;
        }
    }
}
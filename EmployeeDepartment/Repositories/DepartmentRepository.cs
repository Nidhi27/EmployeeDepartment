using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDepartment.Models;

namespace EmployeeDepartment.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        EmployeeDepartmentContext db = new EmployeeDepartmentContext();

        public IEnumerable<Department> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return db.Departments;
        }

        public Department Get(int id)
        {
            // TO DO : Code to find a record in database
            return db.Departments.Find(id);
        }

        public Department Add(Department item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            db.Departments.Add(item);
            db.SaveChanges();
            return item;
        }

        public bool Update(Department item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            var departments = db.Departments.Single(a => a.Id == item.Id);
            departments.Name = item.Name;

            db.SaveChanges();

            return true;
        }


        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Department departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
            db.SaveChanges();
            return true;
        }
    }
}
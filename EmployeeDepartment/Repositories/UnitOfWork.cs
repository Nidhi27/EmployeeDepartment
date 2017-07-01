using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDepartment.Models;

namespace EmployeeDepartment.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeDepartmentContext context;
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Employee> employeeRepository;

        public UnitOfWork(EmployeeDepartmentContext context, GenericRepository<Department> departmentRepository, GenericRepository<Employee> employeeRepository)
        {
            this.context = context;
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;

        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }

                return departmentRepository;
            }
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<Employee>(context);
                }
                return employeeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDepartment.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string DepartmentName { get; set; }
    }
}
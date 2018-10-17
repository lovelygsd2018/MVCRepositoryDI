namespace Emp_DI_2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> DepartmentID { get; set; }
    }
}

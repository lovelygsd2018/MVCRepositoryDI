using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_DI_2.ViewModels
{
    public class vmEmployee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal? Salary { get; set; }
        public string DeparmentName { get; set; }
    }
}

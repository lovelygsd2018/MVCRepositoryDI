using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emp_DI_2.Models;
using Emp_DI_2.Repository;
using Emp_DI_2.ViewModels;
namespace Emp_DI_2.Controllers
{
    public class EmpController : Controller
    {
        IRepository<Employee> _repo;
        IRepository<Department> _repoDep;
        public EmpController(IRepository<Employee> repo, IRepository<Department> repoDept)
        {
            this._repo = repo;
            this._repoDep = repoDept;
        }
        public ActionResult Index()
        {
            var emplist = _repo.GetAll().ToList();
            var deptlist = _repoDep.GetAll().ToList();
            var list = from emp in emplist
                       join dep in deptlist
                       on emp.DepartmentID equals dep.DepartmentID
                       select new vmEmployee()
                       {
                         EmployeeID = emp.EmployeeID,
                         EmployeeName = emp.EmployeeName,
                         DeparmentName = dep.DepartmentName,
                         Salary = emp.Salary
                       }; 
            return View(list);
        }
        //AddNew: Open AddNew Partial View form
        public ActionResult prvShowAddfrm()
        {
            return PartialView("_Add_Emp");
        }
        //AddNew: Save Data
        [HttpPost]
        public void prvSaveAddfrm(Employee Dt)
        {
            if(Dt != null)
            {
                Employee em = new Employee();
                em.EmployeeName = Dt.EmployeeName;
                em.Salary = Dt.Salary;
                _repo.Add(em);
            }       
        }

        public ActionResult prvShowEditfrm(string sID)
        {
            if (string.IsNullOrEmpty(sID))
                return View();
            int iID = int.Parse(sID);
            Employee empDt = _repo.GetById(iID);
            //Department Dropdownlist
            var deptAllDt = _repoDep.GetAll();
            ViewBag.selectLst_DeptAll = new SelectList(deptAllDt, "DepartmentID", "DepartmentName", empDt.DepartmentID);
            //new SelectList(sclist, "CategoryId", "CategoryName", pd.CategoryId);
            return PartialView("_Edit_Emp", empDt);
        }
        [HttpPost]
        public void prvSaveEditfrm(Employee Dt)
        {
            if (Dt != null)
            {
                Employee em = new Employee();
                em.EmployeeID = Dt.EmployeeID;
                em.EmployeeName = Dt.EmployeeName;
                em.Salary = Dt.Salary;
                em.DepartmentID = Dt.DepartmentID;
                _repo.Update(em);
            }
        }      
    }
}
 
 

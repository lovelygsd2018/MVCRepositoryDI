using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Emp_DI_2.Models;
using Emp_DI_2.Repository;
using System.Data.Entity;


namespace Emp_DI_2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<DbContext, EmpEntities>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}

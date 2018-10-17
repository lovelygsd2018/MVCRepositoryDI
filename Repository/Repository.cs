using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emp_DI_2.Models;
using System.Data.Entity;   

namespace Emp_DI_2.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmpEntities _Context;
        protected DbSet<T> _DbSet;

        public Repository(EmpEntities context){
            this._Context = context;
            _DbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _DbSet;
        }
        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }
        public void Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            Save();
        }
        public void Update(T entity)
        {
            _Context.Entry(entity).State = System.Data.EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _Context.SaveChanges();
        }
    }
}

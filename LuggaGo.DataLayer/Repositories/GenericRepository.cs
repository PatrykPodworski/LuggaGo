﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LuggaGo.DataLayer.Interfaces;

namespace LuggaGo.DataLayer.Models.Repositories
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual IQueryable<T> GetAll()
        {
            var query = _entities.Set<T>();
            return query;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using GClient.Models;
using GClient.Interfaces.Infrastructure;


namespace GClient.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties
        private clientDBModel dataContext;
        private readonly IDbSet<T> dbSet;
        #endregion

        /// <summary>
        /// Generate dataContext
        /// </summary>
        /// <param name="dataContext"></param>
        public Repository(clientDBModel dataContext)
        {
            this.dataContext = dataContext;
            this.dbSet = dataContext.Set<T>();
        }

        /// <summary>
        /// Get/Set of DbFactory
        /// </summary>
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Generate DbContext
        /// </summary>
        protected clientDBModel DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        /// <summary>
        /// Generate dbFactory
        /// </summary>
        /// <param name="dbFactory"></param>
        protected Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        /// <summary>
        /// Add Object
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }


        /// <summary>
        /// Update object by attached object
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete object by attached object
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        // <summary>
        /// Get by Object by int Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        #endregion

    }
}
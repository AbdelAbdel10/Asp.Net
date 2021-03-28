using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GClient.Infrastructure;
using GClient.Models;
using GClient.Interfaces.Infrastructure;
using System.Data.Entity;

namespace GClient.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly clientDBModel dbContext;
        private bool disposed = false;

        public UnitOfWork()
        {
            this.dbContext = new clientDBModel();
        }

        /// <summary>
        /// UnitOfWork : Open one connexion for all CRUD for each object.
        /// </summary>
        private Repository<Client> client;

        public Repository<Client> Client
        {
            get
            {
                if (this.client == null)
                {
                    this.client = new Repository<Client>(dbContext);
                }
                return client;
            }
        }


        public void Commit()
        {
            dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
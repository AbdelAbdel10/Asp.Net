using GClient.Interfaces.Infrastructure;
using GClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GClient.Infrastructure
{
    public class DbFactory: IDbFactory
    {
        clientDBModel dbContext;

        /// <summary>
        /// Initialization of dbcontext
        /// </summary>
        /// <returns></returns>
        public clientDBModel Init()
        {
            return dbContext ?? (dbContext = new clientDBModel());
        }
    }
}
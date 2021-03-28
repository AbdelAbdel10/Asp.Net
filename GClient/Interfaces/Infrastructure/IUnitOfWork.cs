using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GClient.Interfaces.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // Commit
        void Commit();
    }

}

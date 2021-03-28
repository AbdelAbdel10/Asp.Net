using GClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GClient.Interfaces.Infrastructure
{
    public interface IDbFactory
    {
        clientDBModel Init();
    }
}

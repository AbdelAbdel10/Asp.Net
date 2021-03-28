using GClient.Interfaces.Infrastructure;
using GClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GClient.Interfaces.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        void Save();
    }
}

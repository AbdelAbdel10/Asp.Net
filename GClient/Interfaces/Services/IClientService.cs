using GClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GClient.Interfaces.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Client GetById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        void Save();
    }
}

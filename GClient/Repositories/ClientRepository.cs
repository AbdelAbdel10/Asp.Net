
using GClient.Infrastructure;
using GClient.Interfaces.Infrastructure;
using GClient.Interfaces.Repositories;
using GClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GClient.Repositories
{
    public class ClientRepository :  IClientRepository
    {
        private readonly UnitOfWork UoW = new UnitOfWork();

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetAllClients()
        {
            return UoW.Client.GetAll();
        }

        public Client GetById(int id)
        {
            return UoW.Client.GetById(id);
        }

        public void AddClient(Client client)
        {
            UoW.Client.Add(client);
        }

        public void UpdateClient(Client client)
        {
            UoW.Client.Update(client);
        }

        public void DeleteClient(int id)
        {
            UoW.Client.Delete(GetById(id));
        }

        public void Save()
        {
            UoW.Commit();
        }
    }
}
using GClient.Interfaces.Infrastructure;
using GClient.Interfaces.Repositories;
using GClient.Interfaces.Services;
using GClient.Models;
using GClient.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GClient.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository = new ClientRepository();
        public ClientService()
        {

        }

        public IEnumerable<Client> GetAllClients()
        {
            return clientRepository.GetAllClients();
        }

        public Client GetById(int id)
        {
            return clientRepository.GetById(id);
        }

        public void AddClient(Client client)
        {
            clientRepository.AddClient(client);
            Save();
        }

        public void UpdateClient(Client client)
        {
            clientRepository.UpdateClient(client);
            Save();
        }

        public void DeleteClient(int id)
        {
            clientRepository.DeleteClient(id);
            Save();
        }

        public void Save()
        {
            clientRepository.Save();
        }
    }
}
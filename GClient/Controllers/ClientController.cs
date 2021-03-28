using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GClient.Interfaces.Services;
using GClient.Models;
using GClient.Services;

namespace GClient.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService clientService = new ClientService();



        // GET: api/Client/GetAll
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetAll()
        {
            try
            {
                IEnumerable<Client> clients = clientService.GetAllClients();
                if (clients == null)
                    return NotFound();

                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Client/Get
        [ResponseType(typeof(Client))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Client client = clientService.GetById(id);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Client/Put
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Client client)
        {
            try{
                clientService.UpdateClient(client);
                return StatusCode(HttpStatusCode.OK);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            } 
        }

        // POST: api/Client/Post
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Client client)
        {
            try
            {
                clientService.AddClient(client);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Client/Delete
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                clientService.DeleteClient(id);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
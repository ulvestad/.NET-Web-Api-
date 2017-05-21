using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerServices.Controllers
{
    public class ServersController : ApiController
    {
        // GET: api/Servers
        public IEnumerable<Servers> Get()
        {
            using (ServerDBEntities entities =new ServerDBEntities()){
                return entities.Servers.ToList();
            }
        }

        // GET: api/Servers/5
        public Servers Get(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                return entities.Servers.FirstOrDefault(s => s.Id == id);
            }
        }

        // POST: api/Servers
        public HttpResponseMessage Post([FromBody]Servers server)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.Servers.Add(server);
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, server);
        }

        // PUT: api/Servers/5
        public HttpResponseMessage Put(int id, [FromBody]Servers server)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                var entity = entities.Servers.FirstOrDefault(s => s.Id == id);
                entity.Name = server.Name;
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, server);
        }

        // DELETE: api/Servers/5
        public HttpResponseMessage Delete(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.Servers.Remove(entities.Servers.FirstOrDefault(s => s.Id == id));
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}

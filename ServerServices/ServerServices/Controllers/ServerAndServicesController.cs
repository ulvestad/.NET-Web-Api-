using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerServices.Controllers
{
    public class ServerAndServicesController : ApiController
    {
        // GET: api/ServerAndServices
        public IEnumerable<ServerAndServices> Get()
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                return entities.ServerAndServices.ToList();
            }
        }

        // GET: api/ServerAndServices/5
        public ServerAndServices Get(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                return entities.ServerAndServices.FirstOrDefault(s => s.Server_id == id);
            }
        }

        // POST: api/ServerAndServices
        public HttpResponseMessage Post([FromBody]ServerAndServices SandS)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.ServerAndServices.Add(SandS);
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, SandS);
        }

        // PUT: api/ServerAndServices/5
        public HttpResponseMessage Put(int id, [FromBody]ServerAndServices SandS)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                //var entity = entities.ServerAndServices.FirstOrDefault(s => s.Server_id == id);
                //Primary key in table is composite key so cannot direclty update values: insted DELTE -> INSERT
                entities.ServerAndServices.Remove(entities.ServerAndServices.FirstOrDefault(s => s.Server_id == id));
                entities.SaveChanges();

                entities.ServerAndServices.Add(SandS);
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, SandS);
        }

        // DELETE: api/ServerAndServices/5
        public HttpResponseMessage Delete(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.ServerAndServices.Remove(entities.ServerAndServices.FirstOrDefault(s => s.Server_id == id));
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}

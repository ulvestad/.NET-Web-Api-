using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerServices.Controllers
{
    public class ServicesController : ApiController
    {
        // GET: api/Services
        public IEnumerable<Services> Get()
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                return entities.Services.ToList();
            }
        }

        // GET: api/Services/5
        public Services Get(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                return entities.Services.FirstOrDefault(s => s.Id == id);
            }
        }

        // POST: api/Services
        public HttpResponseMessage Post([FromBody]Services service)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.Services.Add(service);
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, service);
        }

        // PUT: api/Services/5
        public HttpResponseMessage Put(int id, [FromBody]Services service)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                var entity = entities.Services.FirstOrDefault(s => s.Id == id);
                entity.Name = service.Name;
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, service);
        }

        // DELETE: api/Services/5
        public HttpResponseMessage Delete(int id)
        {
            using (ServerDBEntities entities = new ServerDBEntities())
            {
                entities.Services.Remove(entities.Services.FirstOrDefault(s => s.Id == id));
                entities.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}

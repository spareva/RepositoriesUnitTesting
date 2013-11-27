using StudentsDatabase.Models;
using StudentsDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDatabase.Controllers
{
    public class GradesController : ApiController
    {
        IRepository<Grade> GradeRepository;

        public GradesController(IRepository<Grade> GradeRepository)
        {
            this.GradeRepository = GradeRepository;
        }

        // GET api/Grades
        public IEnumerable<Grade> Get()
        {
            return this.GradeRepository.All();
        }

        // GET api/Grades/5
        public Grade Get(int id)
        {
            return this.GradeRepository.Get(id);
        }

        // POST api/Grades
        public HttpResponseMessage Post(Grade value)
        {
            var created = this.GradeRepository.Add(value);

            var responce = Request.CreateResponse<Grade>(HttpStatusCode.Created, created);
            var resourceLink = Url.Link("DefaultApi", new { id = created.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // PUT api/Grades/5
        public HttpResponseMessage Put(int id, Grade value)
        {
            if (id != value.Id || value == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var updated = this.GradeRepository.Update(id, value);

            var responce = Request.CreateResponse<Grade>(HttpStatusCode.Created, updated);
            var resourceLink = Url.Link("DefaultApi", new { id = updated.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // DELETE api/Grades/5
        public HttpResponseMessage Delete(int id)
        {
            var found = this.GradeRepository.Get(id);
            if (found != null)
            {
                var responce = Request.CreateResponse<Grade>(HttpStatusCode.OK, found);
                var resourceLink = Url.Link("DefaultApi", new { id = found.Id });

                responce.Headers.Location = new Uri(resourceLink);
                this.GradeRepository.Delete(id);

                return responce;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
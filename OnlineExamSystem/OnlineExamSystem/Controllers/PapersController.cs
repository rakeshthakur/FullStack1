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
using OnlineExamSystem.Models;
using OnlineExamSystem.Repository;

namespace OnlineExamSystem.Controllers
{
    public class PapersController : ApiController
    {
        private OnlineExamContext db = new OnlineExamContext();

        // GET: api/Papers
        //public IQueryable<Paper> GetPapers()
        //{
        //    return db.Papers;
        //}

        public IHttpActionResult GetPaper()
        {
            return Ok(db.Papers);
        }
        // GET: api/Papers/5
        [ResponseType(typeof(Paper))]
        public IHttpActionResult GetPaper(int id)
        {
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return NotFound();
            }
          
            return Ok(db.Questions.Where(x => x.PaperId.Equals(id)).ToList().OrderBy(x => Guid.NewGuid()).Take(2));

            //return Ok(db.Questions.Where(x => x.PaperId.Equals(id)).ToList().OrderBy(x => Guid.NewGuid()).Take(2));
        }

        // PUT: api/Papers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaper(int id, Paper paper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paper.PaperId)
            {
                return BadRequest();
            }

            db.Entry(paper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Papers
        [ResponseType(typeof(Paper))]
        public IHttpActionResult PostPaper(Paper paper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Papers.Add(paper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paper.PaperId }, paper);
        }

        // DELETE: api/Papers/5
        [ResponseType(typeof(Paper))]
        public IHttpActionResult DeletePaper(int id)
        {
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return NotFound();
            }

            db.Papers.Remove(paper);
            db.SaveChanges();

            return Ok(paper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaperExists(int id)
        {
            return db.Papers.Count(e => e.PaperId == id) > 0;
        }
    }
}
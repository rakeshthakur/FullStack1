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
    public class TestDetailsController : ApiController
    {
        private OnlineExamContext db = new OnlineExamContext();

        // GET: api/TestDetails
        public IQueryable<TestDetails> GetTestDetails()
        {
            return db.TestDetails;
        }

        // GET: api/TestDetails/5
        [ResponseType(typeof(TestDetails))]
        public IHttpActionResult GetTestDetails(int id)
        {
            TestDetails testDetails = db.TestDetails.Find(id);
            if (testDetails == null)
            {
                return NotFound();
            }

            return Ok(testDetails);
        }

        // PUT: api/TestDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestDetails(int id, TestDetails testDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testDetails.TestId)
            {
                return BadRequest();
            }

            db.Entry(testDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDetailsExists(id))
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

        // POST: api/TestDetails
        [ResponseType(typeof(TestDetails))]
        public IHttpActionResult PostTestDetails(TestDetails testDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            using(db = new OnlineExamContext())
            {
                TestDetails testDetails2 = new TestDetails
                {
                    UserEmail = testDetails.UserEmail,
                    TestId = testDetails.TestId,
                    PaperId = testDetails.PaperId,
                    Marks = testDetails.Marks,
                    TestDate = DateTime.Now
                };
                db.TestDetails.Add(testDetails2);
                db.SaveChanges();
            }
 //           db.TestDetails.Add(testDetails);
//            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testDetails.TestId }, testDetails);
        }

        // DELETE: api/TestDetails/5
        [ResponseType(typeof(TestDetails))]
        public IHttpActionResult DeleteTestDetails(int id)
        {
            TestDetails testDetails = db.TestDetails.Find(id);
            if (testDetails == null)
            {
                return NotFound();
            }

            db.TestDetails.Remove(testDetails);
            db.SaveChanges();

            return Ok(testDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestDetailsExists(int id)
        {
            return db.TestDetails.Count(e => e.TestId == id) > 0;
        }
    }
}
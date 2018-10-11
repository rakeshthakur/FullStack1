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
    public class UserAnswerDetailsController : ApiController
    {
        private OnlineExamContext db = new OnlineExamContext();

        // GET: api/UserAnswerDetails
        public IQueryable<UserAnswerDetails> GetUserAnswerDetails()
        {
            return db.UserAnswerDetails;
        }

        // GET: api/UserAnswerDetails/5
        [ResponseType(typeof(UserAnswerDetails))]
        public IHttpActionResult GetUserAnswerDetails(int id)
        {
            UserAnswerDetails userAnswerDetails = db.UserAnswerDetails.Find(id);
            if (userAnswerDetails == null)
            {
                return NotFound();
            }

            return Ok(userAnswerDetails);
        }

        // PUT: api/UserAnswerDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAnswerDetails(int id, UserAnswerDetails userAnswerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAnswerDetails.UADId)
            {
                return BadRequest();
            }

            db.Entry(userAnswerDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswerDetailsExists(id))
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

        // POST: api/UserAnswerDetails
        [ResponseType(typeof(UserAnswerDetails))]
        public IHttpActionResult PostUserAnswerDetails(UserAnswerDetails userAnswerDetails)
        {
            int c = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.UserAnswerDetails.Add(userAnswerDetails);
            
          //int qid= userAnswerDetails.QuestionId;
          //  var aid= userAnswerDetails.AnswerId;
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = userAnswerDetails.UADId }, userAnswerDetails);
        }

        // DELETE: api/UserAnswerDetails/5
        [ResponseType(typeof(UserAnswerDetails))]
        public IHttpActionResult DeleteUserAnswerDetails(int id)
        {
            UserAnswerDetails userAnswerDetails = db.UserAnswerDetails.Find(id);
            if (userAnswerDetails == null)
            {
                return NotFound();
            }

            db.UserAnswerDetails.Remove(userAnswerDetails);
            db.SaveChanges();

            return Ok(userAnswerDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAnswerDetailsExists(int id)
        {
            return db.UserAnswerDetails.Count(e => e.UADId == id) > 0;
        }
    }
}
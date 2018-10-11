using Microsoft.AspNet.Identity;
using OnlineExamSystem.Models;
using OnlineExamSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineExamSystem.Controllers
{
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [HttpPost, AllowAnonymous]
        [Route("api/Account/Register")]
        public async Task<IHttpActionResult> Register(Admin admin)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            IdentityResult result = await _repo.RegisterUser(admin);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            //check for result object (if user creation fails)
            if (result == null) { return InternalServerError(); }
            //second check for failed user creation by analysis success status
            if (!result.Succeeded)
            {
                //if creation failed analysing all errors occured in the model
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(" ", error);
                    }
                }
                //if model had no errors but still user creation fails
                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}

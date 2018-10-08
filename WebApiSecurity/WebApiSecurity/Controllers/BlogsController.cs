using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSecurity.Models;

namespace WebApiSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IEnumerable<Blog> blogs = new List<Blog>
        {
            new Blog{ Id = 1, Title = "Blog1", Content="Sample Content 1", AddedBy = "Rakesh", AddedDate = DateTime.Now},
            new Blog{ Id = 2, Title = "Blog2", Content="Sample Content 2", AddedBy = "Rakesh", AddedDate = DateTime.Now},
            new Blog{ Id = 3, Title = "Blog3", Content="Sample Content 3", AddedBy = "Rakesh", AddedDate = DateTime.Now},
            new Blog{ Id = 4, Title = "Blog4", Content="Sample Content 4", AddedBy = "Rakesh", AddedDate = DateTime.Now},
            new Blog{ Id = 5, Title = "Blog5", Content="Sample Content 5", AddedBy = "Rakesh", AddedDate = DateTime.Now}
        };

        [HttpGet("", Name ="ListBlogs")]
        [Authorize]
        public ActionResult<IEnumerable<Blog>> GetBlogs()
        {
            return blogs.ToList();
        }
    }
}
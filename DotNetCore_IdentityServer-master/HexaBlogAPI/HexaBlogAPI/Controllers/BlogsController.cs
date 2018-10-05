using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HexaBlogAPI.Models;
using HexaBlogAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexaBlogAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlogsController : ControllerBase
    {
        private IRepository<Blog> repository;

        public BlogsController(IRepository<Blog> repo)
        {
            this.repository = repo;
        }

        //GET /api/blogs
        [ProducesResponseType(200)]
        [HttpGet("", Name ="ListBlogs")]
        public IEnumerable<Blog> GetBlogs()
        {
            return this.repository.GetAll();
        }

        //GET /api/blogs/{id}
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id:int}", Name ="GetBlog")]
        public async Task<ActionResult<Blog>> GetBlogById(int id)
        {
            var item = await this.repository.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            else
                return item;
        }

        //POST /api/blogs
        /// <summary>
        /// Adds a new blogs to the blogs collection
        /// </summary>
        /// <remarks>
        /// POST /api/blog
        /// Sample data
        /// {
        ///     "title":"Blog title",
        ///     "content":"Blog content",
        ///     "addedBy":"Author email",
        ///     "addedDate":"Posted Date"
        /// }
        /// </remarks>
        /// <param name="blog"></param>
        /// <returns>Newly inserted blog object</returns>
        /// <response code="201">New blog item is created</response>
        /// <response code="400">If invalid blog input object</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]        
        [HttpPost("", Name ="AddBlog")]
        public async Task<ActionResult<Blog>> AddBlog(Blog blog)
        {
            if (blog == null)
            {
                return BadRequest();
            }
            var result = await this.repository.AddAsync(blog);
            return CreatedAtAction("GetBlogById", new { id = result.Id },result);
            
        }

        //PUT /api/blogs/{id}
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPut("{id:int?}", Name ="UpdateBlog")]
        public async Task<ActionResult<Blog>> UpdateBlog(int? id, Blog blog)
        {
            if (id == null) return BadRequest();
            if (id.Value != blog.Id) return NotFound();
            var item = await this.repository.UpdateAsync(id.Value, blog);
            if (item == null)
                return NotFound();
            return item;
        }

        //DELETE /api/blogs/{id}
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id:int?}", Name ="DeleteBlog")]
        public async Task<ActionResult<Blog>> DeleteBlog(int? id)
        {
            if (id == null) return BadRequest();
            var result = await this.repository.DeleteAsync(id.Value);
            if (result == null)
                return NotFound();
            return result;
        }
    }
}
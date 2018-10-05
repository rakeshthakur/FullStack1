using HexaBlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexaBlogAPI.Infrastructure
{
    public class BlogsContext:DbContext
    {
        public BlogsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}

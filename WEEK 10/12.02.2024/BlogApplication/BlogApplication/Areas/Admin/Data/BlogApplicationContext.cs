using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApplication.Models;

namespace BlogApplication.Data
{
    public class BlogApplicationContext : DbContext
    {
        public BlogApplicationContext (DbContextOptions<BlogApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<BlogApplication.Models.Category> Category { get; set; } = default!;
    }
}

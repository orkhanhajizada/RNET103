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

        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
    }
}

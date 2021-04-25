using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Models
{
    public class TestContext:DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Question { get; set; }
        public TestContext(DbContextOptions<TestContext> options):base (options)
        {
            Database.EnsureCreated();
        }
    }
}

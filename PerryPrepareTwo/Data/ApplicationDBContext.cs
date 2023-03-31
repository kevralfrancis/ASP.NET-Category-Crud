using Microsoft.EntityFrameworkCore;
using PerryPrepareTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerryPrepareTwo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }


        public DbSet<Category> categories { get; set; }
    }
}

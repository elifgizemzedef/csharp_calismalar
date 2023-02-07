using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication6.Models;
namespace WebApplication6.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base(nameOrConnectionString:"MyConnection")
        {

        }
        public virtual DbSet<SongClass> Songs { get; set; }
    }
}
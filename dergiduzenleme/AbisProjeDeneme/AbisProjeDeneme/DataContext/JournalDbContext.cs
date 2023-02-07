using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AbisProjeDeneme.DataContext
{
    public class JournalDbContext:DbContext
    {
        public JournalDbContext():base(nameOrConnectionString:"Myconnection")
        {

        }
        public virtual DbSet<JournalDbContext> Journal { get; set; }

        public System.Data.Entity.DbSet<AbisProjeDeneme.Models.JournalClass> Journals { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
       public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
         public DbSet<Visit> Visit{get; set;}
          public DbSet<Visitor> Visitor{get; set;}
         public DbSet<VisitItem> VisitItem{get; set;}  
    }
}
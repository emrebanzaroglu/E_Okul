using E_Okul.Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Dal
{
    public class EOkulContext:DbContext
    {
        public EOkulContext(DbContextOptions<EOkulContext> db) : base(db)
        {
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Branches> Branches { get; set; }
    }
}

using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Liked> Liked { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}

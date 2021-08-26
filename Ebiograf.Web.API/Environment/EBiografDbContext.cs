using EBiograf.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Environment
{
    public class EBiografDbContext : DbContext
    {
        //Ebiograf Db Constructor. Base options Connection string will be set in Statup Class.
        public EBiografDbContext(DbContextOptions<EBiografDbContext> options) : base(options) { }

        //  Migrating Database Table Users into SqlDatabase.
        public DbSet<User> Users { get; set; }


    }
}

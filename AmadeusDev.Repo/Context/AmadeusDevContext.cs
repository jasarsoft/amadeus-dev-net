using System;
using System.Linq;

using Jasarsoft.AmadeusDev.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Jasarsoft.AmadeusDev.Repo.Context
{
    public class AmadeusDevContext : IdentityDbContext<IdentityUser>
    {
        public AmadeusDevContext(DbContextOptions<AmadeusDevContext> options) : base(options) { }

        //public virtual DbSet<Administrator> Administrators { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

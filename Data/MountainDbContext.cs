using Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data
{
    public class MountainDbContext : DbContext
    {

        public MountainDbContext(DbContextOptions<MountainDbContext> options) : base(options)
        {

        }

        public DbSet<MountainInfo> Mountains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            List<MountainInfo> mountains = MountainSeeder.GetMountainInfos();
            int mountainIndex = 1;
            mountains.ForEach(mnt =>
            {
                mnt.Id = mountainIndex;
                mountainIndex++;
                modelBuilder.Entity<MountainInfo>().HasData(mnt);
            });
        }


    }
}

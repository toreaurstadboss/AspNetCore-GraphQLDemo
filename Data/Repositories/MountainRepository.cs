using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
   
    public class MountainRepository : IMountainRepository
    {
        private readonly DbContextOptions<MountainDbContext> _options;

        public MountainRepository(DbContextOptions<MountainDbContext> options) 
        {
            _options = options;
        }


        public async Task<IEnumerable<MountainInfo>> GetAll()
        {
            using (var dbContext = new MountainDbContext(_options))
            {
                var mountains = await dbContext.Mountains.ToListAsync();              
                return mountains;
            }
        }

        public async Task<MountainInfo> AddMountain(MountainInfo mountain)
        {
            using (var dbContext = new MountainDbContext(_options))
            {
                //Correct the altimeter data 
                mountain.CalculatedMetresAboveSeaLevel = mountain.CalculateMetresAboveSeaLevel;
                mountain.CalculatedPrimaryFactor = mountain.CalculatePrimaryFactor;
                dbContext.Mountains.Add(mountain);
                await dbContext.SaveChangesAsync();
                return mountain; 
            }
        }

        public async Task<bool> RemoveMountain(int id)
        {
            using (var dbContext = new MountainDbContext(_options))
            {
                try
                {
                    var mountainToDelete = dbContext.Mountains.Single(x => x.Id == id);
                    dbContext.Mountains.Remove(mountainToDelete);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }

        public async Task<MountainInfo> GetById(int id)
        {
            using (var dbContext = new MountainDbContext(_options))
            {
                try
                {
                    var mountain = dbContext.Mountains.Single(x => x.Id == id);
                    return await dbContext.Mountains.SingleOrDefaultAsync(x => x.Id == id);

                }
                catch (Exception e)
                {
                    return null;
                }
            }
            
        }

    }

}

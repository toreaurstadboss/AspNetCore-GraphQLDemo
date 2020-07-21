using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    }

}

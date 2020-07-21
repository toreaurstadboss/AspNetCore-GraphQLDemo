using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
   
    public class MountainRepository : IMountainRepository
    {
        private readonly DbContextOptions<MountainDbContext> options;

        public MountainRepository(DbContextOptions<MountainDbContext> options) 
        {
            this.options = options;
        }


        public async Task<IEnumerable<MountainInfo>> GetAll()
        {
            using (var dbContext = new MountainDbContext(options))
            {
                var mountains = await dbContext.Mountains.ToListAsync();              
                return mountains;
            }
        }

    }

}

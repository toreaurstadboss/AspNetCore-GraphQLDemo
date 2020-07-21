using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IMountainRepository
    {
        Task<IEnumerable<MountainInfo>> GetAll();
    }
}
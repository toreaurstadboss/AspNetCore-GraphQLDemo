using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IMountainRepository
    {
        Task<IEnumerable<MountainInfo>> GetAll();
        Task<MountainInfo> AddMountain(MountainInfo mountain);
        Task<bool> RemoveMountain(int id);
        Task<MountainInfo> GetById(int id);

    }
}
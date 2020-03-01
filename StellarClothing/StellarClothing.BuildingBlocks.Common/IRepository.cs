using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellarClothing.BuildingBlocks.Domain
{
    public interface IRepository<T>
    {
        Task Add(T prod);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(int id);

        Task Delete(int id);

        Task Update(T prod);
    }
}

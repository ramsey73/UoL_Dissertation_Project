using StellarClothing.Admin.Api.Domain;
using System.Linq;

namespace StellarClothing.Admin.Api.Interface
{
    public interface IOptionsRepository
    {
        IQueryable<Option> GetResults(int pollId);
    }
}

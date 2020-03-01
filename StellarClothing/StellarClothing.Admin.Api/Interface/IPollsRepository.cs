using StellarClothing.Admin.Api.Domain;

namespace StellarClothing.Admin.Api.Interface
{
    public interface IPollsRepository
    {
        Poll GetActivePoll();
    }
}

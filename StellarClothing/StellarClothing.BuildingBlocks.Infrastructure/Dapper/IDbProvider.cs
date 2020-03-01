using System.Data;

namespace StellarClothing.BuildingBlocks.Infrastructure.Dapper
{
    public interface IDbProvider
    {
        IDbConnection Connection { get; }
    }
}

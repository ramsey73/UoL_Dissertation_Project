namespace StellarClothing.BuildingBlocks.Domain
{
    public interface IIdentity<T>
    {
        T Id { get; }
    }
}

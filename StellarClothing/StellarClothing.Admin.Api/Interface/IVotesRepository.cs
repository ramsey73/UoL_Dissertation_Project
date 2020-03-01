namespace StellarClothing.Admin.Api.Interface
{
    public interface IVotesRepository
    {
        bool HasAlreadyVoted(string userId, int pollId);
        void Vote(int optionId, int pollId, string userId);
    }
}

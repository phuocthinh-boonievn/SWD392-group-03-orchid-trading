using Domain.Entities;

namespace Application.Interfaces.Auctions
{
    public interface IAuctionRepository
    {
        Task<int> Insert(Aution aution);
        Task RegisterBid(float bid, int auctionId, int userId);
    }
}

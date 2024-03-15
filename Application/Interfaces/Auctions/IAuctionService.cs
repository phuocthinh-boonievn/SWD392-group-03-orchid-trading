using Application.Common.Dto.Auction;

namespace Application.Interfaces.Auctions
{
    public interface IAuctionService
    {
        Task RegisterAuction(CreateAuctionDto createAuctionDto);
        Task RegisterBid(RegisterBidDto requestDto);
    }
}

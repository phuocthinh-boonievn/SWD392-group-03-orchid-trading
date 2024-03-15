namespace Application.Common.Dto.Auction
{
    public class RegisterBidDto
    {
        public float Bid { get; set; }
        public int UserId { get; set; }
        public int auctionId { get; set; }
    }
}

namespace Application.Common.Dto.Auction
{
    public class CreateAuctionDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float StartingBid { get; set; }
        public float MaxBid { get; set; }
        public string DateOpen { get; set; }
        public string DateClose { get; set; }
        public int UserId { get; set; }
    }
}

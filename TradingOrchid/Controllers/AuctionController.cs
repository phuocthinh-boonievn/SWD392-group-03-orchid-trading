using Application.Common.Dto.Exception;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Auctions;
using Application.Common.Dto.Auction;
using Microsoft.AspNetCore.Authorization;

namespace TradingOrchid.Controllers
{
    [Route("trading-orchid/[controller]")]
    [Authorize(Roles = "Customer")]
    public class AuctionController : Controller
    {
        private readonly IAuctionService auctionService;
        public AuctionController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        [HttpPost("create-auction")]
        public async Task<IActionResult> RegisterAuction([FromBody] CreateAuctionDto requset)
        {
            await auctionService.RegisterAuction(requset);
            throw new MyException("Thành công.", 200);
        }

        [HttpPut("register-bid")]
        public async Task<IActionResult> RegisterBid([FromBody] RegisterBidDto requset)
        {
            await auctionService.RegisterBid(requset);
            throw new MyException("Thành công.", 200);
        }
    }
}

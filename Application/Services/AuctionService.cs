using Application.Common.Dto.Auction;
using Application.Common.Dto.Exception;
using Application.Interfaces.Auctions;
using Application.Interfaces.Informations;
using AutoMapper;
using Domain.Entities;
using System.Globalization;

namespace Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly IInformationRepository informationRepository;
        private readonly IMapper mapper;

        public AuctionService
            (IAuctionRepository auctionRepository, IMapper mapper,
            IInformationRepository informationRepository)
        {
            this.auctionRepository = auctionRepository;
            this.informationRepository = informationRepository;
            this.mapper = mapper;
        }
        
        public async Task RegisterBid(RegisterBidDto requestDto)
        {
            try
            {
                await auctionRepository.RegisterBid
                    (requestDto.Bid, requestDto.auctionId, requestDto.UserId);
            }
            catch
            {
                throw;
            }
        }

        public async Task RegisterAuction(CreateAuctionDto requestDto)
        {
            try
            {
                DateTime expectedDate;
                string[] formats = { "dd/MM/yyyy" };

                if (requestDto.StartingBid > requestDto.MaxBid)
                {
                    throw new MyException("Giá cao nhất không được thấp hơn giá khởi điểm.", 404);
                }else if(requestDto.StartingBid < 0 
                    || requestDto.MaxBid < 0)
                {
                    throw new MyException("Giá cao nhất và giá khởi điểm không được âm.", 404);
                }else if(!DateTime.TryParseExact
                    (requestDto.DateOpen, formats, new CultureInfo("en-US"),
                    DateTimeStyles.None, out expectedDate) ||
                    !DateTime.TryParseExact
                    (requestDto.DateClose, formats, new CultureInfo("en-US"),
                    DateTimeStyles.None, out expectedDate))
                {
                    throw new MyException("Định dạng ngày tháng năm yêu cầu: dd/MM/yyyy.", 404);
                }

                var auction = mapper.Map<Aution>(requestDto);
                var auctionId = await auctionRepository.Insert(auction);
                var information = mapper.Map<Information>(requestDto);
                information.AutionID = auctionId;
                await informationRepository.Insert(information);
            }
            catch
            {
                throw;
            }
        }
    }
}

using Application.Common.Dto.Exception;
using Application.Common.Dto.Information;
using Application.Common.Dto.Page;
using Application.Interfaces.Informations;
using AutoMapper;

namespace Application.Services
{
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository informationRepository;
        private readonly IMapper mapper;
        public InformationService
            (IInformationRepository informationRepository, IMapper mapper)
        {
            this.informationRepository = informationRepository;
            this.mapper = mapper;
        }

        public async Task<List<InformationViewDTO>> GetAll(PageDto page)
        {
            try
            {
                var list = mapper.Map<List<InformationViewDTO>>
                    (await informationRepository.GetAll(page));
                return list;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> GetByUserId(PageDto page, int userId)
        {
            try
            {
                var list = mapper.Map<List<InformationViewDTO>>
                    (await informationRepository.GetByUserId(page, userId));
                return list;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> GetByBeingRegiter(PageDto page, int userId)
        {
            try
            {
                var list = mapper.Map<List<InformationViewDTO>>
                    (await informationRepository.GetByBeingRegiter(page, userId));
                return list;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> GetByID(int id)
        {
            try
            {
                var information = mapper.Map<List<InformationViewDTO>>
                    (await informationRepository.GetByID(id));
                return information;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> Search(string search)
        {
            try
            {
                var information = mapper.Map<List<InformationViewDTO>>
                    (await informationRepository.Search(search));
                return information;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }
    }
}

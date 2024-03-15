using Application.Common.Dto.Information;
using Application.Common.Dto.Page;

namespace Application.Interfaces.Informations
{
    public interface IInformationService
    {
        Task<List<InformationViewDTO>> GetByUserId(PageDto page, int userId);

        Task<List<InformationViewDTO>> GetByBeingRegiter(PageDto page, int userId);

        Task<List<InformationViewDTO>> GetAll(PageDto page);

        Task<List<InformationViewDTO>> GetByID(int id);

        Task<List<InformationViewDTO>> Search(string search);

    }
}

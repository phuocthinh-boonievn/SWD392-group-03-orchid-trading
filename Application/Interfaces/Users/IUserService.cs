using Application.Common.Dto.Authen;
using Application.Common.Dto.Page;
using Application.Common.Dto.User;
using Domain.Entities;

namespace Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<Token> Login(LoginDto loginDto);

        Task Register(RegisterDto registerDto);

        Task<List<ViewInformationUserDTO>> GetAll(PageDto page);

        Task<List<ViewInformationUserDTO>> Search(string search);

        Task Edit(int id);

        Task Delete(int id);
    }
}

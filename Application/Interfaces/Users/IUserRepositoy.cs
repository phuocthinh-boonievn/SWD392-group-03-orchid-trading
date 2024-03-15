using Application.Common.Dto.Page;
using Application.Common.Dto.Role;
using Application.Common.Dto.User;
using Domain.Entities;

namespace Application.Interfaces.Users
{
    public interface IUserRepositoy
    {
        Task<User> GetUserByEmail(string email);

        Task<List<User>> GetAll(PageDto page);

        Task<List<User>> Search(string search);

        Task<User> FindIDToResult(int id);

        Task Update(User user);

        Task Delete(User user);

        Task Create(User user);
    }
}

using Application.Common.Dto.Page;
using Application.Common.Paging;
using Application.Interfaces.Users;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace Infrastructure.Repositories
{
    public class UserRepositoy : IUserRepositoy
    {
        private readonly TradingOrchidContext context;
        public UserRepositoy(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch
            {
                throw;
            }
        }

        public async Task Create(User user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<User>> GetAll(PageDto page)
        {
            try
            {
                var query = context.Users.AsQueryable();

                return await PagingConfiguration<User>
                    .Get(query.Include(u => u.Role), page);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<User>> Search(string search)
        {
            try
            {
                return await context.Users
                    .Where(u => u.UserName.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                u.Email.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                u.Phone.Trim().ToLower().Contains(search.Trim().ToLower()))
                    .Include(u => u.Role)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<User> FindIDToResult(int id)
        {
            try
            {
                return await context.Users.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(User user)
        {
            try
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

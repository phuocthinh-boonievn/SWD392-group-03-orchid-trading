using Application.Common.Dto.Role;
using Application.Interfaces.Roles;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TradingOrchidContext context;
        public RoleRepository(TradingOrchidContext context)
        {
            this.context = context;
        }

        public async Task CreateRole(RoleDTO roleDTO)
        {
            try
            {
                Role role = new Role();
                role.RoleName = roleDTO.RoleName;

                context.Roles.Add(role);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRole(int id)
        {
            try
            {
                var list = context.Roles.FirstOrDefault(r => r.RoleID == id);

                context.Remove(list);
                await context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task EditRole(int id, RoleDTO roleDTO)
        {
            try
            {
                var list = context.Roles.FirstOrDefault(r => r.RoleID == id);

                // Thiếu điều kiện check

                list.RoleName = roleDTO.RoleName;

                context.Roles.Update(list);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Role> FindIDToResult(int id)
        {
            try
            {
                return await context.Roles.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Role>> GetAll()
        {
            try
            {
                return await context.Roles
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Role>> GetRoleByID(int id)
        {
            try
            {
                return await context.Roles
                    .Where(r => r.RoleID == id)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Role>> GetRoleByName(string roleName)
        {
            try
            {
                return await context.Roles
                    .Where(r => r.RoleName.Trim().ToLower().Contains(roleName.Trim().ToLower()))
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

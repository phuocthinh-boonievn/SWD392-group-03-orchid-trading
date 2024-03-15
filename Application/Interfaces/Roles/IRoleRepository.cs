using Application.Common.Dto.Role;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Roles
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll();

        Task<List<Role>> GetRoleByID(int id);

        Task<Role> FindIDToResult(int id);

        Task<List<Role>> GetRoleByName(string roleName);

        Task CreateRole(RoleDTO roleDTO);

        Task EditRole(int id, RoleDTO roleDTO);

        Task DeleteRole(int id);
    }
}

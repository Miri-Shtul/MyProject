using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllAsync();
        Task<RoleDTO> GetByIdAsync(int id);
        Task<RoleDTO> AddAsync(int id, string name, string description);
        Task<RoleDTO> UpdateAsync(RoleDTO role);
        Task DeleteAsync(int id);
    }
}

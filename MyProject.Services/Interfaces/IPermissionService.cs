using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IPermissionService
    {
      
        Task<List<PermissionDTO>> GetAllAsync();

        Task<PermissionDTO> GetByIdAsync(int id);
        Task<PermissionDTO> AddAsync(int id, string name, string description);
        Task<PermissionDTO> UpdateAsync(PermissionDTO permission);

        Task deleteAsync(int id);
    }
}

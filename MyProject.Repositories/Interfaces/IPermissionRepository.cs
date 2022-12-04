using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
   public  interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync();

        Task<Permission> GetByIdAsync(int id);

        Task<Permission> AddAsync(int id, string name, string description);

        Task<Permission> UpdateAsync(Permission permission);

        Task DeleteAsync(int id);
    }
}

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

        Task<Permission> GetByIdeAsync(int id);

        Task<Permission> AddeAsync(int id, string name, string description);

        Task<Permission> UpdateeAsync(Permission permission);

        Task DeleteAsync(int id);
    }
}

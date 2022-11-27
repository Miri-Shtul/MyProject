using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();

        Task<Role> GetByIdAsync(int id);

        Task<Role> AddAsync(int id, string name, string description);

        Task<Role> UpdateAsync(Role role);

        Task DeleteAsync(int id);
    }
}

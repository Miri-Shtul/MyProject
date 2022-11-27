using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{

    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Role> AddAsync(int id, string name, string description)
        {
            var r= _context.Roles.Add(new Role {Id= id,Name= name,Description= description });
            await _context.SaveChangesAsync();
            return r.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Roles.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var r = await GetByIdAsync(role.Id);
            r.Name = role.Name;
            r.Description = role.Description;
            await _context.SaveChangesAsync();
            return r;
        }
    }
}

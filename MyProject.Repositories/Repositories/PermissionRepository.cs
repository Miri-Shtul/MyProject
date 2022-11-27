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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;

        public PermissionRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Permission> AddAsync(int id, string name, string description)
        {
           var p = _context.Permissions.Add( new Permission (){ Id = id, Name = name, Description = description });
            await _context.SaveChangesAsync();
            return p.Entity;
        }
    

        public async Task DeleteAsync(int id)
        {
            _context.Permissions.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }
        public async Task<Permission> UpdateAsync(Permission permission)
        {
            var p =await GetByIdAsync(permission.Id);
            p.Name = permission.Name;
            p.Description = permission.Description;
            await _context.SaveChangesAsync();
            return p;
        }
    }
}

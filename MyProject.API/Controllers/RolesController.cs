using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {

            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<List<Role>> Get()
        {
            return await _roleRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Role> Get(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
        [HttpPut]
       
        public async Task Put([FromBody] Role role)
        {
           await _roleRepository.UpdateAsync(role);
        }
    }
}

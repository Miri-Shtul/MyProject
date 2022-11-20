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
        public List<Role> Get()
        {
            return _roleRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return _roleRepository.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }
        [HttpPut]
       
        public void Put([FromBody] Role role)
        {
            _roleRepository.Update(role);
        }
    }
}

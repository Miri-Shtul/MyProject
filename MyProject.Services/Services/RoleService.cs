using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
   public  class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public PermissionDTO GetById(int id)
        {
            return _mapper.Map<PermissionDTO>(_roleRepository.GetById(id));
        }

        public List<PermissionDTO> GetList()
        {
            return _mapper.Map<List<PermissionDTO>>(_roleRepository.GetAll());
        }
    }
}

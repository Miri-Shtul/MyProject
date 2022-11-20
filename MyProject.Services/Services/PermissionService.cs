using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
   public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public PermissionDTO GetById(int id)
        {
            return _mapper.Map<PermissionDTO>(_permissionRepository.GetById(id));
        }
        public List<PermissionDTO> GetList()
        {
            return _mapper.Map<List<PermissionDTO>>(_permissionRepository.GetAll());
        }
    }
}

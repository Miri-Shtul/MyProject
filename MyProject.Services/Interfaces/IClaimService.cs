﻿using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    interface IClaimService
    {
        List<ClaimDTO> GetList();
        ClaimDTO GetById(int id);
    }
}
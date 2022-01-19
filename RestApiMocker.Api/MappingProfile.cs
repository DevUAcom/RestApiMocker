﻿using AutoMapper;
using RestApiMocker.Api.CQRS.Commands;
using RestApiMocker.Api.Models;
using RestApiMocker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestApiMocker.Api.CQRS.Commands.CreateRuleCommand;

namespace RestApiMocker.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRuleCommand, AppRule>();
            CreateMap<ResponseHeaderDto, ResponseHeader>();
        }
    }
}

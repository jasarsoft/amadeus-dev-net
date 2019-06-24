﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Entities;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Service.IService;

namespace Jasarsoft.AmadeusDev.Service.Service
{
    public class LinksService : ILinksService
    {
        private readonly IUnitOfWork unitOfWork;

        public LinksService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


    }
}
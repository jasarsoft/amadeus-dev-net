﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IPriceRepository : IRepository<Price, int>
    {
        int Insert(Price model);

        Task<int> InsertAsync(Price model);
    }
}

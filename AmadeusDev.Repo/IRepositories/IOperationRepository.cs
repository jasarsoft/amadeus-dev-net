﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IOperationRepository : IRepository<Operation, int>
    {
        int Insert(Operation model);

        Task<int> InsertAsync(Operation model);
    }
}

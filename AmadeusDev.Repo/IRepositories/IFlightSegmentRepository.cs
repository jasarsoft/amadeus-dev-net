﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightSegmentRepository : IRepository<FlightSegment, int>
    {
        int Insert(FlightSegment model);

        Task<int> InsertAsync(FlightSegment model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ICarrierRepository : IRepository<Carrier, int>
    {
        int Insert(KeyValuePair<string, string> model);
        Carrier FindByCode(string code);
        Carrier FindByCode(Carrier carrier);
    }
}

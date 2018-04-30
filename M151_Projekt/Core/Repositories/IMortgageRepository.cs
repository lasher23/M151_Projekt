using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M151_Projekt.Models;

namespace M151_Projekt.Core.Repositories
{
    public interface IMortgageRepository : IRepository<Mortgage>
    {
        List<Mortgage> GetByCustomer(int id);
    }
}
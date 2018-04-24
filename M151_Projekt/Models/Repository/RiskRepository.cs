using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using M151_Projekt.Core.Repositories;

namespace M151_Projekt.Models
{
    public class RiskRepository : Repository<Risk>, IRiskRepository
    {
        public RiskRepository(DbContext context) : base(context)
        {
        }        
    }
}
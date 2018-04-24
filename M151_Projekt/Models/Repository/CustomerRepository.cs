using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using M151_Projekt.Core.Repositories;

namespace M151_Projekt.Models.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
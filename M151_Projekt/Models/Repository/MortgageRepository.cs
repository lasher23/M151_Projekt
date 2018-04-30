using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using M151_Projekt.Core.Repositories;

namespace M151_Projekt.Models.Repository
{
    public class MortgageRepository : Repository<Mortgage>, IMortgageRepository
    {
        public MortgageRepository(DbContext context) : base(context)
        {
        }

        public List<Mortgage> GetByCustomer(int id)
        {
            return  Context.Set<MortgageCustomerAssignment>().Where(x => x.Customer.id == id).Select(x => x.Mortgage).ToList();
        }

        private static bool B(int id, MortgageCustomerAssignment y, Mortgage x)
        {
            return y.fk_mortgage.Equals(x.id) && y.fk_customer.Equals(id);

        }
    }
}
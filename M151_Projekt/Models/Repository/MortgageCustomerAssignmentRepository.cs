using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using M151_Projekt.Core.Repositories;

namespace M151_Projekt.Models.Repository
{
    public class MortgageCustomerAssignmentRepository : Repository<MortgageCustomerAssignment>, IMortgageCustomerAssignmentRepository
    {
        public MortgageCustomerAssignmentRepository(DbContext context) : base(context)
        {
        }
    }
}
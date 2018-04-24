using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using M151_Projekt.Core;
using M151_Projekt.Core.Repositories;
using M151_Projekt.Models.Repository;

namespace M151_Projekt.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            Risks = new RiskRepository(context);
            Customers = new CustomerRepository(context);
            Mortgages = new MortgageRepository(context);
            MortgageCustomerAssignments = new MortgageCustomerAssignmentRepository(context);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IRiskRepository Risks { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IMortgageRepository Mortgages { get; private set; }
        public IMortgageCustomerAssignmentRepository MortgageCustomerAssignments { get; private set; }

        public int Complete()
        {
            return this.context.SaveChanges();
        }
    }
}
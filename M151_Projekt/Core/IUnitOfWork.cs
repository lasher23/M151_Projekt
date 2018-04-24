using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M151_Projekt.Core.Repositories;

namespace M151_Projekt.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRiskRepository Risks { get; }
        ICustomerRepository Customers { get;  }

        IMortgageRepository Mortgages{ get; }

        IMortgageCustomerAssignmentRepository MortgageCustomerAssignments { get; }

        int Complete();
    }
}
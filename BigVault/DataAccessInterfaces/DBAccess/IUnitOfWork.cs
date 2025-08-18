using DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    public interface IUnitOfWork : IDisposable {
        IUserRepository Users { get; }
        IGroupRepository Groups { get; }
        ISecretRepository Secrets { get; }
        Task<int> SaveChangesAsync ();
    }
}

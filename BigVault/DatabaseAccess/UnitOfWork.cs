using DataAccessInterfaces;
using DatabaseAccess.Data;
using DatabaseAccess.Interfaces;
using DatabaseAccess.Repositories;

namespace DatabaseAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository? _users;
        private IGroupRepository? _groups;
        private ISecretRepository? _secrets;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IGroupRepository Groups => _groups ??= new GroupRepository(_context);
        public ISecretRepository Secrets => _secrets ??= new SecretRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
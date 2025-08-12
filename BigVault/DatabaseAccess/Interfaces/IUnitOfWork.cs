namespace DatabaseAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IGroupRepository Groups { get; }
        ISecretRepository Secrets { get; }
        Task<int> SaveChangesAsync();
    }
}
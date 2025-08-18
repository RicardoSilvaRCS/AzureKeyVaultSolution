using DatabaseAccess.Models;

namespace DatabaseAccess.Interfaces
{
    public interface ISecretRepository : IGenericRepository<Secret>
    {
        Task<IEnumerable<Group>> GetSecretGroupsAsync(Guid secretId);
        Task<IEnumerable<Secret>> GetAllSecrets ();
    }
}
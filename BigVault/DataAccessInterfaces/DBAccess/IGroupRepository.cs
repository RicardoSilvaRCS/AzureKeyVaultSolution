using DatabaseAccess.Models;

namespace DatabaseAccess.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<IEnumerable<User>> GetGroupUsersAsync(Guid groupId);
        Task<IEnumerable<Secret>> GetGroupSecretsAsync(Guid groupId);
        Task AddSecretToGroupAsync(Guid groupId, Guid secretId);
        Task RemoveSecretFromGroupAsync(Guid groupId, Guid secretId);
    }
}
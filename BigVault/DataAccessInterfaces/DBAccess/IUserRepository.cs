using DatabaseAccess.Models;

namespace DatabaseAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<Group>> GetUserGroupsAsync(Guid userId);
        Task AddToGroupAsync(Guid userId, Guid groupId);
        Task RemoveFromGroupAsync(Guid userId, Guid groupId);
    }
}
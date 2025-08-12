using DatabaseAccess.Data;
using DatabaseAccess.Interfaces;
using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetGroupUsersAsync(Guid groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Users)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);
            
            return group?.Users ?? new List<User>();
        }

        public async Task<IEnumerable<Secret>> GetGroupSecretsAsync(Guid groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Secrets)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);
            
            return group?.Secrets ?? new List<Secret>();
        }

        public async Task AddSecretToGroupAsync(Guid groupId, Guid secretId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            var secret = await _context.Secrets.FindAsync(secretId);

            if (group != null && secret != null)
            {
                group.Secrets.Add(secret);
            }
        }

        public async Task RemoveSecretFromGroupAsync(Guid groupId, Guid secretId)
        {
            var group = await _context.Groups
                .Include(g => g.Secrets)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);
            var secret = await _context.Secrets.FindAsync(secretId);

            if (group != null && secret != null)
            {
                group.Secrets.Remove(secret);
            }
        }
    }
}
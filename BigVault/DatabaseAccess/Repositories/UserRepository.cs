using DatabaseAccess.Data;
using DatabaseAccess.Interfaces;
using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Group>> GetUserGroupsAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Groups)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            
            return user?.Groups ?? new List<Group>();
        }

        public async Task AddToGroupAsync(Guid userId, Guid groupId)
        {
            var user = await _context.Users.FindAsync(userId);
            var group = await _context.Groups.FindAsync(groupId);

            if (user != null && group != null)
            {
                user.Groups.Add(group);
            }
        }

        public async Task RemoveFromGroupAsync(Guid userId, Guid groupId)
        {
            var user = await _context.Users
                .Include(u => u.Groups)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            var group = await _context.Groups.FindAsync(groupId);

            if (user != null && group != null)
            {
                user.Groups.Remove(group);
            }
        }
    }
}
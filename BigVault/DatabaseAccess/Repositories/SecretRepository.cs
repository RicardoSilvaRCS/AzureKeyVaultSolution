using DatabaseAccess.Data;
using DatabaseAccess.Interfaces;
using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Repositories
{
    public class SecretRepository : GenericRepository<Secret>, ISecretRepository {
        public SecretRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Group>> GetSecretGroupsAsync(Guid secretId)
        {
            var secret = await _context.Secrets
                .Include(s => s.Groups)
                .FirstOrDefaultAsync(s => s.SecretId == secretId);
            
            return secret?.Groups ?? new List<Group>();
        }

        public async Task<IEnumerable<Secret>> GetAllSecrets () {
            // Assuming _context is the database context injected into the repository
            return await _context.Secrets.ToListAsync();
        }
    }
}
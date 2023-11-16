using Entities.ApplicationDbCon;
using Entities.Models;

namespace Repositories
{
	public class UserRepository : RepositoryBase<ApplicationUser>
	{
        public async Task<bool> DeleteUserAsync(ApplicationUser user)
		{
			var userDelete = await this.GetByIdAsync(user.Id);
			if (userDelete == null)
			{
				return false;
			}
			userDelete.IsDeleted = true;
			await _context.SaveChangesAsync();

			return true;
		}
        public async Task<bool> RecoveryUserAsync(ApplicationUser user)
        {
            var userRecover = await this.GetByIdAsync(user.Id);
            if (userRecover == null)
            {
                return false;
            }
            userRecover.IsDeleted = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

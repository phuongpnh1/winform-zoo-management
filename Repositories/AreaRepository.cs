using Entities.Models;

namespace Repositories
{
    public class AreaRepository : RepositoryBase<Area>
    {
		public async Task<bool> DeleteUserAsync(Area area)
		{
			var areaDelete = await this.GetByIdAsync(area.Id);
			if (areaDelete == null)
			{
				return false;
			}
			areaDelete.IsDeleted = true;
			await _context.SaveChangesAsync();

			return true;
		}
        public async Task<bool> RecoveryUserAsync(Area area)
        {
            var areaRecover = await this.GetByIdAsync(area.Id);
            if (areaRecover == null)
            {
                return false;
            }
            areaRecover.IsDeleted = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
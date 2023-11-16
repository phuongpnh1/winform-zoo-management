using Entities.Models;

namespace Repositories
{
    public class CageRepository : RepositoryBase<Cage>
    {
		public async Task<bool> DeleteCageAsync(Cage cage)
		{
			var cageDelete = await this.GetByIdAsync(cage.Id);
			if (cageDelete == null)
			{
				return false;
			}
			cageDelete.IsDeleted = true;
			await _context.SaveChangesAsync();

			return true;
		}
	}
}
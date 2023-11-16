using Entities.Models;

namespace Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>
    {
		public async Task<bool> DeleteUserAsync(Animal animal)
		{
			var animalDelete = await this.GetByIdAsync(animal.Id);
			if (animalDelete == null)
			{
				return false;
			}
			animalDelete.IsDelete = true;
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> RecoveryUserAsync(Animal animal)
		{
			var animalRecover = await this.GetByIdAsync(animal.Id);
			if (animalRecover == null)
			{
				return false;
			}
			animalRecover.IsDelete = false;
			await _context.SaveChangesAsync();

			return true;
		}
	}
}
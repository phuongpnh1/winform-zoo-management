using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Entities.Models.EntitiesBase;

namespace Entities.Models
{
	public class Cage : IEntity
	{
		[NotNull]
		[StringLength(50)]
		public string CageName { get; set; } = string.Empty;

		[NotNull]
		public int AreaId { get; set; }

		public bool IsDeleted { get; set; } = false;

		public virtual Area? Area { get; set; }
		public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
	}
}

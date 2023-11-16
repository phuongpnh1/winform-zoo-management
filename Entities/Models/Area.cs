using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Entities.Models.EntitiesBase;

namespace Entities.Models
{
	public class Area : IEntity
	{
		[NotNull]
		[StringLength(50)]
		public string Name { get; set; } = string.Empty;

		public bool IsDeleted { get; set; } = false;

		public virtual ICollection<Cage> Cages { get; set; } = new List<Cage>();
	}
}

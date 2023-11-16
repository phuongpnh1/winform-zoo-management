using Entities.Models.EntitiesBase;

namespace Entities.Models
{
    public class Animal : IEntity
    {
        public string? AnimalName { get; set; }
        public string? Species { get; set; }
        
        public int Age { get; set; }
        public bool IsDelete { get; set; } = false;
        public int CageId { get; set; }
        public virtual Cage? Cage { get; set; }
    }
}

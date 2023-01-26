using Lumia.Models.Base;

namespace Lumia.Models
{
    public class Employee:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}

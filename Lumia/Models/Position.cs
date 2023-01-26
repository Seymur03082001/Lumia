using Lumia.Models.Base;

namespace Lumia.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}

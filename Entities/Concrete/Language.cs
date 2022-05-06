using Core.Entites;

namespace Entites.Concrete
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
    }
}

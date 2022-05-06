using Core.Entites;

namespace Entites.Concrete
{
    public class CategoryTranslation : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}

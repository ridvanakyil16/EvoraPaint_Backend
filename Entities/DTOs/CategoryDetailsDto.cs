using Core.Entites;
using Entites.Concrete;

namespace Entites.DTOs
{
    public class CategoryDetailsDto : CategoryTranslation, IDto
    {
        public int Id { get; set; }
    }
}

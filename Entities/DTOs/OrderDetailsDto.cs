using Core.Entites;
using Entites.Concrete;

namespace Entites.DTOs
{
    public class OrderDetailsDto : IEntity
    {
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductImage { get; set; }
        public string CategoryTRName { get; set; }
        public string CategoryENName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Name { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}

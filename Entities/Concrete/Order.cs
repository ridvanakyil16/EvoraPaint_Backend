using Core.Entites;

namespace Entites.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public short UnitAmount { get; set; }
        public string SenderNameSurname { get; set; }
        public string SenderMail { get; set; }
        public string SenderPhone { get; set; }
    }

}

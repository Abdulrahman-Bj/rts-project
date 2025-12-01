namespace Domain.Entities
{
    public class HotelImage
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public Hotel Hotel { get; set; }
    }
}
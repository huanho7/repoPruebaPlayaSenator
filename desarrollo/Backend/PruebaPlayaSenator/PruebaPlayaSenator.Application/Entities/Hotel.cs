using System.Collections.Generic;

namespace PruebaPlayaSenator.Application.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public int IdCity { get; set; }
        public City City { get; set; }
        public int IdRelevance { get; set; }
        public Relevance Relevance { get; set; }
        public ICollection<HotelXCharacteristic> HotelXCharacteristic { get; set; }
        public string ShortImageTitle { get; set; }
        public byte[] ShortImageData { get; set; }
        public string LargeImageTitle { get; set; }
        public byte[] LargeImageData { get; set; }
    }
}

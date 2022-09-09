using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.Dto
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public int IdCity { get; set; }
        public int IdRelevance { get; set; }
        public string ShortImageTitle { get; set; }
        public byte[] ShortImageData { get; set; }
        public string LargeImageTitle { get; set; }
        public byte[] LargeImageData { get; set; }
    }
}

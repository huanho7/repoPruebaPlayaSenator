using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaPlayaSenator.Application.Dto
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public int IdCity { get; set; }
        public string CityName { get; set; }
        public int IdRelevance { get; set; }
        public string RelevanceName { get; set; }
        public string ShortImageTitle { get; set; }
        public byte[] ShortImageData { get; set; }
        public string LargeImageTitle { get; set; }
        public byte[] LargeImageData { get; set; }

        public List<CharacteristicDto> listaCaracteristicas { get; set; }
    }
}

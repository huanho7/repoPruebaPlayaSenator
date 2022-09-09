using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.Entities
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HotelXCharacteristic> HotelXCharacteristic { get; set; }
    }
}

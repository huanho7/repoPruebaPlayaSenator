using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.Entities
{
    public class HotelXCharacteristic
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public Hotel Hotel { get; set; }
        public int IdCharacteristic { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}

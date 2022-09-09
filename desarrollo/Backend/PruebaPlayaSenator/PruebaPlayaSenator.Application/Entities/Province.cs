using System.Collections.Generic;

namespace PruebaPlayaSenator.Application.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public int IdCountry { get; set; }
        public Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}

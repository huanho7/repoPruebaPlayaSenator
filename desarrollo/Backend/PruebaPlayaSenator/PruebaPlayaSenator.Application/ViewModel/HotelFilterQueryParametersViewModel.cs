using PruebaPlayaSenator.Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.ViewModel
{
    public class HotelFilterQueryParametersViewModel
    {
        public string FilterName { get; set; }
        public bool? FilterTop { get; set; }
        public PaginationOptions PagOptions { get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPlayaSenator.Application.Shared
{
    public class PaginationOptions
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItemsCount { get; set; }
        public int CurrentItemsCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}

using System.Collections.Generic;

namespace Backend.Common
{
    public class PagedList<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int TotalItems { get; set; }

        public PagedList(IEnumerable<T> list, int totalItems)
        {
            List = list;
            TotalItems = totalItems;
        }
    }
}
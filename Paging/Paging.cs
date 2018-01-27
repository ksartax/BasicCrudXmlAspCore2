using System;
using System.Collections.Generic;
using System.Linq;

namespace Paging
{
    public class Paging<T> : List<T>
    {
        public const int DISPLAY_VIEW = 5;

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> List { get; private set; }

        public static Paging<T> PagingList(IQueryable<T> list, int pageSize, int pageIndex)
        {
            int count = list.Count();
            var items = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new Paging<T>(items, pageSize, count, pageIndex);
        }

        public Paging(List<T> list, int pageSize, int count, int pageIndex)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(list);
        }

        public int TotalDisplay
        {
            get
            {
                return PageIndex + DISPLAY_VIEW >= TotalPages ? TotalPages : PageIndex + DISPLAY_VIEW;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }
    }
}

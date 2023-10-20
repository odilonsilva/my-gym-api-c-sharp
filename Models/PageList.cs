using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class PageList<T> : List<T>
    {
        public int PageIndex {  get; set; }
        public int TotalCount { get; set; } = 0;
        public int TotalPages { get; set; }
        
        public int PreviousPage
        {
            get
            {
                return PageIndex > 1 ? PageIndex - 1 : 1;
            }
        }

        public int NextPage
        {
            get
            {
                return PageIndex < TotalPages ? PageIndex + 1 : 0;
            }
        }

        public PageList(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (decimal) pageSize);
            this.AddRange(items);
        }

        public static async Task<ActionResult> Paginate(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageListResult = new PageList<T>(items, pageIndex, pageSize, count);
            var result = new
            {
                data = items,
                current_page = pageIndex,
                prev_page = pageListResult.PreviousPage,
                next_page = pageListResult.NextPage,
                total_page = pageListResult.TotalPages,
                total_items = count
            };

            return new JsonResult(result);
                
        }

    }
}

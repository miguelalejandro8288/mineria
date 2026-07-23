using Microsoft.EntityFrameworkCore;

namespace mineria.Data
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; private set; }

        public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                HasNextPage = pageNumber < (int)Math.Ceiling(totalCount / (double)pageSize),
                HasPreviousPage = pageNumber > 1
            };

            AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = await source.CountAsync();

            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
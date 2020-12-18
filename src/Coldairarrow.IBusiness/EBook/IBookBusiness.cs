using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.EBook
{
    public interface IBookBusiness
    {
        Task<PageResult<Book>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<Book> GetTheDataAsync(long id);
        Task AddDataAsync(Book data);
        Task UpdateDataAsync(Book data);
        Task DeleteDataAsync(List<long> ids);
    }
}
using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.EBook
{
    public interface ICategoryBusiness
    {
        Task<PageResult<Category>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<Category> GetTheDataAsync(long id);
        Task AddDataAsync(Category data);
        Task UpdateDataAsync(Category data);
        Task DeleteDataAsync(List<long> ids);
    }
}
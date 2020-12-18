using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.EBook
{
    public interface IChapterBusiness
    {
        Task<PageResult<Chapter>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<Chapter> GetTheDataAsync(long id);
        Task AddDataAsync(Chapter data);
        Task UpdateDataAsync(Chapter data);
        Task DeleteDataAsync(List<long> ids);
    }
}
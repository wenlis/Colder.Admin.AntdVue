using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.EBook
{
    public interface IBooktaskBusiness
    {
        Task<PageResult<Booktask>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<Booktask> GetTheDataAsync(long id);
        Task AddDataAsync(Booktask data);
        Task UpdateDataAsync(Booktask data);
        Task DeleteDataAsync(List<long> ids);
    }
}
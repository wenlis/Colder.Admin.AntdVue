using Coldairarrow.Business.EBook;
using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.EBook
{
    [Route("/EBook/[controller]/[action]")]
    public class BooktaskController : BaseEBookController
    {
        #region DI

        public BooktaskController(IBooktaskBusiness booktaskBus)
        {
            _booktaskBus = booktaskBus;
        }

        IBooktaskBusiness _booktaskBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<Booktask>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _booktaskBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<Booktask> GetTheData(IdInputDTO<long> input)
        {
            return await _booktaskBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(Booktask data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _booktaskBus.AddDataAsync(data);
            }
            else
            {
                await _booktaskBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<long> ids)
        {
            await _booktaskBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}
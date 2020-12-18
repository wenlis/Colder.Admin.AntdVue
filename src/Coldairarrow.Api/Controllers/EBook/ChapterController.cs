using Coldairarrow.Business.EBook;
using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.EBook
{
    [Route("/EBook/[controller]/[action]")]
    public class ChapterController : BaseEBookController
    {
        #region DI

        public ChapterController(IChapterBusiness chapterBus)
        {
            _chapterBus = chapterBus;
        }

        IChapterBusiness _chapterBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<Chapter>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _chapterBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<Chapter> GetTheData(IdInputDTO<long> input)
        {
            return await _chapterBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(Chapter data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _chapterBus.AddDataAsync(data);
            }
            else
            {
                await _chapterBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<long> ids)
        {
            await _chapterBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}
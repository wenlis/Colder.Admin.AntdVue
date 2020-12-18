using Coldairarrow.Business.EBook;
using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.EBook
{
    [Route("/EBook/[controller]/[action]")]
    [CheckSign]
    public class CategoryController : BaseEBookController
    {
        #region DI

        public CategoryController(ICategoryBusiness categoryBus)
        {
            _categoryBus = categoryBus;
        }

        ICategoryBusiness _categoryBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<Category>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _categoryBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<Category> GetTheData(IdInputDTO<long> input)
        {
            return await _categoryBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(Category data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _categoryBus.AddDataAsync(data);
            }
            else
            {
                await _categoryBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<long> ids)
        {
            await _categoryBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}
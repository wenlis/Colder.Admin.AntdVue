using Coldairarrow.Business.EBook;
using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.EBook
{
    [Route("/EBook/[controller]/[action]")]
    public class BookController : BaseEBookController
    {
        #region DI

        public BookController(IBookBusiness bookBus)
        {
            _bookBus = bookBus;
        }

        IBookBusiness _bookBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<Book>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _bookBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<Book> GetTheData(IdInputDTO<long> input)
        {
            return await _bookBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(Book data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _bookBus.AddDataAsync(data);
            }
            else
            {
                await _bookBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<long> ids)
        {
            await _bookBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}
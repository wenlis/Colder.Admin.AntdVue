using Coldairarrow.Entity.EBook;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.EBook
{
    public class BooktaskBusiness : BaseEBookBusiness<Booktask>, IBooktaskBusiness, ITransientDependency
    {
        public BooktaskBusiness(IEBookDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<Booktask>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<Booktask>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<Booktask, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<Booktask> GetTheDataAsync(long id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(Booktask data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(Booktask data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<long> ids)
        {
            await DeleteAsync(ids.Select(m => m.ToString()).ToList());
        }

        #endregion

        #region 私有成员

        #endregion
    }
}
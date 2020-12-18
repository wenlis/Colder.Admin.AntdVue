using EFCore.Sharding;

namespace Coldairarrow.Business.EBook
{
    public class BaseEBookBusiness<T> : BaseBusiness<T> where T : class, new()
    {
        public BaseEBookBusiness(IEBookDbAccessor db) : base(db)
        {
        }
    }
    public interface IEBookDbAccessor : IDbAccessor
    {
    }
}

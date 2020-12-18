using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.EBook
{
    /// <summary>
    /// 书籍任务
    /// </summary>
    [Table("Booktask")]
    public class Booktask
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int64 Id { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 是否处理
        /// </summary>
        public Boolean Process { get; set; }

    }
}
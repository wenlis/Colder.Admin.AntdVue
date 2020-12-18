using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.EBook
{
    /// <summary>
    /// 分类
    /// </summary>
    [Table("Category")]
    public class Category
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int32 Id { get; set; }

        /// <summary>
        /// 父分类id
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 0未知  1男  2女
        /// </summary>
        public Int32 Sex { get; set; }

    }
}
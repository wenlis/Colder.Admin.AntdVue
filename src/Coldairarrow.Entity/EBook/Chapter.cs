using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.EBook
{
    /// <summary>
    /// 章节
    /// </summary>
    [Table("Chapter")]
    public class Chapter
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public Int64 Id { get; set; }

        /// <summary>
        /// 书籍ID
        /// </summary>
        public Int64 BookId { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32 SerialNums { get; set; }

        /// <summary>
        /// 章节名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 章节字数
        /// </summary>
        public Int32 WordNums { get; set; }

        /// <summary>
        /// 下载状态 1：已下载 0未下载
        /// </summary>
        public Int32? Status { get; set; }

        /// <summary>
        /// 书籍下载地址
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }

    }
}
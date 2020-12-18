using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.EBook
{
    /// <summary>
    /// 书籍主体信息
    /// </summary>
    [Table("Book")]
    public class Book
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
        /// 作者
        /// </summary>
        public String Author { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Desc { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public Int32 CategoryId { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        public Int32 SubCategoryId { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public Int32? Rate { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public String Cover { get; set; }

        /// <summary>
        /// 状态 0未知 1连载 2完本 3暂停
        /// </summary>
        public Int32 Status { get; set; }

        /// <summary>
        /// 字数
        /// </summary>
        public Int64? WordNums { get; set; }

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 是否已经提取章节
        /// </summary>
        public Boolean? Process { get; set; }

    }
}
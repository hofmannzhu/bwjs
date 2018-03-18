using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace  UtilityHelper
{
    public class WordHelper 
    { 
    }

    /// <summary>
    /// word 替换配置类
    /// </summary>
    public class WordReplaceConfig
    {
        /// <summary>
        /// 替换的关键词
        /// </summary>
        public string Key { get; set; }

        public DataTable TableInfo { get; set; }

        /// <summary>
        /// 替换类型
        /// </summary>
        public WordRelpaceType RelpaceType { get; set; }

        /// <summary>
        /// 替换的值，如果是图片的，值为图片的文件地址
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否使用模糊查询，使用起始完全比配，"A%"
        /// </summary>
        public bool IsLikeStart { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public int ImageWidth { get; set; }


        /// <summary>
        /// 图片高度
        /// </summary>
        public int ImageHeight { get; set; }
        /// <summary>
        /// 悬浮图标水平位置
        /// </summary>
        public int ImageHorizontalPosition { get; set; }

        /// <summary>
        /// 悬浮图标垂直位置
        /// </summary>
        public int ImageVerticalPosition { get; set; }

        /// <summary>
        /// 商标列表
        /// </summary>
        public List<BrandImgSource> BrandList { get; set; }

        /// <summary>
        /// 多个复选框
        /// </summary>
        public List<string> CheckList { get; set; }

        /// <summary>
        /// 添加的具体段落内容
        /// value中存具体添加到哪个段落后。
        /// </summary>
        public List<ParagraphContent> PContent { get; set; }
    }
    public class BrandImgSource
    {
        /// <summary>
        /// 商标名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商标路径
        /// </summary>
        public string BrandPath { get; set; }
        /// <summary>
        /// 商标小项
        /// </summary>
        public string SmallItems { get; set; }

    }

    /// <summary>
    /// 指定添加文本内容
    /// </summary>
    public class ParagraphContent
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否有下划线
        /// </summary>
        public bool Underline { get; set; }
    }

    /// <summary>
    /// word 替换类型
    /// </summary>
    public enum WordRelpaceType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text,

        /// <summary>
        /// 图片
        /// </summary>
        Image,

        /// <summary>
        /// 表格里的图片
        /// </summary>
        TableImage,

        /// <summary>
        /// 复选框
        /// </summary>
        CheckBox,

        /// <summary>
        /// 单选框
        /// </summary>
        Radio,

        /// <summary>
        /// 替换图片
        /// </summary>
        RelpaceImage,

        /// <summary>
        /// 商标图样列表
        /// </summary>
        Brand,
        /// <summary>
        /// 多个复选框选择
        /// </summary>
        CheckBoxList,

        /// <summary>
        /// 骑缝章
        /// </summary>
        MonyCompanySign,

        /// <summary>
        /// 添加段落
        /// </summary>
        Paragraph,

        /// <summary>
        /// 表格
        /// </summary>
        Table,
        /// <summary>
        /// 删除段落
        /// </summary>
        DeleteParagraph,

        /// <summary>
        /// 书签
        /// </summary>
        Bookmark
    }
}

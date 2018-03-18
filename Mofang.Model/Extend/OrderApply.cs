/**  版本信息模板在安装目录下，可自行修改。
* OrderApply.cs
*
* 功 能： N/A
* 类 名： OrderApply
*
* Ver 1.0   变更日期    2017-9-4         负责人 程晨龙  变更内容 
* ───────────────────────────────────
* V0.01  2017/9/6 14:39:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：博望基石　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Mofang.Model
{
	 
	public partial class OrderApply
	{
        /// <summary>
        /// 投保人信息
        /// </summary>
        public ApplicantInfo ApplicantInfo { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public ApplicationData ApplicationData { get; set; }

        /// <summary>
        /// 被保人信息
        /// </summary>
        public InsurantInfo InsurantInfo { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public object otherInfo { get; set; }
    }
}


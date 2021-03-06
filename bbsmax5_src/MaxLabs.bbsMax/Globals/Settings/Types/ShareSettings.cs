﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Text;
using System.Collections.Generic;
using MaxLabs.bbsMax.Enums;

namespace MaxLabs.bbsMax.Settings
{
	public class ShareSettings : SettingBase
	{
		public ShareSettings()
		{
			EnableShareFunction = true;

            FunctionName = "分享";
            HotDays = 3;
            HotShareSortType = HotShareSortType.ShareCount;
		}

		[SettingItem]
		public bool EnableShareFunction
		{
			get;
			set;
		}

        [SettingItem]
        public string FunctionName
        {
            get;
            set;
        }

        /// <summary>
        /// 热门分享排序依据
        /// </summary>
        [SettingItem]
        public HotShareSortType HotShareSortType
        {
            get;
            set;
        }

        /// <summary>
        /// 最近热门 （多少天内）
        /// </summary>
        [SettingItem]
        public int HotDays
        {
            get;
            set;
        }
	}
}
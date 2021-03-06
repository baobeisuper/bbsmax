﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MaxLabs.bbsMax.Filters;
using MaxLabs.WebEngine;
using MaxLabs.bbsMax.Rescourses;
using MaxLabs.bbsMax.StepByStepTasks;
using MaxLabs.bbsMax.Settings;

namespace MaxLabs.bbsMax.Web.max_pages.admin
{
    public partial class manage_feed_data : AdminPageBase
    {
        protected override BackendPermissions.Action BackedPermissionAction
        {
            get { return BackendPermissions.Action.Manage_Feed_Data; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_Request.IsClick("searchfeeds"))
            {
                SearchFeeds();
                return;
            }
            else if (_Request.IsClick("deletechecked"))
            {
                DeleteFeeds();
                return;
            }
            else if (_Request.IsClick("deleteallsearch"))
            {
                DeleteAllSearch();
                return;
            }
        }
     
        private void SearchFeeds()
        {
            FeedSearchFilter filter = FeedSearchFilter.GetFromForm();
            filter.Apply("filter", "page");
        }

        private void DeleteAllSearch()
        {
            FeedSearchFilter filter = FeedSearchFilter.GetFromFilter("filter");

            if (TaskManager.BeginTask(MyUserID, new DeleteFeedTask(), filter.ToString()))
            {

            }


        }

        protected void DeleteFeeds()
        {
            int[] feedIDs = StringUtil.Split<int>(_Request.Get("feedids", Method.Post, string.Empty));

            MessageDisplay msgDisplay = CreateMessageDisplay();

            try
            {
                using (new ErrorScope())
                {
                    bool success = FeedBO.Instance.DeleteAnyFeeds(MyUserID,feedIDs);
                    if (!success)
                    {
                        CatchError<ErrorInfo>(delegate(ErrorInfo error)
                        {
                            msgDisplay.AddError(error);
                        });
                    }
                    else
                    {
                       // ShowSuccess();
                        //msgDisplay.ShowInfo(this);
                    }
                }
            }
            catch (Exception ex)
            {
                msgDisplay.AddError(ex.Message);
            }
        }
    }
}
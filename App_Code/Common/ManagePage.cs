using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///ManagePage
/// </summary>
public class ManagePage : System.Web.UI.Page
{
    public ManagePage()
    {
        this.Load += new EventHandler(ManagePage_Load);
    }

    private void ManagePage_Load(object sender, EventArgs e)
    {
        //判断管理员是否登录
        if (!IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../login.aspx'</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 判断管理员是否已经登录(解决Session超时问题)
    /// </summary>
    public bool IsAdminLogin()
    {
        //如果Session为Null
        if (Session["AdminName"] != null)
        {
            return true;
        }
        else
        {
            //检查Cookies
            string adminname = Utils.GetCookie("AdminName");
            if (adminname != "")
            {
                Session["RememberName"] = Utils.GetCookie("RememberName");
                Session["AdminName"] = Utils.GetCookie("AdminName");
                Session["RoleID"] = Utils.GetCookie("RoleID");
                Session["AID"] = Utils.GetCookie("AID");
                Session["RealName"] = Utils.GetCookie("RealName");
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 检查管理权限
    /// </summary>
    /// <param name="nav_id">菜单id</param>
    /// <param name="action_type">操作类型</param>
    public bool ChkAdminLevel(System.Web.UI.Page page, int nav_id, string action_type)
    {
     
        ax_manager_role bll = new ax_manager_role();
        bool result = bll.Exists(Convert.ToInt32(Session["RoleID"]), nav_id, action_type);
        if (!result)
        {
            if (action_type == "View")
            {
                JscriptMsg(page, "对不起！您没有查看该栏目的权限！", "../error.html", "Error");
                return false;
            }
            else
            {
                JscriptMsg(page, "对不起！您没有操作该功能的权限！", "", "Error");
                return false;
            }
        
        }
        return true;
    }
    /// <summary>
    /// 写入管理日志
    /// </summary>
    /// <param name="action_type"></param>
    /// <param name="remark"></param>
    /// <returns></returns>
    public bool AddAdminLog(string action_type, string remark)
    {
           //写入日志
            ax_manager_log mylog = new ax_manager_log();
            mylog.user_id = Convert.ToInt32(Session["AID"]);
            mylog.user_name = Session["RememberName"].ToString();
            mylog.action_type = action_type;
            mylog.add_time = DateTime.Now;
            mylog.remark = remark;
            mylog.user_ip = AXRequest.GetIP();
            int newId = mylog.Add();
                   
            if (newId > 0)
            {
                return true;
            }
     
        return false;
    }


    #region JS提示============================================
    /// <summary>
    /// 添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    public void JscriptMsg(System.Web.UI.Page page,string msgtitle, string url, string msgcss)
    {
        string msbox = "jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        page.RegisterStartupScript("message", "<script language='javascript'>" + msbox + "</script>");
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    /// <summary>
    /// 带回传函数的添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    /// <param name="callback">JS回调函数</param>
    public void JscriptMsg(System.Web.UI.Page page, string msgtitle, string url, string msgcss, string callback)
    {
        string msbox = "jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
        page.RegisterStartupScript("message", "<script language='javascript'>" + msbox + "</script>");
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

}
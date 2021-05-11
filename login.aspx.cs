using System;
using System.Web.UI;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtUserName.Value = Utils.GetCookie("RememberName");
        }
    }

    #region 登录系统=========================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string userName = txtUserName.Value.Trim();
        string userPwd = txtPassword.Value.Trim();

        //判断登录信息
        ax_manager myuser = new ax_manager();
        string sqlGetUserID = "select  id  from [ax_manager] where user_name='" + userName + "'";
        int userid = Convert.ToInt16(DbHelperSQL.GetSingle(sqlGetUserID));
        myuser.GetModel(userid);
        if (myuser.password != null)
        {
            userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(userPwd, "MD5");
            if (myuser.password.Trim() != userPwd)
            {
                MessageBox.errorShow(this.Page, "账号或密码有误，请重试！");
                return;
            }

            //判断账号是否被禁用
            if (Convert.ToInt32(myuser.is_lock) == 2)
            {
                MessageBox.errorShow(this.Page, "您的账号被禁用，请联系客服！");
                return;
            }
    
            //写入登录日志
            ax_manager_log mylog = new ax_manager_log();
            mylog.user_id = userid;
            mylog.user_name = userName;
            mylog.action_type = "登陆";
            mylog.add_time = DateTime.Now;
            mylog.remark = "登陆系统";
            mylog.user_ip = AXRequest.GetIP();
            mylog.Add();


            //写入Cookies
            Utils.WriteCookie("RememberName", userName, 14400);
            Utils.WriteCookie("AdminName", userName, 14400);
            Utils.WriteCookie("RoleID", myuser.role_id.ToString(), 14400);
            Utils.WriteCookie("AID", myuser.id.ToString(), 14400);
            Utils.WriteCookie("RealName", myuser.real_name, 14400);
        
            //写入Session
            Session["RememberName"] = userName;
            Session["AdminName"] = userName;
            Session["RoleID"] = myuser.role_id.ToString();
            Session["AID"] = myuser.id.ToString();
            Session["RealName"] = myuser.real_name;
            Session.Timeout = 45;

            Response.Redirect("main.aspx");
            return;
        }
        else
        {
            MessageBox.errorShow(this.Page, "账号或密码有误，请重试！");
            return;
        }
    }
    #endregion
}

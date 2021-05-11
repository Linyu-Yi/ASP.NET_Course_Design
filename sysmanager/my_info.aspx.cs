using System;
using System.Web.UI;
using System.Web.Security;

public partial class sysmanager_my_info : ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!Page.IsPostBack)
        {
            ShowInfo(Convert.ToInt32(Session["AID"]));
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_manager model = new ax_manager();
        model.GetModel(_id);
        Lituser_name.Text = model.user_name;
        Litreal_name.Text = model.real_name;
        txtmobile.Text = model.mobile;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ax_manager model = new ax_manager();
        model.GetModel(Convert.ToInt32(Session["AID"]));

        string userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text.Trim(), "MD5");
        if (userPwd != model.password)
        {
            JscriptMsg(this.Page, "旧密码不正确！", "", "Warning");
            return;
        }
        if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
        {
            JscriptMsg(this.Page, "两次密码不一致！", "", "Warning");
            return;
        }
        model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        model.mobile = txtmobile.Text.Trim();
        model.id = Convert.ToInt32(Session["AID"]);

        if (!model.UpdateMY())
        {
            JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
            return;
        }
        AddAdminLog("修改", "修改个人信息：用户名:" + Lituser_name.Text); //记录日志
        JscriptMsg(this.Page, "个人信息修改成功！请下次用新密码登陆！", "", "Success");
    }
}

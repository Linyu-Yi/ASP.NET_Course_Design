using System;
using System.Web.UI;

public partial class sysmanager_contact_manager : ManagePage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 42, "View"); //检查权限
            ShowInfo(6);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_article model = new ax_article();
        model.GetModel(_id);

        txtContent.Value = model.content;
    }
    #endregion



    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_article model = new ax_article();
        model.GetModel(_id);

        model.content = txtContent.Value;

        if (model.Update())
        {
            AddAdminLog("修改", "修改联系我们信息"); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {    //检查权限
        if (ChkAdminLevel(this.Page, 42, "Edit"))
        {
            if (!DoEdit(6))
            {
                JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg(this.Page, "联系我们修改成功！", "", "Success");
        }
    }
}
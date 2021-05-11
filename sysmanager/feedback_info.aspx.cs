using System;
using System.Web.UI;

public partial class sysmanager_feedback_info : ManagePage
{
    private int id = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
        {
            JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
            return;
        }

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 49, "View"); //检查权限
            ShowInfo(this.id);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_feedback model = new ax_feedback();
        model.GetModel(_id);

        this.lbltitle.Text = model.title;
        this.lblco.Text = model.co;
        this.lbladdress.Text = model.address;
        
        this.lblcontent.Text = model.content;
        this.lbluser_name.Text = model.user_name;
        this.lbluser_tel.Text = model.user_tel;

        this.lbladd_time.Text = model.add_time.ToString();


    }
    #endregion
}
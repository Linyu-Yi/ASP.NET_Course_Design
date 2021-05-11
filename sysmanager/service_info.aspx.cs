using System;
using System.Web.UI;

public partial class sysmanager_service_info : ManagePage
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
            ChkAdminLevel(this.Page, 44, "View"); //检查权限
            ShowInfo(this.id);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_service model = new ax_service();
        model.GetModel(_id);

        this.lblorder_no.Text = model.order_no;
        this.lblexpress_no.Text = model.express_no;
        this.lblcontent.Text = model.content;
        this.lbluser_name.Text = model.user_name;
        this.lbluser_tel.Text = model.user_tel;
        this.Image1.ImageUrl = model.img_url1;
        this.Image2.ImageUrl = model.img_url2;
        this.Image3.ImageUrl = model.img_url3;
        this.Image4.ImageUrl = model.img_url4;
        this.Image5.ImageUrl = model.img_url5;
        this.lbladd_time.Text = model.add_time.ToString();


    }
    #endregion
}
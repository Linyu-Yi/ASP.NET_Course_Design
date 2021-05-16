using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Data;

public partial class orderInfoLoad : System.Web.UI.Page
{
    public string nu = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        ax_orders model = new ax_orders();
        if (!model.Exists(orderno.Value.Trim(), recvmobile.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！没有找到您输入的信息的相关订单记录，请检查是否输入有误！</div>\").time(5000);</script>");

        }
        else
        {
            ShowInfo(orderno.Value.Trim());
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(string _order_no)
    {
        PanelOrder.Visible = true;
        ax_orders model = new ax_orders();
        model.GetModel(_order_no);
        contact_address.Text = model.address;
        contact_name.Text = model.user_name;
        contact_tel.Text = model.user_tel;

        message.Text = model.message;
        remark.Text = model.remark;
        if (Convert.ToInt32(model.depot_category_id) != 0)
        {
            //depot_category.Text = new ax_depot_category().GetTitle(Convert.ToInt32(model.depot_category_id));
            depot_category.Text = "<font color=red>已发货</font>";
        }
        else
        {
            depot_category.Text = "<font color=red>未发货</font>";
        }

       
        //绑定商品列表
        ax_order_goods bll = new ax_order_goods();
        string sql = " order_id =" + model.id;

        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }
    #endregion

    

}
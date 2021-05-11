using System;
using System.Data;

public partial class m_orderInfoLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkcode.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcode.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"验证码错误!\");</script>");
            checkcode.Value = "";
            return;
        }
        ax_orders model = new ax_orders();
        if (!model.Exists(orderno.Value.Trim(), recvmobile.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"对不起！没有找到您输入的信息的相关订单记录，请检查是否输入有误！\");</script>");
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
            depot_category.Text = new ax_depot_category().GetTitle(Convert.ToInt32(model.depot_category_id));
        }
        else
        {
            depot_category.Text = "<font color=red>未出库</font>";
        }

        if (Convert.ToInt32(model.product_category_id) != 0)
        {
            product_category.Text = new ax_product_category().GetTitle(Convert.ToInt32(model.product_category_id));
            product_no.Text = model.product_no;
        }
        else
        {
            product_category.Text = "<font color=red>未发货</font>";
            product_no.Text = "<font color=red>未发货</font>";
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
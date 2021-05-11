using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ordermanager_order_edit : ManagePage
{
    protected int page;
    private string action = ""; //操作类型
    private int id = 0;
    
    protected ax_orders model = new ax_orders();
    protected void Page_Load(object sender, EventArgs e)
    {

        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!string.IsNullOrEmpty(_action) && _action == "Edit")
        {
            this.action = "Edit";//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }

        }
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 39, "View"); //检查权限
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }

    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        model.GetModel(_id);
        //绑定商品列表
        ax_order_goods bll = new ax_order_goods();
        string sql = " order_id =" + _id;

        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        //获得收货人信息

        contact_address.Text = model.address;
        contact_name.Text = model.user_name;
        contact_tel.Text = model.user_tel;
     
        //根据订单状态，显示各类操作按钮
        switch (model.status)
        {
            case 1: //订单为已生成状态     
                //取消订单显示
                if (roleview(Convert.ToInt32(Session["RoleID"]), 39, "Cancel"))
                {
                    btnCancel.Visible = true;
                }
                //修改订单备注、修改收货信息按钮显示
                if (roleview(Convert.ToInt32(Session["RoleID"]), 39, "Edit"))
                {
                    btnEditRemark.Visible = true;
                    btnEditAcceptInfo.Visible = true;
                    btnEditExpress.Visible = true;
                }
                break;
            case 2: //如果订单为已确认状态
                //完成显示
                if (roleview(Convert.ToInt32(Session["RoleID"]), 39, "Confirm"))
                {
                btnComplete.Visible = true;
                }
                //修改订单备注按钮可见
                if (roleview(Convert.ToInt32(Session["RoleID"]), 39, "Edit"))
                {
                    btnEditRemark.Visible = true;
                }
                break;

        }

    }
    #endregion
    //Convert.ToInt32(Session["RoleID"])
    private bool roleview(int role_id, int nav_id,string action_type)
    {
        ax_manager_role bll = new ax_manager_role();
        bool result = bll.Exists(role_id, nav_id, action_type);
        return result;
    }
}
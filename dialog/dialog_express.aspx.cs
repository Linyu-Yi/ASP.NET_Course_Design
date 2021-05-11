using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dialog_dialog_express : ManagePage
{
     private string order_no = string.Empty;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            order_no = AXRequest.GetQueryString("order_no");
            if (order_no == "")
            {
                JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }
            if (!new ax_orders().Exists(order_no))
            {
                JscriptMsg(this.Page, "订单不存在或已被删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(order_no);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _order_no)
        {
            ax_orders model = new ax_orders();
            model.GetModel(_order_no);

            ax_product_category bll2 = new ax_product_category();
            DataTable dt = bll2.GetList("1=1").Tables[0];
            ddlExpressId.Items.Clear();
            ddlExpressId.Items.Add(new ListItem("请选择快递公司", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddlExpressId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }

            ax_depot_category bll3 = new ax_depot_category();
            DataTable dt3 = bll3.GetList("1=1").Tables[0];
            ddlDepotId.Items.Clear();
            ddlDepotId.Items.Add(new ListItem("请选择发货仓库", ""));
            foreach (DataRow dr in dt3.Rows)
            {
                ddlDepotId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }

            txtExpressNo.Text = model.product_no;
            ddlDepotId.SelectedValue = model.depot_category_id.ToString();
            ddlExpressId.SelectedValue = model.product_category_id.ToString();

        }
        #endregion
    }

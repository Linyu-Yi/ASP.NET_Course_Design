using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class ordermanager_order_rep : ManagePage
{
    protected int depot_category_id;
    protected int depot_id;
    protected int status;
    protected string note_no = string.Empty;
    protected string start_time = string.Empty;
    protected string stop_time = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 39, "View"); //检查权限
            this.depot_category_id = AXRequest.GetQueryInt("depot_category_id");
            this.depot_id = AXRequest.GetQueryInt("depot_id");
            this.status = AXRequest.GetQueryInt("status");
            this.note_no = AXRequest.GetQueryString("note_no");
            this.start_time = AXRequest.GetQueryString("start_time");
            this.stop_time = AXRequest.GetQueryString("stop_time");

            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("订单信息表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;


    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _depot_category_id, int _depot_id, int _status, string _note_no, string _start_time, string _stop_time)
    {
        StringBuilder strTemp = new StringBuilder();

        if (_status > 0)
        {
            strTemp.Append(" and status=" + _status);
        }
        if (_depot_category_id > 0)
        {
            strTemp.Append(" and depot_category_id=" + _depot_category_id);
        }
        if (_depot_id > 0)
        {
            strTemp.Append(" and product_category_id=" + _depot_id);
        }

        if (string.IsNullOrEmpty(_start_time))
        {
            _start_time = "1900-01-01";
            Literal4.Text = "(不限)";
        }
        else
        {
            Literal4.Text = _start_time;
        }
        if (string.IsNullOrEmpty(_stop_time))
        {
            _stop_time = "2099-01-01";
            Literal5.Text = DateTime.Now.ToString("d");
        }
        else
        {
            Literal5.Text = _stop_time;
        }
        strTemp.Append(" and add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time + " 23:59:59") + "'");

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and order_no like  '%" + _note_no + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    //绑定记录
    public void binddr()
    {
        ax_orders bll = new ax_orders();

        string sqlstr = "id>0 ";
        sqlstr = sqlstr + CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time);
        sqlstr = sqlstr + " order by add_time desc,id desc";
        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();

    }

    #region 返回订单状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "已提货";
                break;
            case 2:
                _title = "<font color=blue>已发货</font>";
                break;
            case 3:
                _title = "<font color=green>已完成</font>";
                break;
            case 4:
                _title = "<font color=red>已取消</font>";
                break;
        }

        return _title;
    }
    #endregion

    #region 返回礼券信息=============================
    protected string GetTicketNoStatus(int _id)
    {
        string _title = string.Empty;
        ax_order_goods bll = new ax_order_goods();
        DataTable dt = bll.GetList(_id);

        foreach (DataRow dr in dt.Rows)
        {
            _title = _title + "&nbsp;编号：" + dr["ticket_no"].ToString().Trim() + "&nbsp;名称：" + dr["goods_title"].ToString().Trim() + "&nbsp;,";
        }

        return Utils.DelLastComma(_title);
    }
    #endregion

}

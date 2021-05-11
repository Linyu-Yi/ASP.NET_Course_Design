using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ordermanager_consignment_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected int depot_category_id;
    protected int depot_id;
    protected int status;
    protected string note_no = string.Empty;
    protected string start_time = string.Empty;
    protected string stop_time = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        this.note_no = AXRequest.GetQueryString("note_no");   
        this.pageSize = GetPageSize(10); //每页数量

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 40, "View"); //检查权限
            RptBind("id>0 " + CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time), "add_time desc,id desc");

        }
    }


    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);

        ax_orders bll = new ax_orders();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("consignment_list.aspx", "depot_category_id={0}&depot_id={1}&status={2}&start_time={3}&stop_time={4}&note_no={5}&page={6}", this.depot_category_id.ToString(), this.depot_id.ToString(), this.status.ToString(), "", "", txtNote_no.Text, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _depot_category_id, int _depot_id, int _status, string _note_no, string _start_time, string _stop_time)
    {
        StringBuilder strTemp = new StringBuilder();
 
         strTemp.Append(" and status=1");
        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and order_no like  '%" + _note_no + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("consignment_list_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

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

    #region 返回礼券编号=============================
    protected string GetTicketNoStatus(int _id)
    {
        string _title = string.Empty;
        ax_order_goods bll = new ax_order_goods();
        DataTable dt = bll.GetList(_id);

        foreach (DataRow dr in dt.Rows)
        {
            _title = _title + dr["ticket_no"].ToString().Trim() + "&nbsp;,";
        }

        return Utils.DelLastComma(_title);
    }
    #endregion


    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("consignment_list.aspx", "depot_category_id={0}&depot_id={1}&status={2}&start_time={3}&stop_time={4}&note_no={5}", this.depot_category_id.ToString(), this.depot_id.ToString(), this.status.ToString(), "", "", txtNote_no.Text));
    }



    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("consignment_list_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("consignment_list.aspx", "depot_category_id={0}&depot_id={1}&status={2}&start_time={3}&stop_time={4}&note_no={5}", this.depot_category_id.ToString(), this.depot_id.ToString(), this.status.ToString(), "", "", txtNote_no.Text));

    }
 
}

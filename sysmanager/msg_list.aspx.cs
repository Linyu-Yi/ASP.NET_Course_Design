using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_msg_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;

    
    protected void Page_Load(object sender, EventArgs e)
    {
 
        this.keywords = AXRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(100); //每页数量
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 46, "View"); //检查权限
            RptBind(CombSqlTxt(this.keywords), "MsgID desc");
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        txtKeywords.Text = this.keywords;
        ax_msglist bll = new ax_msglist();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("msg_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" (OP like  '%" + _keywords + "%' or CardNum like  '%" + _keywords + "%' or MemberName like '%" + _keywords + "%' or  MemberTel like '%" + _keywords + "%'  or  Message like '%" + _keywords + "%' )");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("msglist_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion


    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("msg_list.aspx", "keywords={0}", txtKeywords.Text));
    }

    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("msglist_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("msg_list.aspx", "keywords={0}", this.keywords));
    }


    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 46, "Delete"))
        {
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            ax_msglist bll = new ax_msglist();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog("删除", "删除短信发送日志成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg(this.Page, " 删除短信发送日志成功" + sucCount + "条，失败" + errorCount + "条", Utils.CombUrlTxt("msg_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");
        }
    }

}

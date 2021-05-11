using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_manager_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected int status;
    protected int category_id;
    protected int depot_id;
    protected int role_id;    
    protected string keywords = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
 
        this.status = AXRequest.GetQueryInt("status");
        this.category_id = AXRequest.GetQueryInt("category_id");
        this.depot_id = AXRequest.GetQueryInt("depot_id");
        this.role_id = AXRequest.GetQueryInt("role_id");
        this.keywords = AXRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 29, "View"); //检查权限
            RoleBind(ddlRoleId);//绑定角色    
            RptBind("role_id<>1" + CombSqlTxt(this.status, this.category_id, this.depot_id, this.role_id, this.keywords), "add_time desc,id desc");    
        }
    }

    #region 角色类型=================================
    private void RoleBind(DropDownList ddl)
    {
        ax_manager_role bll = new ax_manager_role();
        DataTable dt = bll.GetList("").Tables[0];

        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("==全部==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToInt32(dr["is_sys"]) == 0)
            {
                ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
            }
        }
    }
    #endregion

  
    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        if (this.status > 0)
        {
            this.ddlStatus.SelectedValue = this.status.ToString();
        }

        if (this.role_id > 0)
        {
            this.ddlRoleId.SelectedValue = this.role_id.ToString();
        }
        txtKeywords.Text = this.keywords;
        ax_manager bll = new ax_manager();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&role_id={4}&page={5}", this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), this.keywords, this.role_id.ToString(), "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _category_id, int _depot_id, int _role_id, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        if (_status > 0)
        {
            strTemp.Append(" and is_lock=" + _status);
        }

        if (_role_id > 0)
        {
            strTemp.Append(" and  role_id=" + _role_id);
        }
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (user_name like  '%" + _keywords + "%' or real_name like '%" + _keywords + "%' or  mobile like '%" + _keywords + "%' or  remark like '%" + _keywords + "%'  )");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("manager_page_size"), out _pagesize))
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
        Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&role_id={4}", this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), txtKeywords.Text, this.role_id.ToString()));
    }


    //筛选角色
    protected void ddlRoleId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&role_id={4}",
            this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), this.keywords, ddlRoleId.SelectedValue));
    }

    //筛选状态
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&role_id={4}",
            ddlStatus.SelectedValue, this.category_id.ToString(), this.depot_id.ToString(), this.keywords, this.role_id.ToString()));
    }
  
    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("manager_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}", this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), this.keywords));
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 29, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_manager bll = new ax_manager();
            bll.GetModel(caId);
            string title = bll.user_name;

            bll.Delete(caId);
            AddAdminLog("删除", "删除用户名（账号）：" + title + ""); //记录日志
            JscriptMsg(this.Page, " 成功删除用户名（账号）：" + title + "", Utils.CombUrlTxt("manager_list.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&page={4}", this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), this.keywords, this.page.ToString()), "Success");
        }
    }
    //导出报表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("manager_rep.aspx", "status={0}&category_id={1}&depot_id={2}&keywords={3}&role_id={4}", this.status.ToString(), this.category_id.ToString(), this.depot_id.ToString(), this.keywords, this.role_id.ToString()));
    }
}

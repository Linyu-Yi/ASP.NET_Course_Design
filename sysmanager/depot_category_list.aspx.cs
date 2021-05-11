using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_depot_category_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;

    
    protected void Page_Load(object sender, EventArgs e)
    {    

        this.keywords = AXRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 27, "View"); //检查权限
           RptBind(CombSqlTxt(this.keywords), "sort_id asc,id desc");
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        txtKeywords.Text = this.keywords;
        ax_depot_category bll = new ax_depot_category();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}",this.keywords, "__id__");
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
            strTemp.Append(" title like  '%" + _keywords + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("depot_category_page_size"), out _pagesize))
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
        Response.Redirect(Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}", txtKeywords.Text));
    }

    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("depot_category_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}",this.keywords));
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {  
        //检查权限
        if (ChkAdminLevel(this.Page, 27, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_depot_category bll = new ax_depot_category();
            bll.GetModel(caId);
            string title = bll.title;
            ax_orders bllpp = new ax_orders();
            if (!bllpp.ExistsBM(caId))//查找是否存在该仓库已经有发货记录
            {
                bll.Delete(caId);
                AddAdminLog("删除", "删除发货仓库：" + title + ""); //记录日志
                JscriptMsg(this.Page, " 成功删除发货仓库：" + title + "", Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");

            }
            else
            {
                JscriptMsg(this.Page, "该仓库已经有发货记录，不能删除！", "", "Error");
                return;
            }
        }
    }
   
    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ax_depot_category bll = new ax_depot_category();
        Repeater rptList = new Repeater();
        rptList = this.rptList;
    
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            bll.UpdateField(id, "sort_id=" + sortId.ToString());
        }

        JscriptMsg(this.Page, " 排序保存成功", Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");  
    }
}

﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_service_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        this.pageSize = GetPageSize(10); //每页数量
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 44, "View"); //检查权限
            RptBind("1=1", "add_time desc,id desc");
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);

        ax_service bll = new ax_service();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("service_list.aspx", "page={0}", "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("service_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("service_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("service_list.aspx", "page={0}", this.page.ToString()));
    }
    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 44, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_service bll = new ax_service();
            bll.GetModel(caId);
            string title = bll.order_no;
            bll.Delete(caId);
            AddAdminLog("删除", "删除售后服务信息：" + title + ""); //记录日志
            JscriptMsg(this.Page, " 成功删除售后服务信息：" + title + "", Utils.CombUrlTxt("service_list.aspx", "page={0}", this.page.ToString()), "Success");
        }
    }
}

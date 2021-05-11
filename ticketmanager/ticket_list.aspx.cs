using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

public partial class ticketmanager_ticket_list : ManagePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected int status;
    protected int category_id;
    protected string keywords = string.Empty;
    protected string start_time = string.Empty;
    protected string stop_time = string.Empty;

    
    protected void Page_Load(object sender, EventArgs e)
    {

        this.status = AXRequest.GetQueryInt("status");
        this.category_id = AXRequest.GetQueryInt("category_id");
        this.keywords = AXRequest.GetQueryString("keywords");

         this.start_time = AXRequest.GetQueryString("start_time");

          this.stop_time = AXRequest.GetQueryString("stop_time");
      
        this.pageSize = GetPageSize(10); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 21, "View"); //检查权限
            TreeBind(); //绑定礼品 
            RptBind("id>0" + CombSqlTxt(this.status, this.category_id, this.keywords, this.start_time, this.stop_time), " ticket_no asc");
        
        }
    }

    #region 绑定礼品=================================
    private void TreeBind()
    {
        ax_article bll = new ax_article();
        DataTable dt = bll.GetList("category_id =1 order by sort_id asc,id desc").Tables[0];
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("==全部==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
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
        if (this.category_id > 0)
        {
            this.ddlCategoryId.SelectedValue = this.category_id.ToString();
        }
        txtKeywords.Text = this.keywords;
        txtstart_time.Value = this.start_time;
        txtstop_time.Value = this.stop_time;
        ax_ticket bll = new ax_ticket();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}&page={5}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _category_id, string _keywords, string _start_time, string _stop_time)
    {
        StringBuilder strTemp = new StringBuilder();
        if (_status > 0)
        {
            strTemp.Append(" and status=" + _status);
        }
        if (_category_id > 0)
        {
            strTemp.Append(" and pid=" + _category_id);
        }
        if (string.IsNullOrEmpty(_start_time))
        {
            _start_time = "1900-01-01";
        }
        if (string.IsNullOrEmpty(_stop_time))
        {
            _stop_time = "2099-01-01";
        }
        strTemp.Append(" and add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time + " 23:59:59") + "'");

        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and ticket_no like  '%" + _keywords + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回礼券状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "未发放";
                break;
            case 2:
                _title = "<font color=green>已发放</font>";
                break;
            case 3:
                _title = "<font color=red>已提货</font>";
                break;
        
        }

        return _title;
    }
    #endregion

    #region 返回礼券状态=============================
    protected string GetLQStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "未发放";
                break;
            case 2:
                _title = "已发放";
                break;
            case 3:
                _title = "已提货";
                break;

        }

        return _title;
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("ticket_list_page_size"), out _pagesize))
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
        Response.Redirect(Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}", this.status.ToString(), this.category_id.ToString(), txtKeywords.Text, this.txtstart_time.Value, this.txtstop_time.Value));
    }

    //筛选礼品
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}",
            this.status.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.txtstart_time.Value, this.txtstop_time.Value));
    }
    //筛选状态
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}",
            ddlStatus.SelectedValue, this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value));
    }
    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("ticket_list_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value));
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 21, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_ticket bll = new ax_ticket();
            bll.GetModel(caId);
            string title = bll.ticket_no;

            bll.Delete(caId);
            AddAdminLog("删除", "删除礼券编号：" + title + ""); //记录日志
            JscriptMsg(this.Page, " 成功删除礼券编号：" + title + "", Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}&page={5}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value, this.page.ToString()), "Success");
        }
    }

    //批量发放
    protected void btnFF_Click(object sender, EventArgs e)
    {   
        //检查权限
        if (ChkAdminLevel(this.Page, 21, "Instal"))
        {
            ax_ticket bll = new ax_ticket();
            Repeater rptList = new Repeater();
            rptList = this.rptList;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "status=2");
                }
            }
            JscriptMsg(this.Page, " 批量发放成功", Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}&page={5}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value, this.page.ToString()), "Success");
        }
    }
  
       //批量修改到期时间
    protected void btnDQ_Click(object sender, EventArgs e)
    {      
        //检查权限
        if (ChkAdminLevel(this.Page, 21, "Replace"))
        {
            ax_ticket bll = new ax_ticket();
            Repeater rptList = new Repeater();
            rptList = this.rptList;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "add_time='" + Utils.StrToDateTime(txtAddTime.Text.Trim() + " 23:59:59") + "'");
                }
            }
            JscriptMsg(this.Page, " 批量修改到期时间成功", Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&start_time={3}&stop_time={4}&page={5}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.txtstart_time.Value, this.txtstop_time.Value, this.page.ToString()), "Success");
        }
    }
    //导出报表
    protected void btnExport_Click(object sender, EventArgs e)
    {
       
        //Response.Redirect(Utils.CombUrlTxt("ticket_rep.aspx", "status={0}&category_id={1}&keywords={2}", this.status.ToString(), this.category_id.ToString(), this.keywords));
        ax_ticket mys = new ax_ticket();
        string sqlstr = "id>0" + CombSqlTxt(this.status, this.category_id, this.keywords, this.start_time, this.stop_time) + "order by ticket_no asc";

        DataSet tdSet = mys.GetList(sqlstr);

        CreateExcel(tdSet);
    
    }

    public void CreateExcel(DataSet ds)
    {
        Response.AddHeader("Content-Disposition", "attachment;filename=" +
        HttpUtility.UrlEncode("礼券信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", System.Text.Encoding.UTF8));
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";
        int i = 1;
        System.IO.StringWriter sw = new System.IO.StringWriter();

        sw.WriteLine("<?xml version=\"1.0\"?>");
        sw.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
        sw.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        sw.WriteLine("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
        sw.WriteLine("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
        sw.WriteLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        sw.WriteLine("xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
        sw.WriteLine("<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
        sw.WriteLine("<Created>1996-12-17T01:32:42Z</Created>");
        sw.WriteLine("<LastSaved>2012-07-28T01:05:10Z</LastSaved>");
        sw.WriteLine("<Version>11.9999</Version>");
        sw.WriteLine("</DocumentProperties>");
        sw.WriteLine("<OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\">");
        sw.WriteLine("<RemovePersonalInformation/>");
        sw.WriteLine("</OfficeDocumentSettings>");
        sw.WriteLine("<ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        sw.WriteLine("<WindowHeight>4530</WindowHeight>");
        sw.WriteLine("<WindowWidth>8505</WindowWidth>");
        sw.WriteLine("<WindowTopX>480</WindowTopX>");
        sw.WriteLine("<WindowTopY>120</WindowTopY>");
        sw.WriteLine("<AcceptLabelsInFormulas/>");
        sw.WriteLine("<ProtectStructure>False</ProtectStructure>");
        sw.WriteLine("<ProtectWindows>False</ProtectWindows>");
        sw.WriteLine("</ExcelWorkbook>");
        sw.WriteLine("<Styles>");
        sw.WriteLine("<Style ss:ID=\"Default\" ss:Name=\"Normal\">");
        sw.WriteLine("<Alignment ss:Vertical=\"Bottom\"/>");
        sw.WriteLine("<Borders/>");
        sw.WriteLine("<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"10\"/>");
        sw.WriteLine("<Interior/>");
        sw.WriteLine("<NumberFormat/>");
        sw.WriteLine("<Protection/>");
        sw.WriteLine("</Style>");
        sw.WriteLine("<Style ss:ID=\"s21\">");
        sw.WriteLine("<Font ss:FontName=\"宋体\" x:CharSet=\"134\"/>");
        sw.WriteLine("</Style>");
        sw.WriteLine("<Style ss:ID=\"s24\">");
        sw.WriteLine("<Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
        sw.WriteLine("<Font ss:FontName=\"宋体\" x:CharSet=\"134\"/>");
        sw.WriteLine("</Style>");
        sw.WriteLine("<Style ss:ID=\"s23\">");
        sw.WriteLine("<Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
        sw.WriteLine("<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"16\"/>");
        sw.WriteLine("</Style>");
        sw.WriteLine("<Style ss:ID=\"s29\">");
        sw.WriteLine("<Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
        sw.WriteLine("<Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"12\" ss:Color=\"#FF0000\"");
        sw.WriteLine("ss:Bold=\"1\"/>");
        sw.WriteLine("</Style>");
        sw.WriteLine("</Styles>");
        sw.WriteLine("<Worksheet ss:Name=\"礼券信息\">");
        sw.WriteLine("<Table x:FullColumns=\"1\"");
        sw.WriteLine("x:FullRows=\"1\" ss:DefaultColumnWidth=\"100\" ss:DefaultRowHeight=\"14.25\">");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/>");
        sw.WriteLine("<Column ss:StyleID=\"s21\" ss:AutoFitWidth=\"0\" ss:Width=\"50.25\"/>");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"63.75\"/>");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"195.75\"/>");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"67.5\"/>");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"71.25\"/>");

        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"63\"/>");
        sw.WriteLine("<Column ss:AutoFitWidth=\"0\" ss:Width=\"62.25\" ss:Span=\"1\"/>");
        sw.WriteLine("<Column ss:Index=\"12\" ss:AutoFitWidth=\"0\" ss:Width=\"171.75\" ss:Span=\"1\"/>");
        sw.WriteLine("<Column ss:Index=\"14\" ss:AutoFitWidth=\"0\" ss:Width=\"71.25\"/>");

        sw.WriteLine("<Row ss:AutoFitHeight=\"0\" ss:Height=\"28.5\">");
        sw.WriteLine("<Cell  ss:MergeAcross=\"5\" ss:StyleID=\"s23\"><Data ss:Type=\"String\">礼券信息</Data></Cell>");
        sw.WriteLine("</Row>");

        sw.WriteLine("<Row ss:Height=\"18\" ss:StyleID=\"s24\">");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">序号</Data></Cell>");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">礼券规格</Data></Cell>");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">礼券编号</Data></Cell>");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">礼券密码</Data></Cell>");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">到期日期</Data></Cell>");
        sw.WriteLine("<Cell ss:StyleID=\"s29\"><Data ss:Type=\"String\">状态</Data></Cell>");
        sw.WriteLine("</Row>");

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据

            sw.WriteLine(" <Row>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + i.ToString() + "</Data></Cell>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + new ax_article().GetTitle(Convert.ToInt32(row["pid"].ToString())) + "</Data></Cell>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + row["ticket_no"].ToString() + "</Data></Cell>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + row["ticket_pw"].ToString() + "</Data></Cell>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + DateTime.Parse(row["add_time"].ToString()).ToString("d")+ "</Data></Cell>");
            sw.WriteLine("<Cell ><Data ss:Type=\"String\">" + GetLQStatus(Convert.ToInt32(row["status"].ToString())) + "</Data></Cell>");  
            sw.WriteLine(" </Row>");
            i++;
        }
      
        sw.WriteLine("</Table>");
        sw.WriteLine("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        sw.WriteLine("<Print>");
        sw.WriteLine("<ValidPrinterInfo/>");
        sw.WriteLine("<PaperSizeIndex>9</PaperSizeIndex>");
        sw.WriteLine("<HorizontalResolution>100</HorizontalResolution>");
        sw.WriteLine("<VerticalResolution>100</VerticalResolution>");
        sw.WriteLine("</Print>");
        sw.WriteLine("<Selected/>");
        sw.WriteLine("<Panes>");
        sw.WriteLine("<Pane>");
        sw.WriteLine("<Number>3</Number>");
        sw.WriteLine("<ActiveRow>1</ActiveRow>");
        sw.WriteLine("</Pane>");
        sw.WriteLine("</Panes>");
        sw.WriteLine("<ProtectObjects>False</ProtectObjects>");
        sw.WriteLine("<ProtectScenarios>False</ProtectScenarios>");
        sw.WriteLine("</WorksheetOptions>");
        sw.WriteLine(" </Worksheet>");
        sw.WriteLine("</Workbook>");
        Response.Write(sw);
        Response.End();
    }



}

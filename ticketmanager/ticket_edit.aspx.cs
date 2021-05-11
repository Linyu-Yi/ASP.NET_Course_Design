using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticketmanager_ticket_edit : ManagePage
{
    protected int page;
    protected int status;
    protected int category_id;
    protected string keywords = string.Empty;
    private string action = "Add"; //操作类型
    private int id = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string _action = AXRequest.GetQueryString("action");
        this.status = AXRequest.GetQueryInt("status");
        this.category_id = AXRequest.GetQueryInt("category_id");
        this.keywords = AXRequest.GetQueryString("keywords");
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
            ChkAdminLevel(this.Page, 21, "View"); //检查权限
            TreeBind(); //绑定礼品
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_ticket model = new ax_ticket();
        model.GetModel(_id);
        ddlCategoryId.SelectedValue = model.pid.ToString();
        txtticket_no.Text = model.ticket_no;
        txtticket_pw.Text = model.ticket_pw;
        txtAddTime.Text = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd ");
        if (model.status == 2)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
    }
    #endregion

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

    #region 添加操作=================================
    private bool DoAdd()
    {
        ax_ticket model = new ax_ticket();
        if (model.Exists(txtticket_no.Text.Trim()))
        {
            JscriptMsg(this.Page, "您输入的礼券名称已经存在，请检查！", "", "Error");
            return false;
        }
        model.ticket_no = txtticket_no.Text.Trim();

        model.ticket_pw = txtticket_pw.Text.Trim();
    
        model.pid = int.Parse(ddlCategoryId.SelectedValue.Trim());
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim()+" 23:59:59");
        if (cbIsLock.Checked == true)
        {
            model.status = 2;
        }
        else
        {
            model.status = 1;
        }
        if (model.Add() > 0)
        {
            AddAdminLog("添加", "添加礼券：" + txtticket_no.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_ticket model = new ax_ticket();
        if (model.Exists(txtticket_no.Text.Trim(), _id))
        {
            JscriptMsg(this.Page, "您输入的礼券名称已经存在，请检查！", "", "Error");
            return false;
        }
        model.GetModel(_id);

        model.ticket_no = txtticket_no.Text.Trim();

        model.ticket_pw = txtticket_pw.Text.Trim();

        model.pid = int.Parse(ddlCategoryId.SelectedValue.Trim());
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim() + " 23:59:59");
        if (cbIsLock.Checked == true)
        {
            model.status = 2;
        }
        else
        {
            model.status = 1;
        }

        if (model.Update())
        {
            AddAdminLog("修改", "修改礼券:" + txtticket_no.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 21, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "修改礼券信息成功！", Utils.CombUrlTxt("ticket_list.aspx", "status={0}&category_id={1}&keywords={2}&page={3}", this.status.ToString(), this.category_id.ToString(), this.keywords, this.page.ToString()), "Success");
            }
        }
        else //添加
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 21, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加礼券信息成功！", "ticket_list.aspx", "Success");
            }
        }
    }

}
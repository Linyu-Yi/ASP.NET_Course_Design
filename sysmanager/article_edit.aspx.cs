using System;
using System.Web.UI;

public partial class sysmanager_article_edit : ManagePage
{
    protected int page;
    private string action = "Add"; //操作类型
    private int id = 0;
    
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
            ChkAdminLevel(this.Page, 31, "View"); //检查权限
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {

        ax_article model = new ax_article();
        model.GetModel(_id);
        txttitle.Text = model.title;
        txtContent.Value = model.content;
        txtAddTime.Text = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd HH:mm:ss");
        txtSortId.Text = model.sort_id.ToString();
        if (model.status == 1)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
    }
    #endregion

    #region 添加操作=================================
    private bool DoAdd()
    {
        ax_article model = new ax_article();
        model.category_id = 2;
        model.title = txttitle.Text.Trim();
        model.content = txtContent.Value;
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }
        if (model.Add() > 0)
        {
            AddAdminLog("添加", "添加帮助中心：" + txttitle.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_article model = new ax_article();
        model.GetModel(_id);
        model.category_id = 2;
        model.title = txttitle.Text.Trim();
        model.content = txtContent.Value;
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }
        if (model.Update())
        {
            AddAdminLog("修改", "修改帮助中心:" + txttitle.Text); //记录日志
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
            if (ChkAdminLevel(this.Page, 31, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "修改帮助中心成功！", Utils.CombUrlTxt("article_list.aspx", "page={0}", this.page.ToString()), "Success");
            }
        }
        else //添加
        { 
            //检查权限
            if (ChkAdminLevel(this.Page, 31, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加帮助中心成功！", "article_list.aspx", "Success");
            }
        }
    }
}
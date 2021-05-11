using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_product_category_edit : ManagePage
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
            ChkAdminLevel(this.Page, 30, "View"); //检查权限
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_product_category model = new ax_product_category();
        model.GetModel(_id);

        txttitle.Text = model.title;
        txtSortId.Text = model.sort_id.ToString();
        txtremark.Text = model.remark;
    }
    #endregion



    #region 添加操作=================================
    private bool DoAdd()
    {
        ax_product_category model = new ax_product_category();
        if (model.Exists(txttitle.Text.Trim()))
        {
            JscriptMsg(this.Page, "您输入的快递公司名称已经存在，请检查！", "", "Error");
            return false;
        }

        model.title = txttitle.Text.Trim();
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.remark = txtremark.Text.Trim();
        if (model.Add() > 0)
        {
            AddAdminLog("添加", "添加快递公司：" + txttitle.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_product_category model = new ax_product_category();
        if (model.Exists(txttitle.Text.Trim(), _id))
        {
            JscriptMsg(this.Page, "您输入的快递公司名称已经存在，请检查！", "", "Error");
            return false;
        }
        model.GetModel(_id);

        model.title = txttitle.Text.Trim();
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.remark = txtremark.Text.Trim();

        if (model.Update())
        {
            AddAdminLog("修改", "修改快递公司:" + txttitle.Text); //记录日志
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
            if (ChkAdminLevel(this.Page, 30, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }

                JscriptMsg(this.Page, "修改快递公司信息成功！", Utils.CombUrlTxt("product_category_list.aspx", "page={0}", this.page.ToString()), "Success");
            }
        }
        else //添加
        {    
            //检查权限
            if (ChkAdminLevel(this.Page, 30, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加快递公司信息成功！", "product_category_list.aspx", "Success");
            }
        }
    }

}
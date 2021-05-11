using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class sysmanager_manager_edit : ManagePage
{
    protected int page;
    string defaultpassword = "0|0|0|0"; //默认显示密码
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
        if (action == "Edit") //修改
        {
            txtUserName.Attributes.Remove("ajaxurl");
        }
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 29, "View"); //检查权限
            RoleBind(ddlRoleId);//绑定角色
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }


    #region 角色类型=================================
    private void RoleBind(DropDownList ddl)
    {
        ax_manager_role bll = new ax_manager_role();
        DataTable dt = bll.GetList("1=1 order by id desc").Tables[0];
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("请选择角色...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToInt32(dr["is_sys"]) == 0)
            {
                ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
            }
        }
    }
    #endregion
 
    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_manager model = new ax_manager();
        model.GetModel(_id);
        ddlRoleId.SelectedValue = model.role_id.ToString();

        txtUserName.Text = model.user_name;
        if (_id == 1)//admin账号不能修改
        {
            txtUserName.ReadOnly = true;
        }
        
        if (!string.IsNullOrEmpty(model.password))
        {
            txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
        }
        txtRealName.Text = model.real_name;
        txtmobile.Text = model.mobile;
        txtremark.Text = model.remark;
        if (model.is_lock == 1)
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
        ax_manager model = new ax_manager();

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
 
        //检测用户名是否重复
        if (model.Exists(txtUserName.Text.Trim()))
        {
            JscriptMsg(this.Page, "用户名已经存在，请更换！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        model.real_name = txtRealName.Text.Trim();
        model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.remark = txtremark.Text.Trim();

        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }
        if (model.Add() > 0)
        {
            AddAdminLog("添加", "添加用户：" + txtRealName.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_manager model = new ax_manager();
        model.GetModel(_id);

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
      
        //检测用户名是否重复
        if (model.ExistsE(txtUserName.Text.Trim(), _id))
        {
            JscriptMsg(this.Page, "用户名已经存在，请更换！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        //判断密码是否更改
        if (txtPassword.Text.Trim() != defaultpassword)
        {
            model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        }
        model.real_name = txtRealName.Text.Trim();
        //model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.remark = txtremark.Text.Trim();


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }

        if (model.Update())
        {
            AddAdminLog("修改", "修改用户:" + txtRealName.Text); //记录日志
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
            if (ChkAdminLevel(this.Page, 29, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "修改用户信息成功！", Utils.CombUrlTxt("manager_list.aspx", "page={0}", this.page.ToString()), "Success");
            }
        }
        else //添加
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 29, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加用户信息成功！", "manager_list.aspx", "Success");
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class sysmanager_nav_edit : ManagePage
{

    private string action = "Add"; //操作类型
    private int id = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string _action = AXRequest.GetQueryString("action");
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
            ChkAdminLevel(this.Page, 50, "View"); //检查权限
            ActionTypeBind();//绑定操作权限类型
            TreeBind();//绑定导航菜单
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 绑定导航菜单=============================
    private void TreeBind()
    {
        ax_navigation bll = new ax_navigation();
        DataTable dt = bll.GetList("parent_id=0").Tables[0];

        this.ddlParentId.Items.Clear();
        this.ddlParentId.Items.Add(new ListItem("无父级导航", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlParentId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 绑定操作权限类型=========================
    private void ActionTypeBind()
    {
        cblActionType.Items.Clear();
        foreach (KeyValuePair<string, string> kvp in Utils.ActionType())
        {
            cblActionType.Items.Add(new ListItem(kvp.Value + "(" + kvp.Key + ")", kvp.Key));
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_navigation model = new ax_navigation();
         model.GetModel(_id);

        ddlParentId.SelectedValue = model.parent_id.ToString();
        txtSortId.Text = model.sort_id.ToString();
        if (model.status == 1)
        {
            cbIsLock.Checked = true;
        }
        txtTitle.Text = model.title;
        txtLinkUrl.Text = model.link_url;

        //赋值操作权限类型
        string[] actionTypeArr = model.action_type.Split(',');
        for (int i = 0; i < cblActionType.Items.Count; i++)
        {
            for (int n = 0; n < actionTypeArr.Length; n++)
            {
                if (actionTypeArr[n].ToLower() == cblActionType.Items[i].Value.ToLower())
                {
                    cblActionType.Items[i].Selected = true;
                }
            }
        }
    }
    #endregion

    #region 添加操作=================================
    private bool DoAdd()
    {
        try
        {
            ax_navigation model = new ax_navigation();

            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.status = 0;
            if (cbIsLock.Checked == true)
            {
                model.status = 1;
            }

            model.parent_id = int.Parse(ddlParentId.SelectedValue);
            //添加操作权限类型
            string action_type_str = string.Empty;
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                {
                    action_type_str += cblActionType.Items[i].Value + ",";
                }
            }
            model.action_type = Utils.DelLastComma(action_type_str);

            if (model.Add() > 0)
            {
                AddAdminLog("添加", "添加导航信息：" + model.title); //记录日志
                return true;
            }

        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        try
        {
            ax_navigation model = new ax_navigation();
            model.GetModel(_id);
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.status = 0;
            if (cbIsLock.Checked == true)
            {
                model.status = 1;
            }

            int parentId = int.Parse(ddlParentId.SelectedValue);
            //如果选择的父ID不是自己,则更改
            if (parentId != model.id)
            {
                model.parent_id = parentId;
            }
       
            //添加操作权限类型
            string action_type_str = string.Empty;
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                {
                    action_type_str += cblActionType.Items[i].Value + ",";
                }
            }
            model.action_type = Utils.DelLastComma(action_type_str);
            if (model.Update())
            {
                AddAdminLog("修改", "修改导航信息:" + model.title); //记录日志
                return true;
            }

        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 50, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "修改导航菜单成功！", "nav_list.aspx", "Success");
            }
        }
        else //添加
        {          
            //检查权限
            if (ChkAdminLevel(this.Page, 50, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加导航菜单成功！", "nav_list.aspx", "Success");
            }
        }
    }
}
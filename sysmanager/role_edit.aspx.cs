using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class sysmanager_role_edit : ManagePage
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
            ChkAdminLevel(this.Page, 34, "View"); //检查权限
            NavBind();//导航菜单
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_manager_role model = new ax_manager_role();
        model.GetModel(_id);
        txtRoleName.Text = model.role_name;
  
       // 管理权限
        if (model.manager_role_values != null)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int nav_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    ax_manager_role_value modelt = model.manager_role_values.Find(p => p.nav_id == nav_id && p.action_type == cblActionType.Items[n].Value);
                    if (modelt != null)
                    {
                        cblActionType.Items[n].Selected = true;
                    }
                }
            }
        }


        //for (int i = 0; i < rptList.Items.Count; i++)
        //{
        //    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
        //    int nav_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
        //    ax_manager_role_value bll = new ax_manager_role_value();
        //    if (bll.QXExists(_id, nav_id))
        //    {
        //       cb.Checked = true;
        //    }
        //}
    }
    #endregion

    #region 导航菜单=================================
    private void NavBind()
    {
        ax_navigation bll = new ax_navigation();
        DataTable dt = bll.GetList("1=1 order by sort_id").Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }
    #endregion


    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //美化导航树结构
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string LitImg1 = "<span class=\"folder-open\"></span>";
            string LitImg2 = "<span class=\"folder-line\"></span>";

            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 0)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, 0, LitImg2, LitImg1);
            }
            //绑定导航权限资源
            string[] actionTypeArr = ((HiddenField)e.Item.FindControl("hidActionType")).Value.Split(',');
            CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
            cblActionType.Items.Clear();
            for (int i = 0; i < actionTypeArr.Length; i++)
            {
                if (Utils.ActionType().ContainsKey(actionTypeArr[i]))
                {
                    cblActionType.Items.Add(new ListItem(" " + Utils.ActionType()[actionTypeArr[i]] + " ", actionTypeArr[i]));
                }
            }
        }
    }

    #region 添加操作=================================
    private bool DoAdd()
    {
        bool result = false;

        ax_manager_role model = new ax_manager_role();

        model.role_name = txtRoleName.Text.Trim();
        model.role_type = 1;
        model.is_sys = 0;

        //管理权限
        List<ax_manager_role_value> ls = new List<ax_manager_role_value>();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int nav_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            for (int n = 0; n < cblActionType.Items.Count; n++)
            {
                if (cblActionType.Items[n].Selected == true)
                {
                    ls.Add(new ax_manager_role_value { nav_id = nav_id, action_type = cblActionType.Items[n].Value });
                }
            }
        }
        model.manager_role_values = ls;

        if (model.Add() > 0)
        {
            AddAdminLog("添加", "添加角色:" + model.role_name); //记录日志
            result = true;
        }
        return result;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ax_manager_role model = new ax_manager_role();
        model.GetModel(_id);

        model.role_name = txtRoleName.Text.Trim();

        //管理权限
        List<ax_manager_role_value> ls = new List<ax_manager_role_value>();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int nav_id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            for (int n = 0; n < cblActionType.Items.Count; n++)
            {
                if (cblActionType.Items[n].Selected == true)
                {
                    ls.Add(new ax_manager_role_value { role_id = _id, nav_id = nav_id, action_type = cblActionType.Items[n].Value });
                }
            }
        }
        model.manager_role_values = ls;

        if (model.Update())
        {
            AddAdminLog("修改", "修改角色:" + model.role_name); //记录日志
            result = true;
        }
        result = true;
        return result;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 34, "Edit"))
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "角色权限设置成功！", "", "Success");
            }
        }
        else //添加
        {
            //检查权限
            if (ChkAdminLevel(this.Page, 34, "Add"))
            {
                if (!DoAdd())
                {
                    JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg(this.Page, "添加角色权限成功！", "role_list.aspx", "Success");
            }
        }
    }
}
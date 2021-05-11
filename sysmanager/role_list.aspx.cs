using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_role_list : ManagePage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 34, "View"); //检查权限
            RptBind();
        }
    }

    #region 数据绑定=================================
    private void RptBind()
    {
        ax_manager_role bll = new ax_manager_role();
        this.rptList.DataSource = bll.GetList("0=0 order by role_type");
        this.rptList.DataBind();

    }
    #endregion

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 34, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_manager_role bll = new ax_manager_role();
            bll.GetModel(caId);
            string title = bll.role_name;
            ax_manager bllpp = new ax_manager();
            if (!bllpp.ExistsRole(caId))//查找是否存在该角色的用户记录
            {
                bll.Delete(caId);
                AddAdminLog("删除", "删除角色：" + title + ""); //记录日志
                JscriptMsg(this.Page, " 删除成功", "role_list.aspx", "Success");

            }
            else
            {
                JscriptMsg(this.Page, "已有用户属于该角色，不能删除！", "", "Error");
                return;
            }
        } 
    }
    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ax_manager_role bll = new ax_manager_role();
        Repeater rptList = new Repeater();
        rptList = this.rptList;

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 1;
            }
            bll.UpdateField(id, "role_type=" + sortId.ToString());
        }
        JscriptMsg(this.Page, " 排序保存成功", "role_list.aspx", "Success");
    }


}

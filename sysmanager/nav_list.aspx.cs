using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_nav_list : ManagePage
{   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 50, "View"); //检查权限
            RptBind();
        }
    }

    #region 数据绑定=================================
    private void RptBind()
    {
        ax_navigation bll = new ax_navigation();
        this.rptList.DataSource = bll.GetList("0=0 order by sort_id");
        this.rptList.DataBind();

    }
    #endregion

    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
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
                LitFirst.Text = string.Format(LitStyle, 24, LitImg2, LitImg1);
            }
        }
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        //检查权限
        if (ChkAdminLevel(this.Page, 50, "Delete"))
        {
            // 当前点击的按钮
            LinkButton lb = (LinkButton)sender;
            int caId = int.Parse(lb.CommandArgument);
            ax_navigation bll = new ax_navigation();
            bll.GetModel(caId);
            string title = bll.title;
            bll.Delete(caId);
            AddAdminLog("删除", "删除导航：" + title + ""); //记录日志
            JscriptMsg(this.Page, " 删除成功", "nav_list.aspx", "Success");
        }
    }
    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ax_navigation bll = new ax_navigation();
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
            bll.UpdateField(id, "sort_id=" + sortId.ToString());
        }
        JscriptMsg(this.Page, " 排序保存成功", "nav_list.aspx", "Success");
    }

}

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='login.aspx'</script>");
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            articleBind();
        }
    }

    #region 绑定菜单=================================

    protected void articleBind()
    {

        string sqlstr = "parent_id=0 and id in(select nav_id from ax_manager_role_value where action_type='Show' and role_id=" + Convert.ToInt32(Session["RoleID"]) + ")  order by sort_id";    
 
        ax_navigation bll = new ax_navigation();
        this.repCategory.DataSource = bll.GetList(sqlstr);
        this.repCategory.DataBind();
 
    }

    protected void bsClassList(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row["ID"].ToString());//获得对应ID
            Repeater sClass = (Repeater)e.Item.FindControl("childCategory");//找到要绑定数据的Repeater
            if (sClass != null)
            {
                string sqlstr = "parent_id=" + ID + "  and id in(select nav_id from ax_manager_role_value where action_type='Show' and  role_id=" + Convert.ToInt32(Session["RoleID"]) + ")  order by sort_id";          
          
                ax_navigation bll = new ax_navigation();
                sClass.DataSource = bll.GetList(sqlstr);
                sClass.DataBind();
            }
        }
    }

    #endregion
}
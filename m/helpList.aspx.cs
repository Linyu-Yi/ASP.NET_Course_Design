using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class m_helpList : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddr();
        }
    }
    //绑定记录
    public void binddr()
    {
        ax_article bll = new ax_article();

        string sqlstr = "category_id =2 and status=1 order by sort_id asc, add_time desc";

        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        //PagedDataSource pds = new PagedDataSource();
        //AspNetPager1.RecordCount = dv.Count;
        //pds.DataSource = dv;
        //pds.AllowPaging = true;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;
        repCategory.DataSource = dv;
        repCategory.DataBind();
    }
    // 分页
    //protected void AspNetPager1_PageChanged(object src, EventArgs e)
    //{
    //    binddr();
    //}

}
using System;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            noticeBind();//幻灯
        }
    }

    #region 绑定幻灯=================================
    protected void noticeBind()
    {
        ax_article bll = new ax_article();
        this.rptList_notice.DataSource = bll.GetList(8, " category_id =3 and status=1 ", " sort_id asc, add_time desc");
        this.rptList_notice.DataBind();
    }
    #endregion
}
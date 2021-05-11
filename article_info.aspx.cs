using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class article_info : System.Web.UI.Page
{
    private int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            ShowInfo(this.id);
        }
    }
    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_article model = new ax_article();
        model.GetModel(_id);
        LitTitle.Text = model.title;
        LitContactus.Text = model.content;
    }
    #endregion
}
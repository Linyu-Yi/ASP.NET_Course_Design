using System;
using System.Web.UI;

public partial class m_Contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowInfo(6);
        }
    }
    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_article model = new ax_article();
        model.GetModel(_id);

        LitContactus.Text = model.content;
    }
    #endregion
}
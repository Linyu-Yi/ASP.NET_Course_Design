using System;

public partial class topadmin : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            Lit_Name.Text = Session["RealName"].ToString();
        }
    }

    //安全退出
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("AdminName", "AoXiang", -14400);
        Utils.WriteCookie("RoleID", "AoXiang", -14400);
        Utils.WriteCookie("AID", "AoXiang", -14400);
        Utils.WriteCookie("RealName", "AoXiang", -14400);
        Utils.WriteCookie("DepotID", "AoXiang", -14400);


        Session["RememberName"] = null;
        Session["AdminName"] = null;
        Session["RoleID"] = null;
        Session["AID"] = null;
        Session["RealName"] = null;
        Session["DepotID"] = null;

        Response.Write("<script>parent.location.href='login.aspx'</script>");
        Response.End();
    }
}
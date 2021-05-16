using System;

public partial class identityLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        ax_ticket model = new ax_ticket();
        if (model.Existsfb(orderno.Value.Trim(),2))
        {
            model.GetModel(orderno.Value.Trim());
            if (model.add_time < DateTime.Now)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！您查询的券是真的，但已经过期了，不能在提货了，如有问题请联系客服！</div>\").time(5000);</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>恭喜！您输入的提货编码是真的！可以去申请提货了，亲！</div>\").time(5000);</script>");
            }
              
        }
        else if (model.Existsfb(orderno.Value.Trim(), 3))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>您输入的提货编码提过货了！可以去查询订单查询订单信息了，亲！</div>\").time(5000);</script>");
            
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>没有查到您输入的提货编码，请确认输入是否正确！</div>\").time(5000);</script>");
            
        }
    }
}
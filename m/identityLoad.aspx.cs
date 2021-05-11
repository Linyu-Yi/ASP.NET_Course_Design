using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class m_identityLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkcode.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcode.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"验证码错误\");</script>");
            checkcode.Value = "";
            return;
        }
        ax_ticket model = new ax_ticket();
        if (model.Existsfb(code.Value.Trim(),2))
        {
            model.GetModel(code.Value.Trim());
            if (model.add_time < DateTime.Now)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"对不起！您查询的券是真的，但已经过期了，不能在提货了，如有问题请联系客服！\");</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"恭喜！您输入的提货编码是真的！可以去申请提货了，亲！\");</script>");
            }
      
            checkcode.Value = "";
        }
        else if (model.Existsfb(code.Value.Trim(), 3))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"您输入的提货编码提过货了！可以去查询订单查询订单信息了，亲！\");</script>");
            checkcode.Value = "";
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"没有查到您输入的提货编码，请确认输入是否正确！\");</script>");
            checkcode.Value = "";
        }
    }
}
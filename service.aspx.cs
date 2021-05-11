using System;

public partial class service : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //退换货申请
    protected void btnSQ_Click(object sender, EventArgs e)
    {
        if (checkcode.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcode.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>验证码错误</div>\").time(5000);</script>");
            checkcode.Value = "";
            return;
        }
        ax_orders bll = new ax_orders();
        if (!bll.Existsoe(orderno.Value.Trim(), expno.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！没有找到您输入的订单号和快递单号相关记录，请检查输入是否有误！</div>\").time(5000);</script>");
            return;
        }

        ax_service model = new ax_service();

        model.order_no = orderno.Value.Trim();
        model.express_no = expno.Value.Trim();
        model.content = memo.Value.Trim();
        model.user_name = linkman.Value.Trim();
        model.user_tel = linkphone.Value.Trim();
        model.img_url1 = txtImgUrl1.Text.Trim();
        model.img_url2 = txtImgUrl2.Text.Trim();
        model.img_url3 = txtImgUrl3.Text.Trim();
        model.img_url4 = txtImgUrl4.Text.Trim();
        model.img_url5 = txtImgUrl5.Text.Trim();
  
        if (model.Add() > 0)
        {      
            checkcode.Value = "";
            orderno.Value = "";
            expno.Value = "";
            memo.Value = "";
            linkman.Value = "";
            linkphone.Value = "";
            txtImgUrl1.Text = "";
            txtImgUrl2.Text = "";
            txtImgUrl3.Text = "";
            txtImgUrl4.Text = "";
            txtImgUrl1.Text = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>提交成功！我们会及时处理并和您联系！感谢您的支持！</div>\").time(5000);</script>");
    
        }

    }
   // 投诉建议
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkcodes.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcodes.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>验证码错误</div>\").time(5000);</script>");
            checkcodes.Value = "";
            return;
        }
        ax_feedback model = new ax_feedback();

        model.title = title.Value.Trim();
        model.co = cmpname.Value.Trim();
        model.content = content.Value.Trim();
        model.user_name = name.Value.Trim();
        model.user_tel = tel.Value.Trim();
        model.address = addr.Value.Trim();

        if (model.Add() > 0)
        {
            title.Value = "";
            cmpname.Value = "";
            content.Value = "";
            name.Value = "";
            tel.Value = "";
            addr.Value = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>提交成功！我们会及时和您联系！感谢您的支持！</div>\").time(5000);</script>");
        }
    }
}
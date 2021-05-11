using System;

public partial class m_service : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //退换货申请
    protected void btnSQ_Click(object sender, EventArgs e)
    {
        if (checkcode.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcode.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"验证码错误\");</script>");
            checkcode.Value = "";
            return;
        }
        ax_orders bll = new ax_orders();
        if (!bll.Existsoe(orderno.Value.Trim(), expno.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"对不起！没有找到您输入的订单号和快递单号相关记录，请检查输入是否有误！\");</script>");
            return;
        }

        ax_service model = new ax_service();

        model.order_no = orderno.Value.Trim();
        model.express_no = expno.Value.Trim();
        model.content = memo.Value.Trim();
        model.user_name = linkman.Value.Trim();
        model.user_tel = linkphone.Value.Trim();

        if (FileUpload1.PostedFile.FileName != "")
        {
            DateTime now = DateTime.Now;
            string ImgName = now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Millisecond.ToString();
            string ImgPath = FileUpload1.PostedFile.FileName;
            string ImgExtend = ImgPath.Substring(ImgPath.LastIndexOf(".") + 1);
            if (!(ImgExtend == "bmp" || ImgExtend == "jpg" || ImgExtend == "gif" || ImgExtend == "png"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"请上传bmp|jpg|gif|png格式的图片文件!\");</script>");
                return;
            }
            string ServerPath = Server.MapPath("../upload/m/") + ImgName + "." + ImgExtend;
            FileUpload1.PostedFile.SaveAs(ServerPath);
            model.img_url1 = "/upload/m/" + ImgName + "." + ImgExtend;
        }
        if (FileUpload2.PostedFile.FileName != "")
        {
            DateTime now = DateTime.Now;
            string ImgName = now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Millisecond.ToString();
            string ImgPath = FileUpload2.PostedFile.FileName;
            string ImgExtend = ImgPath.Substring(ImgPath.LastIndexOf(".") + 1);
            if (!(ImgExtend == "bmp" || ImgExtend == "jpg" || ImgExtend == "gif" || ImgExtend == "png"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"请上传bmp|jpg|gif|png格式的图片文件!\");</script>");
                return;
            }
            string ServerPath = Server.MapPath("../upload/m/") + ImgName + "." + ImgExtend;
            FileUpload2.PostedFile.SaveAs(ServerPath);
            model.img_url2 = "/upload/m/" + ImgName + "." + ImgExtend;
        }


        if (model.Add() > 0)
        {      
            checkcode.Value = "";
            orderno.Value = "";
            expno.Value = "";
            memo.Value = "";
            linkman.Value = "";
            linkphone.Value = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"提交成功！我们会及时处理并和您联系！感谢您的支持！\");</script>");
      
        }

    }
    // 投诉建议
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkcodes.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcodes.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">alert(\"验证码错误\");</script>");
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
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script type=\"text/javascript\">提交成功！我们会及时和您联系！感谢您的支持！\");</script>");
        }
    }
}
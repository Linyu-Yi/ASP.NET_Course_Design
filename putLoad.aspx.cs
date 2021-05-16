using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class putLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        ax_ticket model = new ax_ticket();
        if (model.Existsfb(ticketno.Value.Trim(), 3))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>亲！您输入的提货编码提过货了！可以去查询订单查询订单信息了!</div>\").time(5000);</script>");
            
            return;
        }
        if (!model.Exists(ticketno.Value.Trim(), ticketpw.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！没有找到您输入信息的相关记录，请检查是否输入有误！</div>\").time(5000);</script>");
        }
        else
        {

            model.GetModel(ticketno.Value.Trim());
            if (model.add_time < DateTime.Now)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！您查询的券已经过期了，不能在提货了，如有问题请联系客服！</div>\").time(5000);</script>");
            }
            else
            {
                ShopCart.Add(model.GetID(ticketno.Value.Trim(), ticketpw.Value.Trim()), 1);
                PanelOrder.Visible = true;
               
            }    
        }
    }

   

    

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //检查商品
        IList<cart_items> iList = ShopCart.GetList();
        
        //保存订单=======================================================================
        ax_orders model = new ax_orders();
        model.order_no = Utils.GetOrderNumber(); //订单号
        model.user_name = user_name.Value.Trim();
        model.user_tel = user_tel.Value.Trim();
        string province = AXRequest.GetFormString("province");
        string city = AXRequest.GetFormString("city");
        string area = AXRequest.GetFormString("area");
        model.area = province + "," + city + "," + area;
        model.address = address.Value.Trim();
        model.message = message.Value.Trim();

        string goods_title = "";
        //商品详细列表
        List<ax_order_goods> gls = new List<ax_order_goods>();
        foreach (cart_items item in iList)
        {
            ax_ticket myt = new ax_ticket();
            myt.GetModel(item.id);
            goods_title = new ax_article().GetTitle(Convert.ToInt32(myt.pid));
            gls.Add(new ax_order_goods { ticket_id = item.id, goods_id = myt.pid,goods_title = goods_title, ticket_no = item.ticket_no });

        }
        model.order_goods = gls;    

        if (model.Add() == 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>订单保存过程中发生错误，请重新提交！</div>\").time(5000);</script>");
            return;
        }
       
        #region 发送短信并入库
        ax_syssetting mySysSetting = new ax_syssetting();
        mySysSetting.GetModel(1);
        if (mySysSetting.MsgNum > 0 && mySysSetting.MsgOn == 1)
        {
            string user = mySysSetting.MsgName;

            string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(mySysSetting.MsgPwd, "MD5").ToLower(), "MD5").ToLower();
            string mobile = user_tel.Value.Trim();
            string content = "尊敬的" + user_name.Value.Trim() + "客户,您的" + goods_title + "订单号:" + model.order_no + "提交成功！我们会尽快给您安排发货,请注意查收!发货信息将会发送到您的手机上!请您留意!【AH水产】";
            string contentEncode = HttpUtility.UrlEncode(content, System.Text.Encoding.GetEncoding("utf-8"));
            string sms_url = " http://210.5.152.50:7100/submit?userName=" + user + "&body={'content':'" + contentEncode + "','passWord':'" + pass + "','expId':'','phones':['" + mobile + "'],'productId':'21','sendTime':''}&isEncrypt=0";

            SMS mysms = new SMS();
            mysms.GetHtmlFromUrl(sms_url);

            ax_msglist my = new ax_msglist();
            my.CardNum = model.order_no;
            my.MemberName = user_name.Value.Trim();
            my.MemberTel = mobile;
            my.Message = content;
            my.SendTime = System.DateTime.Now;
            my.OP = "提货短信";
            my.Add();

            mySysSetting.MsgNum = mySysSetting.MsgNum - 1;
            mySysSetting.UpdateMsgNum();
        }

        #endregion

        //清空购物车
        ShopCart.Clear("0");
        PanelOrder.Visible = false;
        this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>恭喜您！订单提交成功！我们会尽快给您安排发货，请注意查收！发货信息将会发送到您的手机上！请您留意！</div>\").time(5000);</script>");
    }
}
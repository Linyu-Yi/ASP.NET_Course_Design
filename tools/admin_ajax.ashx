<%@ WebHandler Language="C#" Class="admin_ajax" %>

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;


public class admin_ajax : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = AXRequest.GetQueryString("action");

        switch (action)
        {
            case "edit_order_status": //修改订单信息和状态
                edit_order_status(context);
                break;   
                 
            case "manager_validate": //验证管理员用户名是否重复
                manager_validate(context);
                break;
         
        }

    }
    #region 返回礼品名称=============================
    protected string GetTicketgoods_title(long _id)
    {
        string _title = string.Empty;
        ax_order_goods bll = new ax_order_goods();
        DataTable dt = bll.GetList(_id);

        foreach (DataRow dr in dt.Rows)
        {
            _title = _title + dr["goods_title"].ToString().Trim() + ",";
        }

        return Utils.DelLastComma(_title);
    }
    #endregion
    
    #region 修改订单信息和状态==============================
    private void edit_order_status(HttpContext context)
    {
        //取得登录信息
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"未登录或已超时，请重新登录！\"}");
            return;
        }

        string order_no = AXRequest.GetString("order_no");
        string edit_type = AXRequest.GetString("edit_type");

        if (order_no == "")
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"传输参数有误，无法获取订单号！\"}");
            return;
        }
        if (edit_type == "")
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"无法获取修改订单类型！\"}");
            return;
        }
        ax_orders model = new ax_orders();
        model.GetModel(order_no);
        if (!model.Exists(order_no))
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"订单号不存在或已被删除！\"}");
            return;
        }
        switch (edit_type.ToLower())
        {
            
            case "order_express": //确认发货
     
                int express_id = AXRequest.GetFormInt("express_id");
                int depot_category_id = AXRequest.GetFormInt("depot_category_id");
                string express_no = AXRequest.GetFormString("express_no");
                if (express_id == 0)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请选择快递公司！\"}");
                    return;
                }
                if (depot_category_id == 0)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请选择发货仓库！\"}");
                    return;
                }
                model.depot_category_id = depot_category_id;
                model.product_category_id = express_id;
                model.product_no = express_no;
                model.status = 2;
                model.confirm_time = DateTime.Now;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单发货失败！\"}");
                    return;
                }
                #region 发送短信并入库
                ax_syssetting mySysSetting = new ax_syssetting();
                mySysSetting.GetModel(1);
                if (mySysSetting.MsgNum > 0 && mySysSetting.MsgOn == 1)
                {
                string user = mySysSetting.MsgName;

                string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mySysSetting.MsgPwd, "MD5").ToLower(), "MD5").ToLower();
                string mobile = model.user_tel.Trim();
                    //尊敬的***客户，您的***（礼盒名称）已通过****（快递公司）的****（单号）单号发货，请您注意查收！感谢您对我们的支持！【AH水产】

                string content = "尊敬的" + model.user_name + "您的" + GetTicketgoods_title(int.Parse(model.id.ToString())) + "已通过" + new ax_product_category().GetTitle(Convert.ToInt32(model.product_category_id)) + "的" + model.product_no + "单号发货,请您注意查收!感谢您对我们的支持!【AH水产】";
                string contentEncode = HttpUtility.UrlEncode(content, System.Text.Encoding.GetEncoding("utf-8"));
                string sms_url = " http://210.5.152.50:7100/submit?userName=" + user + "&body={'content':'" + contentEncode + "','passWord':'" + pass + "','expId':'','phones':['" + mobile + "'],'productId':'21','sendTime':''}&isEncrypt=0";

                SMS mysms = new SMS();
                mysms.GetHtmlFromUrl(sms_url);

                ax_msglist my = new ax_msglist();
                my.CardNum = model.order_no;
                my.MemberName = model.user_name.Trim();
                my.MemberTel = mobile;
                my.Message = content;
                my.SendTime = System.DateTime.Now;
                my.OP = "发货短信";
                my.Add();

                mySysSetting.MsgNum = mySysSetting.MsgNum - 1;
                mySysSetting.UpdateMsgNum();
                }

                #endregion
                context.Response.Write("{\"status\": 1, \"msg\": \"订单发货成功！\"}");
                break;
            case "order_complete": //完成订单=========================================

                if (model.status > 2)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能重复处理！\"}");
                    return;
                }
                model.status = 3;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认订单完成失败！\"}");
                    return;
                }

                context.Response.Write("{\"status\": 1, \"msg\": \"确认订单完成成功！\"}");
                break;
            case "order_cancel": //取消订单==========================================

                if (model.status > 2)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能取消订单！\"}");
                    return;
                }
                model.status = 4;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"取消订单失败！\"}");
                    return;
                }

                context.Response.Write("{\"status\": 1, \"msg\": \"取消订单成功！\"}");
                break;
                
            case "edit_order_remark": //修改订单备注=================================
                string remark = AXRequest.GetFormString("remark");
                if (remark == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请填写订单备注内容！\"}");
                    return;
                }
                model.remark = remark;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"修改订单备注失败！\"}");
                    return;
                }
                context.Response.Write("{\"status\": 1, \"msg\": \"修改订单备注成功！\"}");
                break;
                
            case "edit_accept_info": //修改收货信息====================================

                if (model.status == 2)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经送货，不能修改收货信息！\"}");
                    return;
                }
                string accept_name = AXRequest.GetFormString("accept_name");
                string province = AXRequest.GetFormString("province");
                string city = AXRequest.GetFormString("city");
                string area = AXRequest.GetFormString("area");
                string address = AXRequest.GetFormString("address");
                string tel = AXRequest.GetFormString("mobile");
   

                if (accept_name == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请填写收货人姓名！\"}");
                    return;
                }
                if (area == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请选择所在地区！\"}");
                    return;
                }
                if (address == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请填写详细的收货地址！\"}");
                    return;
                }
                if (tel == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请填写收货人联系手机！\"}");
                    return;
                }

                model.user_name = accept_name;
                model.area = province + "," + city + "," + area;
                model.address = address;
                model.user_tel = tel;
     
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"修改收货人信息失败！\"}");
                    return;
                }
               
                context.Response.Write("{\"status\": 1, \"msg\": \"修改收货人信息成功！\"}");
                break;
         

        }

    }
    #endregion
    
    #region 验证用户账号是否重复========================
    private void manager_validate(HttpContext context)
    {
        string user_name = AXRequest.GetString("param");
        if (string.IsNullOrEmpty(user_name))
        {
            context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
            return;
        }
        ax_manager bll = new ax_manager();
        if (bll.Exists(user_name))
        {
            context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
        return;
    }
    #endregion


  
    
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
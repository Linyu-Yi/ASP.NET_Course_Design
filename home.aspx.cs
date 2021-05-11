using System;
using System.Data;
using System.Web.Security;

public partial class home : System.Web.UI.Page
{
    protected string msg = "";
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
            Bind();//待发货订单
            noticeBind();//售后服务

            /*
            //更新短信条数
            ax_syssetting mySysSetting = new ax_syssetting();
            mySysSetting.GetModel(1);

            string user = mySysSetting.MsgName;
            string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(mySysSetting.MsgPwd, "MD5").ToLower(), "MD5").ToLower();
            string sms_url = "http://210.5.152.50:7100/balance?userName=" + user + "&body= {'passWord':'" + pass + "'}&isEncrypt=0";

            SMS mysms = new SMS();
            try
            {
                string[] ArrayVid = mysms.GetHtmlFromUrl(sms_url).Split(':');
                if (ArrayVid.Length == 2)
                {
                    mySysSetting.MsgNum = Convert.ToInt64(ArrayVid[1].Substring(0, ArrayVid[1].Length - 2));
                    mySysSetting.UpdateMsgNum();
                }
            }
            catch (Exception ex)
            {

            }
            */

        }
    }

    #region 绑定待发货订单=================================
    protected void Bind()
    {
        ax_orders bll = new ax_orders();
        this.rptList.DataSource = bll.GetList(13, " status=1", " add_time desc");
        this.rptList.DataBind();
    }
    #endregion

    #region 绑定售后服务=================================
    protected void noticeBind()
    {
        ax_service bll = new ax_service();
        this.rptList_notice.DataSource = bll.GetList(13, " 1=1 ", " add_time desc");
        this.rptList_notice.DataBind();
    }
    #endregion

    #region 返回订单状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "已提货";
                break;
            case 2:
                _title = "<font color=blue>已发货</font>";
                break;
            case 3:
                _title = "<font color=green>已完成</font>";
                break;
            case 4:
                _title = "<font color=red>已取消</font>";
                break;
        }

        return _title;
    }
    #endregion

    #region 返回礼券编号=============================
    protected string GetTicketNoStatus(int _id)
    {
        string _title = string.Empty;
        ax_order_goods bll = new ax_order_goods();
        DataTable dt = bll.GetList(_id);

        foreach (DataRow dr in dt.Rows)
        {
            _title = _title + dr["ticket_no"].ToString().Trim() + "&nbsp;,";
        }

        return Utils.DelLastComma(_title);
    }
    #endregion
   
   
}
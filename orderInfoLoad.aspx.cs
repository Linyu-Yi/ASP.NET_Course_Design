using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Data;

public partial class orderInfoLoad : System.Web.UI.Page
{
    public string nu = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkcode.Value.Trim().Equals("") || Session["SESSION_CODE"].ToString().Trim() != checkcode.Value.Trim())
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>验证码错误</div>\").time(5000);</script>");
            checkcode.Value = "";
            return;
        }
        ax_orders model = new ax_orders();
        if (!model.Exists(orderno.Value.Trim(), recvmobile.Value.Trim()))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script> $.alert(\"<div class='message'>对不起！没有找到您输入的信息的相关订单记录，请检查是否输入有误！</div>\").time(5000);</script>");

        }
        else
        {
            ShowInfo(orderno.Value.Trim());
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(string _order_no)
    {
        PanelOrder.Visible = true;
        ax_orders model = new ax_orders();
        model.GetModel(_order_no);
        contact_address.Text = model.address;
        contact_name.Text = model.user_name;
        contact_tel.Text = model.user_tel;

        message.Text = model.message;
        remark.Text = model.remark;
        if (Convert.ToInt32(model.depot_category_id) != 0)
        {
            depot_category.Text = new ax_depot_category().GetTitle(Convert.ToInt32(model.depot_category_id));
        }
        else
        {
            depot_category.Text = "<font color=red>未出库</font>";
        }

        if (Convert.ToInt32(model.product_category_id) != 0)
        {
            product_category.Text = new ax_product_category().GetTitle(Convert.ToInt32(model.product_category_id));
            product_no.Text = model.product_no;
            nu = " <a href=\" http://m.kuaidi100.com/result.jsp?com=&nu=" + model.product_no + "+\" target=\"_blank\">【点击查询物流信息】</a>";
            //LitExpInfo.Text = ShowExp(product_category.Text.Trim(), product_no.Text.Trim());
        }
        else
        {
            product_category.Text = "<font color=red>未发货</font>";
            product_no.Text = "<font color=red>未发货</font>";
        }
        //绑定商品列表
        ax_order_goods bll = new ax_order_goods();
        string sql = " order_id =" + model.id;

        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }
    #endregion

    private string ShowExp(string _typeCom, string _nu)
     {
        string ApiKey = "0fefe505dc38fdce";//在快递100网站申请的APIKey
        string typeCom = _typeCom;
		string nu=_nu;
		string powered = "快递数据由: <a href=\"http://www.kuaidi100.com/?refer=hishop\" target=\"_blank\">快递100</a> 提供";

        if (typeCom == "顺丰速递")
        {
            typeCom = "shunfeng";
        }
		if(typeCom=="AAE全球专递"){
			typeCom="aae";
		}
		if(typeCom=="安捷快递"){
			typeCom="anjiekuaidi";
		}
		if(typeCom=="安信达快递"){
			typeCom="anxindakuaixi";
		}
		if(typeCom=="百福东方"){
			typeCom="baifudongfang";
		}	
		if(typeCom=="彪记快递"){
			typeCom="biaojikuaidi";
		}	
		if(typeCom=="BHT"){
			typeCom="bht";
		}	
		if(typeCom=="BHT"){
			typeCom="bht";
		}	
		if(typeCom=="希伊艾斯快递"){
			typeCom="cces";
		}
		if(typeCom=="中国东方"){
			typeCom="Coe";
		}
		if(typeCom=="长宇物流"){
			typeCom="changyuwuliu";
		}
		if(typeCom=="大田物流"){
			typeCom="datianwuliu";
		}	
		if(typeCom=="德邦物流"){
			typeCom="debangwuliu";
		}
		if(typeCom=="DPEX"){
			typeCom="dpex";
		}
		if(typeCom=="DHL"){
			typeCom="dhl";
		}	
		if(typeCom=="D速快递"){
			typeCom="dsukuaidi";
		}	
		if(typeCom=="fedex"){
			typeCom="fedex";
		}
		if(typeCom=="飞康达物流"){
			typeCom="feikangda";
		}
		if(typeCom=="凤凰快递"){
			typeCom="fenghuangkuaidi";
		}
		if(typeCom=="港中能达物流"){
			typeCom="ganzhongnengda";
		}
		if(typeCom=="广东邮政物流"){
			typeCom="guangdongyouzhengwuliu";
		}
		if(typeCom=="汇通快运"){
			typeCom="huitongkuaidi";
		}
		if(typeCom=="恒路物流"){
			typeCom="hengluwuliu";
		}
		if(typeCom=="华夏龙物流"){
			typeCom="huaxialongwuliu";
		}
		if(typeCom=="佳怡物流"){
			typeCom="jiayiwuliu";
		}
		if(typeCom=="京广速递"){
			typeCom="jinguangsudikuaijian";
		}
		if(typeCom=="急先达"){
			typeCom="jixianda";
		}
		if(typeCom=="佳吉物流"){
			typeCom="jiajiwuliu";
		}
		if(typeCom=="加运美"){
			typeCom="jiayunmeiwuliu";
		}
		if(typeCom=="快捷速递"){
			typeCom="kuaijiesudi";
		}
		if(typeCom=="联昊通物流"){
			typeCom="lianhaowuliu";
		}
		if(typeCom=="龙邦物流"){
			typeCom="longbanwuliu";
		}
		if(typeCom=="民航快递"){
			typeCom="minghangkuaidi";
		}
		if(typeCom=="配思货运"){
			typeCom="peisihuoyunkuaidi";
		}
		if(typeCom=="全晨快递"){
			typeCom="quanchenkuaidi";
		}
		if(typeCom=="全际通物流"){
			typeCom="quanjitong";
		}
		if(typeCom=="全日通快递"){
			typeCom="quanritongkuaidi";
		}
		if(typeCom=="全一快递"){
			typeCom="quanyikuaidi";
		}
		if(typeCom=="盛辉物流"){
			typeCom="shenghuiwuliu";
		}
		if(typeCom=="速尔物流"){
			typeCom="suer";
		}
		if(typeCom=="盛丰物流"){
			typeCom="shengfengwuliu";
		}
		if(typeCom=="天地华宇"){
			typeCom="tiandihuayu";
		}
		if(typeCom=="天天快递"){
			typeCom="tiantian";
		}
		if(typeCom=="TNT"){
			typeCom="tnt";
		}
		if(typeCom=="UPS"){
			typeCom="ups";
		}
		if(typeCom=="万家物流"){
			typeCom="wanjiawuliu";
		}
		if(typeCom=="文捷航空速递"){
			typeCom="wenjiesudi";
		}
		if(typeCom=="伍圆速递"){
			typeCom="wuyuansudi";
		}
		if(typeCom=="万象物流"){
			typeCom="wanxiangwuliu";
		}
		if(typeCom=="新邦物流"){
			typeCom="xinbangwuliu";
		}
		if(typeCom=="信丰物流"){
			typeCom="xinfengwuliu";
		}
		if(typeCom=="星晨急便"){
			typeCom="xingchengjibian";
		}
		if(typeCom=="鑫飞鸿物流"){
			typeCom="xinhongyukuaidi";
		}
		if(typeCom=="亚风速递"){
			typeCom="yafengsudi";
		}
		if(typeCom=="一邦速递"){
			typeCom="yibangwuliu";
		}
		if(typeCom=="优速物流"){
			typeCom="youshuwuliu";
		}
		if(typeCom=="远成物流"){
			typeCom="yuanchengwuliu";
		}
		if(typeCom=="圆通速递"){
			typeCom="yuantong";
		}
		if(typeCom=="源伟丰快递"){
			typeCom="yuanweifeng";
		}
		if(typeCom=="元智捷诚快递"){
			typeCom="yuanzhijiecheng";
		}
		if(typeCom=="越丰物流"){
			typeCom="yuefengwuliu";
		}
		if(typeCom=="韵达快递"){
			typeCom="yunda";
		}
		if(typeCom=="源安达"){
			typeCom="yuananda";
		}
		if(typeCom=="运通快递"){
			typeCom="yuntongkuaidi";
		}
		if(typeCom=="宅急送"){
			typeCom="zhaijisong";
		}
		if(typeCom=="中铁快运"){
			typeCom="zhongtiewuliu";
		}
		if(typeCom=="中通速递"){
			typeCom="zhongtong";
		}
		if(typeCom=="中邮物流"){
			typeCom="zhongyouwuliu";
		}

        string apiurl = "http://api.kuaidi100.com/api?id=" + ApiKey + "&com="+ typeCom +"&nu="+ nu +"&show=2&muti=1&order=asc";
        //Response.Write(apiurl);
        WebRequest request = WebRequest.Create(@apiurl);
        WebResponse response = request.GetResponse();
        Stream stream = response.GetResponseStream();
        Encoding encode = Encoding.UTF8;
        StreamReader reader = new StreamReader(stream, encode);
        string detail = reader.ReadToEnd();

		return (detail + "<br/>" + powered);
}

}
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticketmanager_ticket_inset : ManagePage
{   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 21, "View"); //检查权限
            TreeBind(); //绑定礼品
        }
    }

    #region 绑定礼品=================================
    private void TreeBind()
    {
        ax_article bll = new ax_article();
        DataTable dt = bll.GetList("category_id =1 order by sort_id asc,id desc").Tables[0];
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("==全部==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
        }

    }
    #endregion

    #region 添加操作=================================
    private bool DoAdd()
    {   
        string one = ddlCategoryId.SelectedValue.Trim();//礼品id
        ax_ticket bllpp = new ax_ticket();
        if (!bllpp.ExistsP(int.Parse(one)))//查找是否存在该礼品的礼券记录
        {
            int ws = one.Length;
            for (int i = 0; i < (8 - ws); i++)
            {
                one = one + "0";
            }
        }
        else
        {
            one = bllpp.GetMaxNo(int.Parse(one)).ToString();
        }
        ax_ticket model = new ax_ticket();
        model.pid = int.Parse(ddlCategoryId.SelectedValue.Trim());
        if (cbIsLock.Checked == true)
        {
            model.status = 2;
        }
        else
        {
            model.status = 1;
        }
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim() + " 23:59:59");

        int[] arr = getNum(int.Parse(txtticket_num.Text.Trim()), 123456, 987654);
        for (int i = 0; i < int.Parse(txtticket_num.Text.Trim()); i++)
        { 
            model.ticket_no = (int.Parse(one) + i+1).ToString();
            model.ticket_pw = arr[i].ToString();
            model.Add();
        }
        AddAdminLog("批量生成", "批量生成礼券规格：" + ddlCategoryId.SelectedItem.Text + "的礼券" + txtticket_num.Text.Trim() + "张"); //记录日志
        return true;

    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {    
        //检查权限
        if (ChkAdminLevel(this.Page, 21, "Build"))
        {
            if (!DoAdd())
            {
                JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg(this.Page, "批量生成礼券信息成功！", "ticket_list.aspx", "Success");
        }
    }

    /// <summary>
    /// 产生无重复随机数
    /// </summary>
    /// <param name="num">个数</param>
    /// <param name="minValue">最小数</param>
    /// <param name="maxValue">最大数</param>
    /// <returns>数组</returns> 
    public int[] getNum(int num, int minValue, int maxValue)
    {
        Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
        int[] arrNum = new int[num];//注意:数组中各元素的初始值是0,当0在取值范围内时要另处理
        int tmp = 0;
        for (int i = 0; i < num; i++)
        {
            tmp = getRandomNum(tmp, minValue, maxValue, ra);//取出值赋到数组中
            if (Array.IndexOf(arrNum, tmp) < 0)//判断是否存在,不存在的话元素tmp的索引应为-1
            {
                arrNum[i] = tmp;
            }
            else
            {
                i = i - 1;
            }
        }
        return arrNum;
    }

    public int getRandomNum(int tmp, int minValue, int maxValue, Random ra)
    {
        tmp = ra.Next(minValue, maxValue);
        return tmp;
    }
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class m_selseSite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //TreeBind(); //绑定全国销售网点
            binddr();
        }
    }

    #region 绑定全国销售网点=================================
    //private void TreeBind()
    //{
    //    ax_sellnet bll = new ax_sellnet();
    //    DataTable dt = bll.GetListAll("select city from ax_sellnet group by city").Tables[0];
    //    this.ddlCity.Items.Clear();
    //    this.ddlCity.Items.Add(new ListItem("==全国销售网点==", ""));
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        string Id = dr["city"].ToString();
    //        string Title = dr["city"].ToString().Trim();
    //        this.ddlCity.Items.Add(new ListItem(Title, Id));
    //    }

    //}
    #endregion

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    binddr();
    //}

    //绑定记录
    public void binddr()
    {
        ax_sellnet bll = new ax_sellnet();
        string sqlstr = "1=1 ";

        //if (this.keys.Value.Trim() != "")
        //{
        //    sqlstr = sqlstr + " and title like '%" + this.keys.Value.Trim() + "%'";
        //}
        //if (this.ddlCity.SelectedValue != "")
        //{
        //    sqlstr = sqlstr + " and city = '" + this.ddlCity.SelectedValue + "'";
        //}

        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();
    }
}
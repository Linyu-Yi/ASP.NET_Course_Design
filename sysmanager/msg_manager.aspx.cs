using System;
using System.Web.UI;
using System.Web.Security;

public partial class sysmanager_msg_manager : ManagePage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ChkAdminLevel(this.Page, 47, "View"); //检查权限
            ShowInfo(1);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ax_syssetting model = new ax_syssetting();
        model.GetModel(_id);
        this.LitMsgNum.Text = model.MsgNum.ToString();
        txtMsgName.Text = model.MsgName;
        txtMsgPwd.Text = model.MsgPwd;
        if (model.MsgOn == 1)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }

    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {   
        //检查权限
        if (ChkAdminLevel(this.Page, 47, "Edit"))
        {
            ax_syssetting mySysSetting = new ax_syssetting();
            mySysSetting.GetModel(1);

            mySysSetting.MsgName = this.txtMsgName.Text.Trim();
            mySysSetting.MsgPwd = this.txtMsgPwd.Text.Trim();

            if (cbIsLock.Checked == true)
            {
                mySysSetting.MsgOn = 1;
            }
            else
            {
                mySysSetting.MsgOn = 0;
            }
            mySysSetting.id = 1;

            if (!mySysSetting.Update())
            {

                JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }

            JscriptMsg(this.Page, " 设置成功！", "", "Success");
        }
    }
}

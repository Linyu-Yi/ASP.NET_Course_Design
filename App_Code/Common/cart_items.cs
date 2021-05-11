using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 购物车实体类
/// </summary>
[Serializable]
public partial class cart_items
{
    public cart_items()
    { }
    #region Model
    private long _id;
    private string _ticket_no;
   
    /// <summary>
    /// 礼品ID
    /// </summary>
    public long id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 礼券编号
    /// </summary>
    public string ticket_no
    {
        set { _ticket_no = value; }
        get { return _ticket_no; }
    }
 
    #endregion
}

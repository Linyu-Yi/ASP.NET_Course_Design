using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using LitJson;

/// <summary>
/// 购物车帮助类
/// </summary>
public partial class ShopCart
{

    #region 基本增删改方法====================================
    /// <summary>
    /// 返回购物车列表
    /// </summary>
    /// <returns>IList</returns>
    public IList<cart_items> get_cart_list()
    {
        IList<cart_items> ls = GetList();
        if (ls == null)
        {
            ls = new List<cart_items>();
        }
        return ls;
    }

    /// <summary>
    /// 获得购物车列表
    /// </summary>
    public static IList<cart_items> GetList()
    {
        IDictionary<string, int> dic = GetCart();
        if (dic != null)
        {
            IList<cart_items> iList = new List<cart_items>();

            foreach (var item in dic)
            {
                ax_ticket model = new ax_ticket();
                model.GetModel(Convert.ToInt32(item.Key));

                cart_items modelt = new cart_items();
                modelt.id = model.id;
                modelt.ticket_no = model.ticket_no;
               
                iList.Add(modelt);
            }
            return iList;
        }
        return null;
    }

    /// <summary>
    /// 添加到购物车
    /// </summary>
    public static bool Add(string Key, int Quantity)
    {
        IDictionary<string, int> dic = GetCart();
        if (dic != null)
        {
            if (dic.ContainsKey(Key))
            {
                dic[Key] += Quantity;
                AddCookies(JsonMapper.ToJson(dic));
                return true;
            }
        }
        else
        {
            dic = new Dictionary<string, int>();
        }
        //不存在的则新增
        dic.Add(Key, Quantity);
        AddCookies(JsonMapper.ToJson(dic));
        return true;
    }

 

    /// <summary>
    /// 移除购物车
    /// </summary>
    /// <param name="Key">主键 0为清理所有的购物车信息</param>
    public static void Clear(string Key)
    {
        if (Key == "0")//为0的时候清理全部购物车cookies
        {
            Utils.WriteCookie("ps_cookie_shopping_cart", "", -43200);
        }
        else
        {
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                dic.Remove(Key);
                AddCookies(JsonMapper.ToJson(dic));
            }
        }
    }
    #endregion


    #region 私有方法==========================================
    /// <summary>
    /// 获取cookies值
    /// </summary>
    private static IDictionary<string, int> GetCart()
    {
        IDictionary<string, int> dic = new Dictionary<string, int>();
        if (!string.IsNullOrEmpty(GetCookies()))
        {
            return JsonMapper.ToObject<Dictionary<string, int>>(GetCookies());
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 添加对象到cookies
    /// </summary>
    /// <param name="strValue"></param>
    private static void AddCookies(string strValue)
    {
        Utils.WriteCookie("ps_cookie_shopping_cart", strValue, 43200); //存储一个月
    }

    /// <summary>
    /// 获取cookies
    /// </summary>
    /// <returns></returns>
    private static string GetCookies()
    {
        return Utils.GetCookie("ps_cookie_shopping_cart");
    }

    #endregion
}

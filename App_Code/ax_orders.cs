using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

	/// <summary>
	/// 类ax_orders。
	/// </summary>
	[Serializable]
	public partial class ax_orders
	{
		public ax_orders()
		{}

        #region Model
        private long _id;
        private string _order_no = "";
        private int? _depot_category_id = 0;
        private int? _product_category_id = 0;
        private string _product_no = "";
        private string _user_name = "";
        private string _user_tel;
        private string _area = "";
        private string _address = "";
        private string _message = "";
        private int? _status = 1;
        private DateTime? _add_time = DateTime.Now;
        private DateTime? _confirm_time;
        private string _remark = "";
        /// <summary>
        /// 自增ID
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no
        {
            set { _order_no = value; }
            get { return _order_no; }
        }
        /// <summary>
        /// 发货仓储id
        /// </summary>
        public int? depot_category_id
        {
            set { _depot_category_id = value; }
            get { return _depot_category_id; }
        }
        /// <summary>
        /// 快递公司id
        /// </summary>
        public int? product_category_id
        {
            set { _product_category_id = value; }
            get { return _product_category_id; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string product_no
        {
            set { _product_no = value; }
            get { return _product_no; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string user_tel
        {
            set { _user_tel = value; }
            get { return _user_tel; }
        }
        /// <summary>
        /// 省市区
        /// </summary>
        public string area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 订单留言
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 订单留言
        /// </summary>
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 订单状态1生成订单,2确认订单,3完成订单,4取消订单
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 确认发货时间
        /// </summary>
        public DateTime? confirm_time
        {
            set { _confirm_time = value; }
            get { return _confirm_time; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        private List<ax_order_goods> _order_goods;
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<ax_order_goods> order_goods
        {
            set { _order_goods = value; }
            get { return _order_goods; }
        }

        #endregion Model

		#region  Method


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("id", "ax_orders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_orders]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 查找是否存在该仓库已经有发货记录
        /// </summary>
        public bool ExistsBM(int depot_category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_orders]");
            strSql.Append(" where depot_category_id=@depot_category_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@depot_category_id", SqlDbType.Int,4)};
            parameters[0].Value = depot_category_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 查找是否存在该快递已经有发货记录
        /// </summary>
        public bool ExistsKD(int product_category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_orders]");
            strSql.Append(" where product_category_id=@product_category_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@product_category_id", SqlDbType.Int,4)};
            parameters[0].Value = product_category_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_orders]");
            strSql.Append(" where order_no=@order_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在订单号和手机号存在的记录
        /// </summary>
        public bool Exists(string _order_no,string _user_tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_orders]");
            strSql.Append(" where order_no=@order_no and user_tel=@user_tel ");
            SqlParameter[] parameters = {
                     new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,100)};
            parameters[0].Value = _order_no;
            parameters[1].Value = _user_tel;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在订单号和物流号存在的记录
        /// </summary>
        public bool Existsoe(string order_no, string product_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_orders]");
            strSql.Append(" where order_no=@order_no and product_no=@product_no ");
            SqlParameter[] parameters = {
                     new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@product_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;
            parameters[1].Value = product_no;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据条件和字段汇总
        /// </summary>
        public string GetTitleSum(string strWhere, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + Title + " as sumcode from [ax_orders]");
            strSql.Append(" where " + strWhere);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "0";
            }
            return title;
        }
        /// <summary>
        /// 添加一条数据带订单商品详细表
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ax_orders] (");
            strSql.Append("order_no,depot_category_id,product_category_id,product_no,user_name,user_tel,area,address,message,status,add_time,confirm_time,remark)");
            strSql.Append(" values (");
            strSql.Append("@order_no,@depot_category_id,@product_category_id,@product_no,@user_name,@user_tel,@area,@address,@message,@status,@add_time,@confirm_time,@remark)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_no", SqlDbType.NVarChar,100),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
                     new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = product_category_id;
            parameters[3].Value = product_no;
            parameters[4].Value = user_name;
            parameters[5].Value = user_tel;
            parameters[6].Value = area;
            parameters[7].Value = address;
            parameters[8].Value = message;
            parameters[9].Value = status;
            parameters[10].Value = add_time;
            parameters[11].Value = confirm_time;
            parameters[12].Value = remark;
            parameters[13].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //订单商品列表
            if (order_goods != null)
            {
                StringBuilder strSql2;
                StringBuilder strSql3;
                foreach (ax_order_goods models in order_goods)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into ax_order_goods(");
                    strSql2.Append("order_id,ticket_id,ticket_no,goods_id,goods_title)");
                    strSql2.Append(" values (");
                    strSql2.Append("@order_id,@ticket_id,@ticket_no,@goods_id,@goods_title)");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@order_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50),
					new SqlParameter("@goods_id", SqlDbType.BigInt,8),
					new SqlParameter("@goods_title", SqlDbType.NVarChar,100)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.ticket_id;
                    parameters2[2].Value = models.ticket_no;
                    parameters2[3].Value = models.goods_id;
                    parameters2[4].Value = models.goods_title;
                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);

                     strSql3 = new StringBuilder();
                     strSql3.Append("update ax_ticket set status=3");
                    strSql3.Append(" where id=@id ");
                    SqlParameter[] parameters3 = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
                    parameters3[0].Value = models.ticket_id;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[13].Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ax_orders] set ");
            strSql.Append("order_no=@order_no,");
            strSql.Append("depot_category_id=@depot_category_id,");
            strSql.Append("product_category_id=@product_category_id,");
            strSql.Append("product_no=@product_no,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("message=@message,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("confirm_time=@confirm_time,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_no", SqlDbType.NVarChar,100),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = product_category_id;
            parameters[3].Value = product_no;
            parameters[4].Value = user_name;
            parameters[5].Value = user_tel;
            parameters[6].Value = area;
            parameters[7].Value = address;
            parameters[8].Value = message;
            parameters[9].Value = status;
            parameters[10].Value = add_time;
            parameters[11].Value = confirm_time;
            parameters[12].Value = remark;
            parameters[13].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ax_orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_no,depot_category_id,product_category_id,product_no,user_name,user_tel,area,address,message,status,add_time,confirm_time,remark ");
            strSql.Append(" FROM [ax_orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null)
                {
                    this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_no"] != null)
                {
                    this.product_no = ds.Tables[0].Rows[0]["product_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null)
                {
                    this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_tel"] != null)
                {
                    this.user_tel = ds.Tables[0].Rows[0]["user_tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["area"] != null)
                {
                    this.area = ds.Tables[0].Rows[0]["area"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["message"] != null)
                {
                    this.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
            }
        }


        /// <summary>
        /// 根据订单号返回一个实体
        /// </summary>
        public void GetModel(string order_no)
        {
          
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_no,depot_category_id,product_category_id,product_no,user_name,user_tel,area,address,message,status,add_time,confirm_time,remark ");
            strSql.Append(" FROM [ax_orders] ");
            strSql.Append(" where order_no=@order_no");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null)
                {
                    this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_no"] != null)
                {
                    this.product_no = ds.Tables[0].Rows[0]["product_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null)
                {
                    this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_tel"] != null)
                {
                    this.user_tel = ds.Tables[0].Rows[0]["user_tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["area"] != null)
                {
                    this.area = ds.Tables[0].Rows[0]["area"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["message"] != null)
                {
                    this.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
            }
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ax_orders] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM  ax_orders");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ax_orders");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}



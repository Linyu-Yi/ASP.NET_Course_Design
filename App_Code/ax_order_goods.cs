using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ax_order_goods。
	/// </summary>
	[Serializable]
	public partial class ax_order_goods
	{
		public ax_order_goods()
		{}
        #region Model
        private long _id;
        private long? _order_id;
        private long _ticket_id = 0;
        private string _ticket_no = "";
        private long? _goods_id;
        private string _goods_title;
        /// <summary>
        /// 自增ID
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long? order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 礼券id
        /// </summary>
        public long ticket_id
        {
            set { _ticket_id = value; }
            get { return _ticket_id; }
        }
        /// <summary>
        /// 礼券编码
        /// </summary>
        public string ticket_no
        {
            set { _ticket_no = value; }
            get { return _ticket_no; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long? goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string goods_title
        {
            set { _goods_title = value; }
            get { return _goods_title; }
        }
        #endregion Model


		#region  Method


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("id", "ax_order_goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_order_goods]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 添加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ax_order_goods] (");
            strSql.Append("order_id,ticket_id,ticket_no,goods_id,goods_title)");
            strSql.Append(" values (");
            strSql.Append("@order_id,@ticket_id,@ticket_no,@goods_id,@goods_title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50),
					new SqlParameter("@goods_id", SqlDbType.BigInt,8),
					new SqlParameter("@goods_title", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_id;
            parameters[1].Value = ticket_id;
            parameters[2].Value = ticket_no;
            parameters[3].Value = goods_id;
            parameters[4].Value = goods_title;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ax_order_goods] set ");
            strSql.Append("order_id=@order_id,");
            strSql.Append("ticket_id=@ticket_id,");
            strSql.Append("ticket_no=@ticket_no,");
            strSql.Append("goods_id=@goods_id,");
            strSql.Append("goods_title=@goods_title");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_id", SqlDbType.BigInt,8),
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50),
					new SqlParameter("@goods_id", SqlDbType.BigInt,8),
					new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = order_id;
            parameters[1].Value = ticket_id;
            parameters[2].Value = ticket_no;
            parameters[3].Value = goods_id;
            parameters[4].Value = goods_title;
            parameters[5].Value = id;

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
            strSql.Append("delete from [ax_order_goods] ");
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
            strSql.Append("select id,order_id,ticket_id,ticket_no,goods_id,goods_title ");
            strSql.Append(" FROM [ax_order_goods] ");
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
                if (ds.Tables[0].Rows[0]["order_id"] != null && ds.Tables[0].Rows[0]["order_id"].ToString() != "")
                {
                    this.order_id = long.Parse(ds.Tables[0].Rows[0]["order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ticket_id"] != null && ds.Tables[0].Rows[0]["ticket_id"].ToString() != "")
                {
                    this.ticket_id = int.Parse(ds.Tables[0].Rows[0]["ticket_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ticket_no"] != null)
                {
                    this.ticket_no = ds.Tables[0].Rows[0]["ticket_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["goods_id"] != null && ds.Tables[0].Rows[0]["goods_id"].ToString() != "")
                {
                    this.goods_id = long.Parse(ds.Tables[0].Rows[0]["goods_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goods_title"] != null)
                {
                    this.goods_title = ds.Tables[0].Rows[0]["goods_title"].ToString();
                }
            }
        }

        /// <summary>
        /// 订单号id删除数据
        /// </summary>
        public bool DeleteOid(int order_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ax_order_goods] ");
            strSql.Append(" where order_id=@order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)};
            parameters[0].Value = order_id;

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
        /// 通过order_id获得对应的信息
        /// </summary>
        public DataTable GetList(long order_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ax_order_goods");
            if (order_id == 0)
            {
                strSql.Append(" order by id desc");
            }
            else
            {
                strSql.Append(" where order_id=" + order_id + " order by id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ax_order_goods] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}


		#endregion  Method
	}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ax_ticket。
	/// </summary>
	[Serializable]
	public partial class ax_ticket
	{
		public ax_ticket()
		{}
		#region Model
		private long _id;
		private int? _pid=0;
		private string _ticket_no="";
		private string _ticket_pw="";
		private int? _status=0;
		private DateTime? _add_time= DateTime.Now;
		/// <summary>
		/// 礼券id
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 礼品id
		/// </summary>
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string ticket_no
		{
			set{ _ticket_no=value;}
			get{return _ticket_no;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string ticket_pw
		{
			set{ _ticket_pw=value;}
			get{return _ticket_pw;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model


		#region  Method

        /// <summary>
        /// 得到最大同礼品的礼券编号
        /// </summary>
        public int GetMaxNo(int pid)
        {

            return DbHelperSQL.GetMaxNo("ticket_no", "ax_ticket",pid);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_ticket]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        public bool Exists(string ticket_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ax_ticket");
            strSql.Append(" where ticket_no=@ticket_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@ticket_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = ticket_no;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在发布过的编号和密码都存在的记录
        /// </summary>
        public bool Exists(string ticket_no, string ticket_pw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ax_ticket]");
            strSql.Append(" where ticket_no=@ticket_no and ticket_pw=@ticket_pw  and status=2");
            SqlParameter[] parameters = {
                     new SqlParameter("@ticket_no", SqlDbType.NVarChar,100),
					new SqlParameter("@ticket_pw", SqlDbType.NVarChar,100)};
            parameters[0].Value = ticket_no;
            parameters[1].Value = ticket_pw;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 查询发布的编号是否存在
        /// </summary>
        public bool Existsfb(string ticket_no, int _status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ax_ticket");
            strSql.Append(" where ticket_no=@ticket_no and status=" + _status);
            SqlParameter[] parameters = {
					new SqlParameter("@ticket_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = ticket_no;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询排除本身名称是否存在
        /// </summary>
        public bool Exists(string ticket_no, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ax_ticket");
            strSql.Append(" where id<>@id and  ticket_no=@ticket_no ");
            SqlParameter[] parameters = {
                     new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ticket_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = ticket_no;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 查询礼品是否存在
        /// </summary>
        public bool ExistsP(int pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ax_ticket");
            strSql.Append(" where pid=@pid ");
            SqlParameter[] parameters = {
                     new SqlParameter("@pid", SqlDbType.Int,4)};
            parameters[0].Value = pid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 返回PW
        /// </summary>
        public string GetPW(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ticket_pw from [ax_ticket]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
        /// <summary>
        /// 返回ID
        /// </summary>
        public string GetID(string ticket_no, string ticket_pw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from [ax_ticket]");
            strSql.Append(" where ticket_no='" + ticket_no + "' and ticket_pw='" + ticket_pw + "' and status=2");

            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

		/// <summary>
		/// 添加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ax_ticket] (");
			strSql.Append("pid,ticket_no,ticket_pw,status,add_time)");
			strSql.Append(" values (");
			strSql.Append("@pid,@ticket_no,@ticket_pw,@status,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50),
					new SqlParameter("@ticket_pw", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = pid;
			parameters[1].Value = ticket_no;
			parameters[2].Value = ticket_pw;
			parameters[3].Value = status;
			parameters[4].Value = add_time;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(long id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ax_ticket set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ax_ticket] set ");
			strSql.Append("pid=@pid,");
			strSql.Append("ticket_no=@ticket_no,");
			strSql.Append("ticket_pw=@ticket_pw,");
			strSql.Append("status=@status,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50),
					new SqlParameter("@ticket_pw", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = pid;
			parameters[1].Value = ticket_no;
			parameters[2].Value = ticket_pw;
			parameters[3].Value = status;
			parameters[4].Value = add_time;
			parameters[5].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ax_ticket] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pid,ticket_no,ticket_pw,status,add_time ");
			strSql.Append(" FROM [ax_ticket] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pid"]!=null && ds.Tables[0].Rows[0]["pid"].ToString()!="")
				{
					this.pid=int.Parse(ds.Tables[0].Rows[0]["pid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ticket_no"]!=null )
				{
					this.ticket_no=ds.Tables[0].Rows[0]["ticket_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ticket_pw"]!=null )
				{
					this.ticket_pw=ds.Tables[0].Rows[0]["ticket_pw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["status"]!=null && ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					this.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["add_time"]!=null && ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					this.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
			}
		}
     
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(string ticket_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,ticket_no,ticket_pw,status,add_time ");
            strSql.Append(" FROM [ax_ticket] ");
            strSql.Append(" where ticket_no=@ticket_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@ticket_no", SqlDbType.VarChar,50)};
            parameters[0].Value = ticket_no;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pid"] != null && ds.Tables[0].Rows[0]["pid"].ToString() != "")
                {
                    this.pid = int.Parse(ds.Tables[0].Rows[0]["pid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ticket_no"] != null)
                {
                    this.ticket_no = ds.Tables[0].Rows[0]["ticket_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ticket_pw"] != null)
                {
                    this.ticket_pw = ds.Tables[0].Rows[0]["ticket_pw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
			strSql.Append(" FROM [ax_ticket] ");
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
            strSql.Append(" FROM  ax_ticket");
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
            strSql.Append("select * FROM  ax_ticket");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion  Method
    }




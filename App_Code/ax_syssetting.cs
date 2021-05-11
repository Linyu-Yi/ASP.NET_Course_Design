using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ax_syssetting。
	/// </summary>
	[Serializable]
	public partial class ax_syssetting
	{
		public ax_syssetting()
		{}
		#region Model
		private int _id;
		private int? _msgon=1;
		private string _msgname="";
		private string _msgpwd="";
		private string _hdinfo="";
		private long? _msgnum=0;
		/// <summary>
		/// 系统设置
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 开关
		/// </summary>
		public int? MsgOn
		{
			set{ _msgon=value;}
			get{return _msgon;}
		}
		/// <summary>
		/// 短信用户名
		/// </summary>
		public string MsgName
		{
			set{ _msgname=value;}
			get{return _msgname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string MsgPwd
		{
			set{ _msgpwd=value;}
			get{return _msgpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HDInfo
		{
			set{ _hdinfo=value;}
			get{return _hdinfo;}
		}
		/// <summary>
		/// 条数
		/// </summary>
		public long? MsgNum
		{
			set{ _msgnum=value;}
			get{return _msgnum;}
		}
		#endregion Model


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_syssetting]");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ax_syssetting] (");
			strSql.Append("MsgOn,MsgName,MsgPwd,HDInfo,MsgNum)");
			strSql.Append(" values (");
			strSql.Append("@MsgOn,@MsgName,@MsgPwd,@HDInfo,@MsgNum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgOn", SqlDbType.Int,4),
					new SqlParameter("@MsgName", SqlDbType.VarChar,50),
					new SqlParameter("@MsgPwd", SqlDbType.VarChar,50),
					new SqlParameter("@HDInfo", SqlDbType.VarChar,500),
					new SqlParameter("@MsgNum", SqlDbType.BigInt,8)};
			parameters[0].Value = MsgOn;
			parameters[1].Value = MsgName;
			parameters[2].Value = MsgPwd;
			parameters[3].Value = HDInfo;
			parameters[4].Value = MsgNum;

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
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ax_syssetting] set ");
			strSql.Append("MsgOn=@MsgOn,");
			strSql.Append("MsgName=@MsgName,");
			strSql.Append("MsgPwd=@MsgPwd,");
			strSql.Append("HDInfo=@HDInfo,");
			strSql.Append("MsgNum=@MsgNum");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgOn", SqlDbType.Int,4),
					new SqlParameter("@MsgName", SqlDbType.VarChar,50),
					new SqlParameter("@MsgPwd", SqlDbType.VarChar,50),
					new SqlParameter("@HDInfo", SqlDbType.VarChar,500),
					new SqlParameter("@MsgNum", SqlDbType.BigInt,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = MsgOn;
			parameters[1].Value = MsgName;
			parameters[2].Value = MsgPwd;
			parameters[3].Value = HDInfo;
			parameters[4].Value = MsgNum;
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ax_syssetting] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,MsgOn,MsgName,MsgPwd,HDInfo,MsgNum ");
			strSql.Append(" FROM [ax_syssetting] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MsgOn"]!=null && ds.Tables[0].Rows[0]["MsgOn"].ToString()!="")
				{
					this.MsgOn=int.Parse(ds.Tables[0].Rows[0]["MsgOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MsgName"]!=null )
				{
					this.MsgName=ds.Tables[0].Rows[0]["MsgName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MsgPwd"]!=null )
				{
					this.MsgPwd=ds.Tables[0].Rows[0]["MsgPwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HDInfo"]!=null )
				{
					this.HDInfo=ds.Tables[0].Rows[0]["HDInfo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MsgNum"]!=null && ds.Tables[0].Rows[0]["MsgNum"].ToString()!="")
				{
					this.MsgNum=long.Parse(ds.Tables[0].Rows[0]["MsgNum"].ToString());
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
			strSql.Append(" FROM [ax_syssetting] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取短信剩余总数
        /// </summary>
        public string zs()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MsgNum   ");
            strSql.Append(" from ax_syssetting ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["MsgNum"].ToString();
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 更新短信剩余条数
        /// </summary>
        public void UpdateMsgNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ax_syssetting set ");
            strSql.Append("MsgNum=" + MsgNum + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		#endregion  Method
	}



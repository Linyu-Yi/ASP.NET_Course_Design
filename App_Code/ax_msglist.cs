using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
/// 类短信明细
	/// </summary>
	[Serializable]
	public partial class ax_msglist
	{
		public ax_msglist()
		{}
		#region Model
		private long _msgid;
		private string _cardnum="";
		private string _membername="";
		private string _membertel="";
		private string _message="";
		private DateTime? _sendtime= DateTime.Now;
		private string _op="";
		/// <summary>
		/// 短信明细
		/// </summary>
		public long MsgID
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string CardNum
		{
			set{ _cardnum=value;}
			get{return _cardnum;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string MemberName
		{
			set{ _membername=value;}
			get{return _membername;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string MemberTel
		{
			set{ _membertel=value;}
			get{return _membertel;}
		}
		/// <summary>
		/// 短信内容
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 发布人
		/// </summary>
		public string OP
		{
			set{ _op=value;}
			get{return _op;}
		}
		#endregion Model


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_msglist]");
			strSql.Append(" where MsgID=@MsgID ");

			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.BigInt)};
			parameters[0].Value = MsgID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 添加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ax_msglist] (");
			strSql.Append("CardNum,MemberName,MemberTel,Message,SendTime,OP)");
			strSql.Append(" values (");
			strSql.Append("@CardNum,@MemberName,@MemberTel,@Message,@SendTime,@OP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@MemberName", SqlDbType.VarChar,50),
					new SqlParameter("@MemberTel", SqlDbType.VarChar,50),
					new SqlParameter("@Message", SqlDbType.VarChar,500),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@OP", SqlDbType.VarChar,50)};
			parameters[0].Value = CardNum;
			parameters[1].Value = MemberName;
			parameters[2].Value = MemberTel;
			parameters[3].Value = Message;
			parameters[4].Value = SendTime;
			parameters[5].Value = OP;

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
			strSql.Append("update [ax_msglist] set ");
			strSql.Append("CardNum=@CardNum,");
			strSql.Append("MemberName=@MemberName,");
			strSql.Append("MemberTel=@MemberTel,");
			strSql.Append("Message=@Message,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("OP=@OP");
			strSql.Append(" where MsgID=@MsgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@MemberName", SqlDbType.VarChar,50),
					new SqlParameter("@MemberTel", SqlDbType.VarChar,50),
					new SqlParameter("@Message", SqlDbType.VarChar,500),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@OP", SqlDbType.VarChar,50),
					new SqlParameter("@MsgID", SqlDbType.BigInt,8)};
			parameters[0].Value = CardNum;
			parameters[1].Value = MemberName;
			parameters[2].Value = MemberTel;
			parameters[3].Value = Message;
			parameters[4].Value = SendTime;
			parameters[5].Value = OP;
			parameters[6].Value = MsgID;

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
		public bool Delete(long MsgID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ax_msglist] ");
			strSql.Append(" where MsgID=@MsgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.BigInt)};
			parameters[0].Value = MsgID;

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
		public void GetModel(long MsgID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MsgID,CardNum,MemberName,MemberTel,Message,SendTime,OP ");
			strSql.Append(" FROM [ax_msglist] ");
			strSql.Append(" where MsgID=@MsgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.BigInt)};
			parameters[0].Value = MsgID;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MsgID"]!=null && ds.Tables[0].Rows[0]["MsgID"].ToString()!="")
				{
					this.MsgID=long.Parse(ds.Tables[0].Rows[0]["MsgID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardNum"]!=null )
				{
					this.CardNum=ds.Tables[0].Rows[0]["CardNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberName"]!=null )
				{
					this.MemberName=ds.Tables[0].Rows[0]["MemberName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberTel"]!=null )
				{
					this.MemberTel=ds.Tables[0].Rows[0]["MemberTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Message"]!=null )
				{
					this.Message=ds.Tables[0].Rows[0]["Message"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SendTime"]!=null && ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					this.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OP"]!=null )
				{
					this.OP=ds.Tables[0].Rows[0]["OP"].ToString();
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
			strSql.Append(" FROM [ax_msglist] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ax_msglist");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  Method
	}



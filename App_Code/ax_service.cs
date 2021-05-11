using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ax_service。
	/// </summary>
	[Serializable]
	public partial class ax_service
	{
		public ax_service()
		{}
		#region Model
		private int _id;
		private string _order_no="";
		private string _express_no="";
		private string _content="";
		private string _user_name;
		private string _user_tel;
		private string _img_url1="";
		private string _img_url2="";
		private string _img_url3="";
		private string _img_url4="";
		private string _img_url5="";
		private DateTime? _add_time= DateTime.Now;
		/// <summary>
		/// 售后服务信息
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 货物订单号
		/// </summary>
		public string order_no
		{
			set{ _order_no=value;}
			get{return _order_no;}
		}
		/// <summary>
		/// 物流单号
		/// </summary>
		public string express_no
		{
			set{ _express_no=value;}
			get{return _express_no;}
		}
		/// <summary>
		/// 退换原因
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 申请人姓名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 申请人电话
		/// </summary>
		public string user_tel
		{
			set{ _user_tel=value;}
			get{return _user_tel;}
		}
		/// <summary>
		/// 退换凭证图1
		/// </summary>
		public string img_url1
		{
			set{ _img_url1=value;}
			get{return _img_url1;}
		}
		/// <summary>
		/// 退换凭证图2
		/// </summary>
		public string img_url2
		{
			set{ _img_url2=value;}
			get{return _img_url2;}
		}
		/// <summary>
		/// 退换凭证图3
		/// </summary>
		public string img_url3
		{
			set{ _img_url3=value;}
			get{return _img_url3;}
		}
		/// <summary>
		/// 退换凭证图4
		/// </summary>
		public string img_url4
		{
			set{ _img_url4=value;}
			get{return _img_url4;}
		}
		/// <summary>
		/// 退换凭证图1
		/// </summary>
		public string img_url5
		{
			set{ _img_url5=value;}
			get{return _img_url5;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ax_service]");
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
			strSql.Append("insert into [ax_service] (");
			strSql.Append("order_no,express_no,content,user_name,user_tel,img_url1,img_url2,img_url3,img_url4,img_url5,add_time)");
			strSql.Append(" values (");
			strSql.Append("@order_no,@express_no,@content,@user_name,@user_tel,@img_url1,@img_url2,@img_url3,@img_url4,@img_url5,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,50),
					new SqlParameter("@express_no", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@img_url1", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url2", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url3", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url4", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url5", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = order_no;
			parameters[1].Value = express_no;
			parameters[2].Value = content;
			parameters[3].Value = user_name;
			parameters[4].Value = user_tel;
			parameters[5].Value = img_url1;
			parameters[6].Value = img_url2;
			parameters[7].Value = img_url3;
			parameters[8].Value = img_url4;
			parameters[9].Value = img_url5;
			parameters[10].Value = add_time;

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
			strSql.Append("update [ax_service] set ");
			strSql.Append("order_no=@order_no,");
			strSql.Append("express_no=@express_no,");
			strSql.Append("content=@content,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("user_tel=@user_tel,");
			strSql.Append("img_url1=@img_url1,");
			strSql.Append("img_url2=@img_url2,");
			strSql.Append("img_url3=@img_url3,");
			strSql.Append("img_url4=@img_url4,");
			strSql.Append("img_url5=@img_url5,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,50),
					new SqlParameter("@express_no", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@img_url1", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url2", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url3", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url4", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url5", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = order_no;
			parameters[1].Value = express_no;
			parameters[2].Value = content;
			parameters[3].Value = user_name;
			parameters[4].Value = user_tel;
			parameters[5].Value = img_url1;
			parameters[6].Value = img_url2;
			parameters[7].Value = img_url3;
			parameters[8].Value = img_url4;
			parameters[9].Value = img_url5;
			parameters[10].Value = add_time;
			parameters[11].Value = id;

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
			strSql.Append("delete from [ax_service] ");
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
			strSql.Append("select id,order_no,express_no,content,user_name,user_tel,img_url1,img_url2,img_url3,img_url4,img_url5,add_time ");
			strSql.Append(" FROM [ax_service] ");
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
				if(ds.Tables[0].Rows[0]["order_no"]!=null )
				{
					this.order_no=ds.Tables[0].Rows[0]["order_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["express_no"]!=null )
				{
					this.express_no=ds.Tables[0].Rows[0]["express_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null )
				{
					this.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_name"]!=null )
				{
					this.user_name=ds.Tables[0].Rows[0]["user_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_tel"]!=null )
				{
					this.user_tel=ds.Tables[0].Rows[0]["user_tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url1"]!=null )
				{
					this.img_url1=ds.Tables[0].Rows[0]["img_url1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url2"]!=null )
				{
					this.img_url2=ds.Tables[0].Rows[0]["img_url2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url3"]!=null )
				{
					this.img_url3=ds.Tables[0].Rows[0]["img_url3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url4"]!=null )
				{
					this.img_url4=ds.Tables[0].Rows[0]["img_url4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["img_url5"]!=null )
				{
					this.img_url5=ds.Tables[0].Rows[0]["img_url5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["add_time"]!=null && ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					this.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
			strSql.Append(" FROM [ax_service] ");
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
            strSql.Append(" FROM  ax_service");
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
            strSql.Append("select * FROM  ax_service");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
	
		#endregion  Method
	}



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
  public  class DataBase
    {
        SqlConnection con = null;

        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, object value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, value);
        }
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, int size, ParameterDirection Direction, object value)
        {
            SqlParameter Param;
            if (size > 0)
            {
                Param = new SqlParameter(ParamName, DbType, size);
            }
            else
            {
                Param = new SqlParameter(ParamName, DbType);
            }
            Param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && value == null))
            {
                Param.Value = value;


            }
            return Param;
        }

        public int RunSql(string sql, SqlParameter[] prams)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = CreateCommandSql(sql, prams);
                result = cmd.ExecuteNonQuery();
                this.Close();
                return result;
            }
            catch(Exception e)
            {
                throw e;
                
            }

        }
        public SqlCommand CreateCommandSql(string sql, SqlParameter[] prams)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }
        private void Open()
        {
            if (con == null)
            {
                con = new SqlConnection("server=192.168.3.142;uid=sa;pwd=xlkj;database=xingliankeji");

            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void Close()
        {
            if (con != null)
                con.Close();

        }
        public DataTable Query(string sql)
        {
            Open();
            using (SqlDataAdapter sqlda = new SqlDataAdapter(sql, con))
            {
                using (DataTable dt = new DataTable())
                {
                    sqlda.Fill(dt);
                    Close();
                    return dt;
                }
            }
        }
        public int RunSql(string sql)
        {
            int result = -1;
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}

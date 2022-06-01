using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto.DbContext
{
    public class Context
    {
        public SqlConnection con { get; set; }
        public int MyProperty { get; set; }

        public Context()
        {
            var op = ConfigurationManager.ConnectionStrings;
            this.con = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
        }

        public void Add(SqlCommand command)
        {
            command.Connection = con;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Get(SqlCommand command)
        {
            DataSet dataSet = new DataSet();
            command.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, con);
            con.Open();
            adapter.Fill(dataSet);
            con.Close();
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }

        public void Update(SqlCommand command)
        {
            command.Connection = con;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(SqlCommand command)
        {
            command.Connection = con;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public object IsNull (object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
    }
}
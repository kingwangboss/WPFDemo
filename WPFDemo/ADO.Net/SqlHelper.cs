﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;

        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //foreach (SqlParameter parameter in parameters)
                    //{
                    //    cmd.Parameters.Add(parameter);
                    //}
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
            }
        }
    }
}

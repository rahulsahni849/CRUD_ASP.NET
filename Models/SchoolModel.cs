using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace crud_app.Models
{
    public class SchoolModel
    {

        public int Id { get; set; }
        public string  class_name { get; set; }
        public int order_no { get; set; }
        public int no_of_year { get; set; }
        public string school_name { get; set; }

        public Boolean show { get; set; }

        public static List<SchoolModel> getData()
        {
            string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("getData",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr =  cmd.ExecuteReader();
                List<SchoolModel> data = new List<SchoolModel>();
                while (rdr.Read())
                {
                    data.Add(new SchoolModel()
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        class_name = rdr["class"].ToString(),
                        order_no = Convert.ToInt32(rdr["display_order_no"].ToString()),
                        no_of_year = Convert.ToInt32(rdr["no_of_year"].ToString()),
                        school_name = rdr["school_name"].ToString(),
                        show = Convert.ToBoolean(rdr["show"].ToString())
                    });
                }

                return data;
            }
        }
        public static SchoolModel getData(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("getDataById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                SchoolModel data  = new SchoolModel();
                while (rdr.Read())
                {
                    data = new SchoolModel()
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        class_name = rdr["class"].ToString(),
                        order_no = Convert.ToInt32(rdr["display_order_no"].ToString()),
                        no_of_year = Convert.ToInt32(rdr["no_of_year"].ToString()),
                        school_name = rdr["school_name"].ToString(),
                        show = Convert.ToBoolean(rdr["show"].ToString())
                    };
                }

                return data;
            }
        }


        public static int postData(SchoolModel data)
        {
            string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("postData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("class", data.class_name);
                cmd.Parameters.AddWithValue("no_of_year", data.no_of_year);
                cmd.Parameters.AddWithValue("display_order_no", data.order_no);
                cmd.Parameters.AddWithValue("show", data.show);
                cmd.Parameters.AddWithValue("school_name", data.school_name);
                con.Open();
                int status = cmd.ExecuteNonQuery();

                return status;

            }
        }
        public static int updateData(int id,SchoolModel data)
        {
            string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("updateData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("class", data.class_name);
                cmd.Parameters.AddWithValue("no_of_year", data.no_of_year);
                cmd.Parameters.AddWithValue("display_order_no", data.order_no);
                cmd.Parameters.AddWithValue("show", data.show);
                cmd.Parameters.AddWithValue("school_name", data.school_name);
                con.Open();
                int status = cmd.ExecuteNonQuery();

                return status;

            }
        }

        public static int deleteData(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["test"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("deleteData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                int status = cmd.ExecuteNonQuery();

                return status;

            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebStudent.Models;

namespace WebStudent.Repository
{
    public class SinhVienRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddSV(SinhVienModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddSinhVien", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@HoTen", obj.HoTen);
            com.Parameters.AddWithValue("@NgaySinh", obj.NgaySinh);
            com.Parameters.AddWithValue("@GioiTinh", obj.GioiTinh);
            com.Parameters.AddWithValue("@DiaChi", obj.DiaChi);
            com.Parameters.AddWithValue("@MaLop", obj.MaLop);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list     
        public List<SinhVienModel> GetAllSV()
        {
            connection();
            List<SinhVienModel> EmpList = new List<SinhVienModel>();


            SqlCommand com = new SqlCommand("GetSinhVien", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new SinhVienModel
                    {

                        MaSV = Convert.ToInt32(dr["MaSV"]),
                        HoTen = Convert.ToString(dr["HoTen"]),
                        NgaySinh = Convert.ToString(dr["NgaySinh"]),
                        GioiTinh = Convert.ToString(dr["GioiTinh"]),
                        DiaChi = Convert.ToString(dr["DiaChi"]),
                        MaLop = Convert.ToString(dr["MaLop"])
                    }
                    );
            }

            return EmpList;
        }
        //To Update Employee details    
        public bool UpdateSV(SinhVienModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateSinhVien", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaSV", obj.MaSV);
            com.Parameters.AddWithValue("@HoTen", obj.HoTen);
            com.Parameters.AddWithValue("@NgaySinh", obj.NgaySinh);
            com.Parameters.AddWithValue("@GioiTinh", obj.GioiTinh);
            com.Parameters.AddWithValue("@DiaChi", obj.DiaChi);
            com.Parameters.AddWithValue("@MaLop", obj.MaLop);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteSV(int MaSV)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteSinhVien", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaSV", MaSV);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
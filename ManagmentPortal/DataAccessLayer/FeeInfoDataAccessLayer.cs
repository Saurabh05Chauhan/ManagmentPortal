using ManagmentPortal.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManagmentPortal.DataAccessLayer
{
    public class FeeInfoDataAccessLayer
    {
        string constr = "server = localhost; database = newdb; uid = root; pwd = root";
        public string SaveFeeInfo(FeeInfoModel model)
        {
            try
            {
                int studentFeeID = GetPrimaryKey();
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("spInsertFeeInfo"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("StudentFeeID", studentFeeID);
                            cmd.Parameters.AddWithValue("StudentID", model.studentID);
                            cmd.Parameters.AddWithValue("Fee", model.Fees);
                            cmd.Parameters.AddWithValue("Fine", model.Fine);
                            cmd.Parameters.AddWithValue("FeeSubmissionDate", model.FeeSubmissionDate);
                            cmd.Parameters.AddWithValue("ForMonth", model.forMonth);
                            cmd.Parameters.AddWithValue("Total", model.Total);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public DataTable GetFeeGridResults(int studentID, string month)
        {
            
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("spGetFeeDetails"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("StudentID", studentID);
                        cmd.Parameters.AddWithValue("InMonth", month);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }

                    }
                }
            }

        }

        public FeeInfoModel GetFeeGridResults(int id)
        {
            try
            {
                FeeInfoModel model = new FeeInfoModel();
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("spGetFeeDetails"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("StudentID", id);
                            cmd.Parameters.AddWithValue("InMonth", "");

                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            con.Open();
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                model = this.mapDataToModel(dt);
                            }
                            con.Close();
                        }

                    }
                }

                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public FeeInfoModel mapDataToModel(DataTable dataTable)
        {
            FeeInfoModel model = new FeeInfoModel();
            if (dataTable.Rows.Count >= 1)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    model.studentID = Convert.ToInt32(row["StudentID"]);
                    //model.StudentInfoID = Convert.ToInt32(row["StudentInfoID"]);
                    model.StudentName = row["StudentName"].ToString();
                    model.Class = row["Class"].ToString();
                    model.Section = row["Section"].ToString();
                    model.Stream = row["Stream"].ToString();
                    model.Fees = Convert.ToInt32(row["Fees"]);
                    model.Fine = Convert.ToInt32(row["Fine"]);
                    model.FeeSubmissionDate = Convert.ToDateTime(row["FeeSubmissionDate"]);
                    model.forMonth = row["ForMonth"].ToString();
                    model.Total = Convert.ToInt32(row["Total"]);
                    //model.leaveDate = Convert.ToDateTime(row["SchoolLeavingDate"]);

                }
            }

            return model;
        }
        public int GetPrimaryKey()
        {
            int result = 0;
            try
            {
                string query = "Select max(StudentID) from newdb.tbstudentfee";
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            con.Open();
                            result = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }

                    }
                }


            }
            catch (Exception e)
            {
                string error = e.ToString();
            }

            return result + 1;

        }
    }
}
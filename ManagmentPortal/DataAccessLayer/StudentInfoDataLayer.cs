using ManagmentPortal.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ManagmentPortal.DataAccessLayer
{
    public class StudentInfoDataLayer

    {
        string constr = "server = localhost; database = newdb; uid = root; pwd = root";
        public string saveToDB(tbstudent student,tbstudentinfo info )
        {
            string outStudid = "";
            try
            {
                

                int StudentInfoID = GetPrimaryKey("StudentInfoID");
                int StudentID = GetPrimaryKey("StudentID");
                outStudid = StudentID.ToString();
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("spInsertStudentInfo"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("StudentID", StudentID);
                            cmd.Parameters.AddWithValue("StudentName", student.StudentName);
                            cmd.Parameters.AddWithValue("Class", student.Class);
                            cmd.Parameters.AddWithValue("Section", student.Section);
                            cmd.Parameters.AddWithValue("Stream", student.Stream);
                            cmd.Parameters.AddWithValue("IsActive", student.IsActive);
                            cmd.Parameters.AddWithValue("StudentInfoID", StudentInfoID);
                            cmd.Parameters.AddWithValue("FathersName", info.FathersName);
                            cmd.Parameters.AddWithValue("MothersName", info.MothersName);
                            cmd.Parameters.AddWithValue("DateOfBirth", info.DateOfBirth);
                            cmd.Parameters.AddWithValue("Address", info.Address);
                            cmd.Parameters.AddWithValue("AdmissionDate", info.AdmissionDate);
                            cmd.Parameters.AddWithValue("SchoolLeavingDate", info.SchoolLeavingDate);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                return "Success," + outStudid;
            }
            catch(Exception e)
            {
                string error = e.ToString();
                return error;
            }

            
        }

        public string UpdatetbStudent(tbstudent student, tbstudentinfo info)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("spUpdateStudentInfo"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("inStudentID", info.StudentID);
                            cmd.Parameters.AddWithValue("inStudentName", student.StudentName);
                            cmd.Parameters.AddWithValue("inClass", student.Class);
                            cmd.Parameters.AddWithValue("inSection", student.Section);
                            cmd.Parameters.AddWithValue("inStream", student.Stream);
                            cmd.Parameters.AddWithValue("inIsActive", student.IsActive);
                            cmd.Parameters.AddWithValue("inStudentInfoID", info.StudentInfoID);
                            cmd.Parameters.AddWithValue("inFathersName", info.FathersName);
                            cmd.Parameters.AddWithValue("inMothersName", info.MothersName);
                            cmd.Parameters.AddWithValue("inDateOfBirth", info.DateOfBirth);
                            cmd.Parameters.AddWithValue("inAddress", info.Address);
                            cmd.Parameters.AddWithValue("inAdmissionDate", info.AdmissionDate);
                            cmd.Parameters.AddWithValue("inSchoolLeavingDate", info.SchoolLeavingDate);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

                return "Success"+info.StudentID;

            }
            catch (Exception e)
            {
                string error = e.ToString();
                return error;
            }

            
        }


        public int GetPrimaryKey(string queryfor)
        {
            int result = 0;
            try
            {
                string query = "";
                
                if (queryfor == "StudentID")
                {
                     query = "Select max(StudentID) from newdb.tbStudent";
                }
                else
                {
                     query = "Select max(StudentInfoID) from newdb.tbStudentInfo";
                }
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query,con))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            con.Open();
                            result =Convert.ToInt32( cmd.ExecuteScalar());
                            con.Close();
                        }
                            
                    }
                }

                
            }
            catch(Exception e)
            {
                string error = e.ToString();
            }
            
            return result+1;

        }

        public DataTable GetGridResults(int studentID,string name,string Class,string month)
        {
            string query = "";
            if(name !="" || Class!= "")
            {
                query = "SearchFromName";
            }
            else if(studentID!= 0 && month != "")
            {
                query = "SearchIDandMonth";
            }
            else
            {
                query = "SearchFromID";
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("spGetResults"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("StudentID", studentID);
                        cmd.Parameters.AddWithValue("InMonth", month);
                        cmd.Parameters.AddWithValue("StudentName", name);
                        cmd.Parameters.AddWithValue("Class", Class);
                        cmd.Parameters.AddWithValue("QueryFor", query);
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

        public StudentInfoModel GetStudentInfo(int studentID)
        {
            StudentInfoModel model = new StudentInfoModel();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("spGetResults", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("StudentID", studentID);
                        cmd.Parameters.AddWithValue("StudentName", "");
                        cmd.Parameters.AddWithValue("Class", "");
                        cmd.Parameters.AddWithValue("InMonth", "");
                        cmd.Parameters.AddWithValue("QueryFor", "SearchFromID");
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        con.Open();
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                           model= this.mapDataToModel(dt);
                        }
                        con.Close();
                    }



                }
            }

            return model;
        }

        public StudentInfoModel GetStudentInfoForFee(int studentID)
        {
            StudentInfoModel model = new StudentInfoModel();
            string query = "";
            query = "Select StudentName,Class,Section from newdb.tbStudent where studentID=" + studentID;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
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

        public StudentInfoModel mapDataToModel(DataTable dataTable)
        {
            StudentInfoModel model = new StudentInfoModel();
            if (dataTable.Rows.Count >= 1)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    model.StudentID = Convert.ToInt32(row["StudentID"]);
                    model.StudentInfoID = Convert.ToInt32(row["StudentInfoID"]);
                    model.studentName = row["StudentName"].ToString();
                    model.Class = row["Class"].ToString();
                    model.section = row["Section"].ToString();
                    model.stream = row["Stream"].ToString();
                    model.fathersName = row["FathersName"].ToString();
                    model.mothersName = row["MothersName"].ToString();
                    model.address = row["Address"].ToString();
                    model.isActive = Convert.ToInt32(row["IsActive"]);
                    model.dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    model.admitDate = Convert.ToDateTime(row["AdmissionDate"]);
                    //model.leaveDate = Convert.ToDateTime(row["SchoolLeavingDate"]);
                    
                }
            }

            return model;
        }

        public List<string> GetDrpList(int category)
        {
            string query = "";
            List<string> drpValues = new List<string>();
            drpValues.Add("--Select One--");
            try
            {
                
                query = "Select value from newdb.tbcode where categoryID=" + category;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            con.Open();
                            MySqlDataReader reader=cmd.ExecuteReader();
                            
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    drpValues.Add(reader.GetString(0));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found.");
                            }
                            con.Close();
                            reader.Close();
                        }

                    }
                }

                

            }
            catch(Exception e)
            {
                string error = e.ToString();
            }

            return drpValues;
        }
    }
}
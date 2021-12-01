using ManagmentPortal.DataAccessLayer;
using ManagmentPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManagmentPortal.Presenter
{
    public class StudentInfoPresenter
    {

        StudentInfoDataLayer data = new StudentInfoDataLayer();
        public string SaveInfo(StudentInfoModel infoModel)
        {
            if (infoModel.StudentID==0 )
            {
                tbstudent student = new tbstudent();
                student.StudentName = infoModel.studentName;
                student.Class = infoModel.Class;
                student.Section = infoModel.section;
                student.Stream = infoModel.stream;
                student.IsActive = Constant.active;

                tbstudentinfo info = new tbstudentinfo();
                info.FathersName = infoModel.fathersName;
                info.MothersName = infoModel.mothersName;
                info.DateOfBirth = infoModel.dateOfBirth;
                info.AdmissionDate = infoModel.admitDate;
                info.Address = infoModel.address;

                return data.saveToDB(student, info);

            }
            else
            {
                
                tbstudent student = new tbstudent();
                student.StudentID = SessionHelper.CurrentStudentId;
                student.StudentName = infoModel.studentName;
                student.Class = infoModel.Class;
                student.Section = infoModel.section;
                student.Stream = infoModel.stream;
                

                tbstudentinfo info = new tbstudentinfo();
                if (SessionHelper.CurrentStudentInfoId == 0)
                {
                    info.StudentInfoID = Convert.ToInt32(infoModel.StudentID);
                }
                else
                {
                    info.StudentInfoID = SessionHelper.CurrentStudentInfoId;
                }
                info.StudentID = infoModel.StudentID;
                info.FathersName = infoModel.fathersName;
                info.MothersName = infoModel.mothersName;
                info.DateOfBirth = infoModel.dateOfBirth;
                info.AdmissionDate = infoModel.admitDate;
                info.Address = infoModel.address;
                if (infoModel.leaveDate== null)
                {
                    student.IsActive = Constant.active;
                }
                else
                {
                    student.IsActive = Constant.inActive;
                }

                return data.UpdatetbStudent(student, info);
            }

            
        }

        public StudentInfoModel GetStudentInfo(int studentID)
        {
            StudentInfoModel model = new StudentInfoModel();

            model = data.GetStudentInfo(studentID);
            return model;
        } 
        
        public StudentInfoModel GetStudentInfoForFee(int studentID)
        {
            StudentInfoModel model = new StudentInfoModel();

            model = data.GetStudentInfoForFee(studentID);
            return model;
        }

        public DataTable GetGridResults(int studentID,string month )
        {
            DataTable ds = new DataTable();
            ds= data.GetGridResults(studentID,"","",month);

            return ds;
        }

        public List<string> GetDrpList(int category)
        {
            List<string> drplist = new List<string>();
            drplist = data.GetDrpList(category);

            return drplist;
        }

        public DataTable GetSearchFromNameAndClass(string name,string Class)
        {
            DataTable ds = new DataTable();
            ds = data.GetGridResults(0, name,Class,"");

            return ds;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagmentPortal.Models
{
    public class StudentInfoModel
    {
        public int StudentID=0;
        public int StudentInfoID=0;
        public string studentName;
        public string Class;
        public string stream;
        public string section;
        public string fathersName;
        public string mothersName;
        public DateTime dateOfBirth;
        public DateTime admitDate;
        public Nullable<DateTime> leaveDate;
        public string address;
        public int isActive;
    }
}
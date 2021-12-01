using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagmentPortal.Models
{
    public class FeeInfoModel
    {
        public int studentID;
        public string StudentName;
        public string Class;
        public string Section;
        public string Stream;
        public int Fees;
        public int Fine;
        public DateTime FeeSubmissionDate;
        public string forMonth;
        public int Total;
    }
}
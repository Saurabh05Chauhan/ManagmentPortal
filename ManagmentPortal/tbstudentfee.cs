//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagmentPortal
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbstudentfee
    {
        public int StudentFeeID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> Fees { get; set; }
        public Nullable<int> Fine { get; set; }
        public Nullable<System.DateTime> FeeSubmissionDate { get; set; }
        public string ForMonth { get; set; }

        public int total { get; set; }

        public virtual tbstudent tbstudent { get; set; }
    }
}

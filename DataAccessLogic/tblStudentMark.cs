//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblStudentMark
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int GradeID { get; set; }
        public int CourseID { get; set; }
        public int ExamTypeID { get; set; }
        public int AcademicQuarterID { get; set; }
        public int OutOfTotal { get; set; }
        public int MarkObtained { get; set; }
        public int AcademicYear { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblAcademicQuarter tblAcademicQuarter { get; set; }
        public virtual tblCourse tblCourse { get; set; }
        public virtual tblExamType tblExamType { get; set; }
        public virtual tblGrade tblGrade { get; set; }
        public virtual tblStudent tblStudent { get; set; }
    }
}

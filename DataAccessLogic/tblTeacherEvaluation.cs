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
    
    public partial class tblTeacherEvaluation
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int AcademicQuarterID { get; set; }
        public int EvaluationCriteriaID { get; set; }
        public string Mark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblAcademicQuarter tblAcademicQuarter { get; set; }
        public virtual tblEvaluationCriteria tblEvaluationCriteria { get; set; }
        public virtual tblTeacher tblTeacher { get; set; }
    }
}

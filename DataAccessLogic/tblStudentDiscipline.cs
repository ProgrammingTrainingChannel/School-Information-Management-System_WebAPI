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
    
    public partial class tblStudentDiscipline
    {
        public int ID { get; set; }
        public int StudenID { get; set; }
        public int CaseTypeID { get; set; }
        public int PenalityTypeID { get; set; }
        public int EmergencyContactID { get; set; }
        public string InformedBy { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    
        public virtual tblCaseType tblCaseType { get; set; }
        public virtual tblEmergencyContact tblEmergencyContact { get; set; }
        public virtual tblPenalityType tblPenalityType { get; set; }
        public virtual tblStudent tblStudent { get; set; }
    }
}

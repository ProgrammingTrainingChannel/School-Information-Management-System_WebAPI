using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using BusinessEntity.TeacherEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.TeacherEvaluation
{
    public class StudentPaymentEntity : IBase
    {
        public int ID { get; set; }
        public string RecieptNumber { get; set; }
        public string CashierName { get; set; }
        public string PaidBy { get; set; }
        public bool IsFullyPaid { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public PaymentPeriodEntity PaymentPeriod { get; set; }
        public PaymentReasonEntity PaymentReason { get; set; }
        public StudentEntity Student { get; set; }

        public StudentPaymentEntity()
        {

        }

        public StudentPaymentEntity(DataAccessLogic.tblStudentPayment StudentPayment)
        {
            this.ID = StudentPayment.ID;
            this.RecieptNumber = StudentPayment.RecieptNumber;
            this.CashierName = StudentPayment.CashierName;
            this.PaidBy = StudentPayment.PaidBy;
            this.IsFullyPaid = StudentPayment.IsFullyPaid;

            this.PaymentPeriod = new PaymentPeriodEntity(StudentPayment.tblPaymentPeriod);
            this.PaymentReason = new PaymentReasonEntity(StudentPayment.tblPaymentReason);
            this.Student = new StudentEntity(StudentPayment.tblStudent);

            this.CreatedBy = StudentPayment.CreatedBy;
            this.CreatedDate = StudentPayment.CreatedDate;
            this.UpdatedBy = StudentPayment.UpdatedBy;
            this.UpdatedDate = StudentPayment.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblStudentPayment StudentPayment = new DataAccessLogic.tblStudentPayment();
            StudentPayment.ID = this.ID;
            StudentPayment.RecieptNumber = this.RecieptNumber;
            StudentPayment.CashierName = this.CashierName;
            StudentPayment.PaidBy = this.PaidBy;
            StudentPayment.IsFullyPaid = this.IsFullyPaid;

            StudentPayment.PaymentPeriodID = this.PaymentPeriod.ID;
            StudentPayment.PaymentReasonID = this.PaymentReason.ID;
            StudentPayment.StudentID = this.Student.ID;

            StudentPayment.CreatedBy = this.CreatedBy;
            StudentPayment.CreatedDate = this.CreatedDate;
            StudentPayment.CreatedBy = this.CreatedBy;
            StudentPayment.CreatedDate = this.CreatedDate;

            return StudentPayment as T;
        }
    }
}

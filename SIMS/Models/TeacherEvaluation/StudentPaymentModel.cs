using SIMS.Models.Admission;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models.TeacherEvaluation
{
    public class StudentPaymentModel : IBase
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

        public PaymentPeriodModel PaymentPeriod { get; set; }
        public PaymentReasonModel PaymentReason { get; set; }
        public StudentModel Student { get; set; }

        public StudentPaymentModel()
        {

        }

        public StudentPaymentModel(BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment)
        {
            this.ID = StudentPayment.ID;
            this.RecieptNumber = StudentPayment.RecieptNumber;
            this.CashierName = StudentPayment.CashierName;
            this.PaidBy = StudentPayment.PaidBy;
            this.IsFullyPaid = StudentPayment.IsFullyPaid;

            this.PaymentPeriod = new PaymentPeriodModel(StudentPayment.PaymentPeriod);
            this.PaymentReason = new PaymentReasonModel(StudentPayment.PaymentReason);
            this.Student = new StudentModel(StudentPayment.Student);

            this.CreatedBy = StudentPayment.CreatedBy;
            this.CreatedDate = StudentPayment.CreatedDate;
            this.UpdatedBy = StudentPayment.UpdatedBy;
            this.UpdatedDate = StudentPayment.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment = new BusinessEntity.TeacherEvaluation.StudentPaymentEntity();
            StudentPayment.ID = this.ID;
            StudentPayment.RecieptNumber = this.RecieptNumber;
            StudentPayment.CashierName = this.CashierName;
            StudentPayment.PaidBy = this.PaidBy;
            StudentPayment.IsFullyPaid = this.IsFullyPaid;

            StudentPayment.PaymentPeriod = this.PaymentPeriod.MapToEntity<BusinessEntity.Lookup.PaymentPeriodEntity>();
            StudentPayment.PaymentReason = this.PaymentReason.MapToEntity<BusinessEntity.Lookup.PaymentReasonEntity>();
            StudentPayment.Student = this.Student.MapToEntity<BusinessEntity.Admission.StudentEntity>();

            StudentPayment.CreatedBy = this.CreatedBy;
            StudentPayment.CreatedDate = this.CreatedDate;
            StudentPayment.UpdatedBy = this.UpdatedBy;
            StudentPayment.UpdatedDate = this.UpdatedDate;

            return StudentPayment as T;
        }
    }
}
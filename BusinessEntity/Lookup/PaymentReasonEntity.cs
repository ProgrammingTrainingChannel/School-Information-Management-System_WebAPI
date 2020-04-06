using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class PaymentReasonEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PaymentReasonEntity()
        {

        }

        public PaymentReasonEntity(DataAccessLogic.tblPaymentReason paymentReason)
        {
            this.ID = paymentReason.ID;
            this.Name = paymentReason.Name;
            this.Description = paymentReason.Description;
            this.CreatedBy = paymentReason.CreatedBy;
            this.CreatedDate = paymentReason.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblPaymentReason paymentReason = new DataAccessLogic.tblPaymentReason();
            paymentReason.ID = this.ID;
            paymentReason.Name = this.Name;
            paymentReason.Description = this.Description;
            paymentReason.CreatedBy = this.CreatedBy;
            paymentReason.CreatedDate = this.CreatedDate;

            return paymentReason as T;
        }
    }
}

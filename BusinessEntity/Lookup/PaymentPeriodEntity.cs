using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class PaymentPeriodEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PaymentPeriodEntity()
        {

        }

        public PaymentPeriodEntity(DataAccessLogic.tblPaymentPeriod paymentPeriod)
        {
            this.ID = paymentPeriod.ID;
            this.Name = paymentPeriod.Name;
            this.Description = paymentPeriod.Description;
            this.CreatedBy = paymentPeriod.CreatedBy;
            this.CreatedDate = paymentPeriod.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblPaymentPeriod paymentPeriod = new DataAccessLogic.tblPaymentPeriod();
            paymentPeriod.ID = this.ID;
            paymentPeriod.Name = this.Name;
            paymentPeriod.Description = this.Description;
            paymentPeriod.CreatedBy = this.CreatedBy;
            paymentPeriod.CreatedDate = this.CreatedDate;

            return paymentPeriod as T;
        }
    }
}

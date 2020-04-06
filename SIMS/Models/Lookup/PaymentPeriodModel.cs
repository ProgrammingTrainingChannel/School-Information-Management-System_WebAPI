using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class PaymentPeriodModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PaymentPeriodModel()
        {

        }

        public PaymentPeriodModel(BusinessEntity.Lookup.PaymentPeriodEntity paymentPeriod)
        {
            this.ID = paymentPeriod.ID;
            this.Name = paymentPeriod.Name;
            this.Description = paymentPeriod.Description;
            this.CreatedBy = paymentPeriod.CreatedBy;
            this.CreatedDate = paymentPeriod.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.PaymentPeriodEntity paymentPeriod = new BusinessEntity.Lookup.PaymentPeriodEntity();
            paymentPeriod.ID = this.ID;
            paymentPeriod.Name = this.Name;
            paymentPeriod.Description = this.Description;
            paymentPeriod.CreatedBy = this.CreatedBy;
            paymentPeriod.CreatedDate = this.CreatedDate;

            return paymentPeriod as T;
        }
    }
}

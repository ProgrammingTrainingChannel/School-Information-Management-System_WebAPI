﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class PaymentReasonModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PaymentReasonModel()
        {

        }

        public PaymentReasonModel(BusinessEntity.Lookup.PaymentReasonEntity paymentReason)
        {
            this.ID = paymentReason.ID;
            this.Name = paymentReason.Name;
            this.Description = paymentReason.Description;
            this.CreatedBy = paymentReason.CreatedBy;
            this.CreatedDate = paymentReason.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.PaymentReasonEntity paymentReason = new BusinessEntity.Lookup.PaymentReasonEntity();
            paymentReason.ID = this.ID;
            paymentReason.Name = this.Name;
            paymentReason.Description = this.Description;
            paymentReason.CreatedBy = this.CreatedBy;
            paymentReason.CreatedDate = this.CreatedDate;

            return paymentReason as T;
        }
    }
}

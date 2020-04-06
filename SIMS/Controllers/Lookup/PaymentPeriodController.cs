using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class PaymentPeriodController : ApiController
    {
        [HttpGet]
        [Route("api/PaymentPeriod/GetPaymentPeriods")]
        public List<Models.Lookup.PaymentPeriodModel> GetPaymentPeriods()
        {
            BusinessLogic.Lookup.PaymentPeriodManager PaymentPeriodManager = new BusinessLogic.Lookup.PaymentPeriodManager();

            List<BusinessEntity.Lookup.PaymentPeriodEntity> PaymentPeriods = PaymentPeriodManager.GetPaymentPeriods();
            List<Models.Lookup.PaymentPeriodModel> PaymentPeriodModels = new List<Models.Lookup.PaymentPeriodModel>();

            foreach (BusinessEntity.Lookup.PaymentPeriodEntity PaymentPeriod in PaymentPeriods)
            {
                PaymentPeriodModels.Add(new Models.Lookup.PaymentPeriodModel(PaymentPeriod));
            }

            return PaymentPeriodModels;
        }

        [HttpGet]
        [Route("api/PaymentPeriod/GetPaymentPeriodByID")]
        public Models.Lookup.PaymentPeriodModel GetPaymentPeriodByID(int PaymentPeriodID)
        {
            BusinessLogic.Lookup.PaymentPeriodManager PaymentPeriodManager = new BusinessLogic.Lookup.PaymentPeriodManager();
            BusinessEntity.Lookup.PaymentPeriodEntity PaymentPeriod = PaymentPeriodManager.GetPaymentPeriodByID(PaymentPeriodID);

            return new Models.Lookup.PaymentPeriodModel(PaymentPeriod);
        }

        [HttpPost]
        [Route("api/PaymentPeriod/SavePaymentPeriod")]
        public BusinessEntity.Result SavePaymentPeriod(Models.Lookup.PaymentPeriodModel PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentPeriodManager PaymentPeriodManager = new BusinessLogic.Lookup.PaymentPeriodManager();
                result = PaymentPeriodManager.SavePaymentPeriod(PaymentPeriod.MapToEntity<BusinessEntity.Lookup.PaymentPeriodEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentPeriod save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PaymentPeriod/UpdatePaymentPeriod")]
        public BusinessEntity.Result UpdatePaymentPeriod(Models.Lookup.PaymentPeriodModel PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentPeriodManager PaymentPeriodManager = new BusinessLogic.Lookup.PaymentPeriodManager();
                result = PaymentPeriodManager.UpdatePaymentPeriod(PaymentPeriod.MapToEntity<BusinessEntity.Lookup.PaymentPeriodEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentPeriod update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PaymentPeriod/DeletePaymentPeriod")]
        public BusinessEntity.Result DeletePaymentPeriod(Models.Lookup.PaymentPeriodModel PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentPeriodManager PaymentPeriodManager = new BusinessLogic.Lookup.PaymentPeriodManager();
                result = PaymentPeriodManager.DeletePaymentPeriod(PaymentPeriod.MapToEntity<BusinessEntity.Lookup.PaymentPeriodEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentPeriod delete failed.";

                return result;
            }
        }
    }
}

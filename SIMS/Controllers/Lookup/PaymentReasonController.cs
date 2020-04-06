using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class PaymentReasonController : ApiController
    {
        [HttpGet]
        [Route("api/PaymentReason/GetPaymentReasons")]
        public List<Models.Lookup.PaymentReasonModel> GetPaymentReasons()
        {
            BusinessLogic.Lookup.PaymentReasonManager PaymentReasonManager = new BusinessLogic.Lookup.PaymentReasonManager();

            List<BusinessEntity.Lookup.PaymentReasonEntity> PaymentReasons = PaymentReasonManager.GetPaymentReasons();
            List<Models.Lookup.PaymentReasonModel> PaymentReasonModels = new List<Models.Lookup.PaymentReasonModel>();

            foreach (BusinessEntity.Lookup.PaymentReasonEntity PaymentReason in PaymentReasons)
            {
                PaymentReasonModels.Add(new Models.Lookup.PaymentReasonModel(PaymentReason));
            }

            return PaymentReasonModels;
        }

        [HttpGet]
        [Route("api/PaymentReason/GetPaymentReasonByID")]
        public Models.Lookup.PaymentReasonModel GetPaymentReasonByID(int PaymentReasonID)
        {
            BusinessLogic.Lookup.PaymentReasonManager PaymentReasonManager = new BusinessLogic.Lookup.PaymentReasonManager();
            BusinessEntity.Lookup.PaymentReasonEntity PaymentReason = PaymentReasonManager.GetPaymentReasonByID(PaymentReasonID);

            return new Models.Lookup.PaymentReasonModel(PaymentReason);
        }

        [HttpPost]
        [Route("api/PaymentReason/SavePaymentReason")]
        public BusinessEntity.Result SavePaymentReason(Models.Lookup.PaymentReasonModel PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentReasonManager PaymentReasonManager = new BusinessLogic.Lookup.PaymentReasonManager();
                result = PaymentReasonManager.SavePaymentReason(PaymentReason.MapToEntity<BusinessEntity.Lookup.PaymentReasonEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentReason save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PaymentReason/UpdatePaymentReason")]
        public BusinessEntity.Result UpdatePaymentReason(Models.Lookup.PaymentReasonModel PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentReasonManager PaymentReasonManager = new BusinessLogic.Lookup.PaymentReasonManager();
                result = PaymentReasonManager.UpdatePaymentReason(PaymentReason.MapToEntity<BusinessEntity.Lookup.PaymentReasonEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentReason update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PaymentReason/DeletePaymentReason")]
        public BusinessEntity.Result DeletePaymentReason(Models.Lookup.PaymentReasonModel PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PaymentReasonManager PaymentReasonManager = new BusinessLogic.Lookup.PaymentReasonManager();
                result = PaymentReasonManager.DeletePaymentReason(PaymentReason.MapToEntity<BusinessEntity.Lookup.PaymentReasonEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PaymentReason delete failed.";

                return result;
            }
        }
    }
}

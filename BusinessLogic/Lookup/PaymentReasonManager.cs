using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class PaymentReasonManager
    {
        public List<BusinessEntity.Lookup.PaymentReasonEntity> GetPaymentReasons()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPaymentReason> results = e.tblPaymentReasons.ToList();

            List<BusinessEntity.Lookup.PaymentReasonEntity> entities = new List<BusinessEntity.Lookup.PaymentReasonEntity>();
            foreach (DataAccessLogic.tblPaymentReason PaymentReason in results)
            {
                entities.Add(new BusinessEntity.Lookup.PaymentReasonEntity(PaymentReason));
            }

            return entities;
        }

        public BusinessEntity.Lookup.PaymentReasonEntity GetPaymentReasonByID(int PaymentReasonID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPaymentReason> results = e.tblPaymentReasons.Where(x => x.ID == PaymentReasonID).ToList();

            List<BusinessEntity.Lookup.PaymentReasonEntity> entities = new List<BusinessEntity.Lookup.PaymentReasonEntity>();
            foreach (DataAccessLogic.tblPaymentReason PaymentReason in results)
            {
                entities.Add(new BusinessEntity.Lookup.PaymentReasonEntity(PaymentReason));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SavePaymentReason(BusinessEntity.Lookup.PaymentReasonEntity PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblPaymentReasons.Add(PaymentReason.MapToModel<DataAccessLogic.tblPaymentReason>());
                e.SaveChanges();

                result.Message = "Saved Successfully.";
                result.Status = true;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Failed to save";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result UpdatePaymentReason(BusinessEntity.Lookup.PaymentReasonEntity PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPaymentReasons.Find(PaymentReason.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(PaymentReason);
                    e.SaveChanges();

                    result.Message = "Updated Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to update";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to update";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result DeletePaymentReason(BusinessEntity.Lookup.PaymentReasonEntity PaymentReason)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPaymentReasons.Find(PaymentReason.ID);
                if (original != null)
                {
                    e.tblPaymentReasons.Remove(e.tblPaymentReasons.Where(x => x.ID == PaymentReason.ID).First());
                    e.SaveChanges();

                    result.Message = "Deleted Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to delete";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to delete";
                result.Status = false;
                return result;
            }
        }
    }
}

using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class PaymentPeriodManager
    {
        public List<BusinessEntity.Lookup.PaymentPeriodEntity> GetPaymentPeriods()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPaymentPeriod> results = e.tblPaymentPeriods.ToList();

            List<BusinessEntity.Lookup.PaymentPeriodEntity> entities = new List<BusinessEntity.Lookup.PaymentPeriodEntity>();
            foreach (DataAccessLogic.tblPaymentPeriod PaymentPeriod in results)
            {
                entities.Add(new BusinessEntity.Lookup.PaymentPeriodEntity(PaymentPeriod));
            }

            return entities;
        }

        public BusinessEntity.Lookup.PaymentPeriodEntity GetPaymentPeriodByID(int PaymentPeriodID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPaymentPeriod> results = e.tblPaymentPeriods.Where(x => x.ID == PaymentPeriodID).ToList();

            List<BusinessEntity.Lookup.PaymentPeriodEntity> entities = new List<BusinessEntity.Lookup.PaymentPeriodEntity>();
            foreach (DataAccessLogic.tblPaymentPeriod PaymentPeriod in results)
            {
                entities.Add(new BusinessEntity.Lookup.PaymentPeriodEntity(PaymentPeriod));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SavePaymentPeriod(BusinessEntity.Lookup.PaymentPeriodEntity PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblPaymentPeriods.Add(PaymentPeriod.MapToModel<DataAccessLogic.tblPaymentPeriod>());
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

        public BusinessEntity.Result UpdatePaymentPeriod(BusinessEntity.Lookup.PaymentPeriodEntity PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPaymentPeriods.Find(PaymentPeriod.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(PaymentPeriod);
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

        public BusinessEntity.Result DeletePaymentPeriod(BusinessEntity.Lookup.PaymentPeriodEntity PaymentPeriod)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPaymentPeriods.Find(PaymentPeriod.ID);
                if (original != null)
                {
                    e.tblPaymentPeriods.Remove(e.tblPaymentPeriods.Where(x => x.ID == PaymentPeriod.ID).First());
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

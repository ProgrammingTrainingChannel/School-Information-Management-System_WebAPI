using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class AcademicQuarterManager
    {
        public List<BusinessEntity.Lookup.AcademicQuarterEntity> GetAcademicQuarters()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblAcademicQuarter> results = e.tblAcademicQuarters.ToList();

            List<BusinessEntity.Lookup.AcademicQuarterEntity> entities = new List<BusinessEntity.Lookup.AcademicQuarterEntity>();
            foreach (DataAccessLogic.tblAcademicQuarter AcademicQuarter in results)
            {
                entities.Add(new BusinessEntity.Lookup.AcademicQuarterEntity(AcademicQuarter));
            }

            return entities;
        }

        public BusinessEntity.Lookup.AcademicQuarterEntity GetAcademicQuarterByID(int AcademicQuarterID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblAcademicQuarter> results = e.tblAcademicQuarters.Where(x => x.ID == AcademicQuarterID).ToList();

            List<BusinessEntity.Lookup.AcademicQuarterEntity> entities = new List<BusinessEntity.Lookup.AcademicQuarterEntity>();
            foreach (DataAccessLogic.tblAcademicQuarter AcademicQuarter in results)
            {
                entities.Add(new BusinessEntity.Lookup.AcademicQuarterEntity(AcademicQuarter));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveAcademicQuarter(BusinessEntity.Lookup.AcademicQuarterEntity AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblAcademicQuarters.Add(AcademicQuarter.MapToModel<DataAccessLogic.tblAcademicQuarter>());
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

        public BusinessEntity.Result UpdateAcademicQuarter(BusinessEntity.Lookup.AcademicQuarterEntity AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblAcademicQuarters.Find(AcademicQuarter.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(AcademicQuarter);
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

        public BusinessEntity.Result DeleteAcademicQuarter(BusinessEntity.Lookup.AcademicQuarterEntity AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblAcademicQuarters.Find(AcademicQuarter.ID);
                if (original != null)
                {
                    e.tblAcademicQuarters.Remove(e.tblAcademicQuarters.Where(x => x.ID == AcademicQuarter.ID).First());
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

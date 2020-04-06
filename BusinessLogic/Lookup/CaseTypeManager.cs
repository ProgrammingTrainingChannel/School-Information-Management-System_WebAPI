using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class CaseTypeManager
    {
        public List<BusinessEntity.Lookup.CaseTypeEntity> GetCaseTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCaseType> results = e.tblCaseTypes.ToList();

            List<BusinessEntity.Lookup.CaseTypeEntity> entities = new List<BusinessEntity.Lookup.CaseTypeEntity>();
            foreach (DataAccessLogic.tblCaseType CaseType in results)
            {
                entities.Add(new BusinessEntity.Lookup.CaseTypeEntity(CaseType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.CaseTypeEntity GetCaseTypeByID(int CaseTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCaseType> results = e.tblCaseTypes.Where(x => x.ID == CaseTypeID).ToList();

            List<BusinessEntity.Lookup.CaseTypeEntity> entities = new List<BusinessEntity.Lookup.CaseTypeEntity>();
            foreach (DataAccessLogic.tblCaseType CaseType in results)
            {
                entities.Add(new BusinessEntity.Lookup.CaseTypeEntity(CaseType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveCaseType(BusinessEntity.Lookup.CaseTypeEntity CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblCaseTypes.Add(CaseType.MapToModel<DataAccessLogic.tblCaseType>());
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

        public BusinessEntity.Result UpdateCaseType(BusinessEntity.Lookup.CaseTypeEntity CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCaseTypes.Find(CaseType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(CaseType);
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

        public BusinessEntity.Result DeleteCaseType(BusinessEntity.Lookup.CaseTypeEntity CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCaseTypes.Find(CaseType.ID);
                if (original != null)
                {
                    e.tblCaseTypes.Remove(e.tblCaseTypes.Where(x => x.ID == CaseType.ID).First());
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

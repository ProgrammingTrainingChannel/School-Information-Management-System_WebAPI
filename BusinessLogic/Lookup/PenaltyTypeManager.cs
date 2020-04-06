using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class PenaltyTypeManager
    {
        public List<BusinessEntity.Lookup.PenalityTypeEntity> GetPenaltyTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPenalityType> results = e.tblPenalityTypes.ToList();

            List<BusinessEntity.Lookup.PenalityTypeEntity> entities = new List<BusinessEntity.Lookup.PenalityTypeEntity>();
            foreach (DataAccessLogic.tblPenalityType PenaltyType in results)
            {
                entities.Add(new BusinessEntity.Lookup.PenalityTypeEntity(PenaltyType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.PenalityTypeEntity GetPenaltyTypeByID(int PenaltyTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPenalityType> results = e.tblPenalityTypes.Where(x => x.ID == PenaltyTypeID).ToList();

            List<BusinessEntity.Lookup.PenalityTypeEntity> entities = new List<BusinessEntity.Lookup.PenalityTypeEntity>();
            foreach (DataAccessLogic.tblPenalityType PenaltyType in results)
            {
                entities.Add(new BusinessEntity.Lookup.PenalityTypeEntity(PenaltyType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SavePenaltyType(BusinessEntity.Lookup.PenalityTypeEntity PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblPenalityTypes.Add(PenaltyType.MapToModel<DataAccessLogic.tblPenalityType>());
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

        public BusinessEntity.Result UpdatePenaltyType(BusinessEntity.Lookup.PenalityTypeEntity PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPenalityTypes.Find(PenaltyType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(PenaltyType);
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

        public BusinessEntity.Result DeletePenaltyType(BusinessEntity.Lookup.PenalityTypeEntity PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPenalityTypes.Find(PenaltyType.ID);
                if (original != null)
                {
                    e.tblPenalityTypes.Remove(e.tblPenalityTypes.Where(x => x.ID == PenaltyType.ID).First());
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

using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class RegionManager
    {
        public List<BusinessEntity.Lookup.RegionEntity> GetRegions()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblRegion> results = e.tblRegions.ToList();

            List<BusinessEntity.Lookup.RegionEntity> entities = new List<BusinessEntity.Lookup.RegionEntity>();
            foreach (DataAccessLogic.tblRegion Region in results)
            {
                entities.Add(new BusinessEntity.Lookup.RegionEntity(Region));
            }

            return entities;
        }

        public BusinessEntity.Lookup.RegionEntity GetRegionByID(int RegionID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblRegion> results = e.tblRegions.Where(x => x.ID == RegionID).ToList();

            List<BusinessEntity.Lookup.RegionEntity> entities = new List<BusinessEntity.Lookup.RegionEntity>();
            foreach (DataAccessLogic.tblRegion Region in results)
            {
                entities.Add(new BusinessEntity.Lookup.RegionEntity(Region));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveRegion(BusinessEntity.Lookup.RegionEntity Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblRegions.Add(Region.MapToModel<DataAccessLogic.tblRegion>());
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

        public BusinessEntity.Result UpdateRegion(BusinessEntity.Lookup.RegionEntity Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblRegions.Find(Region.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Region);
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

        public BusinessEntity.Result DeleteRegion(BusinessEntity.Lookup.RegionEntity Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblRegions.Find(Region.ID);
                if (original != null)
                {
                    e.tblRegions.Remove(e.tblRegions.Where(x => x.ID == Region.ID).First());
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

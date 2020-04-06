using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class CampusManager
    {
        public List<BusinessEntity.Lookup.CampusEntity> GetCampuss()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCampu> results = e.tblCampus.ToList();

            List<BusinessEntity.Lookup.CampusEntity> entities = new List<BusinessEntity.Lookup.CampusEntity>();
            foreach (DataAccessLogic.tblCampu Campus in results)
            {
                entities.Add(new BusinessEntity.Lookup.CampusEntity(Campus));
            }

            return entities;
        }

        public BusinessEntity.Lookup.CampusEntity GetCampusByID(int CampusID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCampu> results = e.tblCampus.Where(x => x.ID == CampusID).ToList();

            List<BusinessEntity.Lookup.CampusEntity> entities = new List<BusinessEntity.Lookup.CampusEntity>();
            foreach (DataAccessLogic.tblCampu Campus in results)
            {
                entities.Add(new BusinessEntity.Lookup.CampusEntity(Campus));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveCampus(BusinessEntity.Lookup.CampusEntity Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblCampus.Add(Campus.MapToModel<DataAccessLogic.tblCampu>());
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

        public BusinessEntity.Result UpdateCampus(BusinessEntity.Lookup.CampusEntity Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCampus.Find(Campus.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Campus);
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

        public BusinessEntity.Result DeleteCampus(BusinessEntity.Lookup.CampusEntity Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCampus.Find(Campus.ID);
                if (original != null)
                {
                    e.tblCampus.Remove(e.tblCampus.Where(x => x.ID == Campus.ID).First());
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

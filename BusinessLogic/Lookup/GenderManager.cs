using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class GenderManager
    {
        public List<BusinessEntity.Lookup.GenderEntity> GetGenders()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGender> results = e.tblGenders.ToList();

            List<BusinessEntity.Lookup.GenderEntity> entities = new List<BusinessEntity.Lookup.GenderEntity>();
            foreach (DataAccessLogic.tblGender Gender in results)
            {
                entities.Add(new BusinessEntity.Lookup.GenderEntity(Gender));
            }

            return entities;
        }

        public BusinessEntity.Lookup.GenderEntity GetGenderByID(int GenderID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGender> results = e.tblGenders.Where(x => x.ID == GenderID).ToList();

            List<BusinessEntity.Lookup.GenderEntity> entities = new List<BusinessEntity.Lookup.GenderEntity>();
            foreach (DataAccessLogic.tblGender Gender in results)
            {
                entities.Add(new BusinessEntity.Lookup.GenderEntity(Gender));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveGender(BusinessEntity.Lookup.GenderEntity Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblGenders.Add(Gender.MapToModel<DataAccessLogic.tblGender>());
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

        public BusinessEntity.Result UpdateGender(BusinessEntity.Lookup.GenderEntity Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGenders.Find(Gender.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Gender);
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

        public BusinessEntity.Result DeleteGender(BusinessEntity.Lookup.GenderEntity Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGenders.Find(Gender.ID);
                if (original != null)
                {
                    e.tblGenders.Remove(e.tblGenders.Where(x => x.ID == Gender.ID).First());
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

using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class SubCityManager
    {
        public List<BusinessEntity.Lookup.SubCityEntity> GetSubCitys()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblSubCity> results = e.tblSubCities.ToList();

            List<BusinessEntity.Lookup.SubCityEntity> entities = new List<BusinessEntity.Lookup.SubCityEntity>();
            foreach (DataAccessLogic.tblSubCity SubCity in results)
            {
                entities.Add(new BusinessEntity.Lookup.SubCityEntity(SubCity));
            }

            return entities;
        }

        public BusinessEntity.Lookup.SubCityEntity GetSubCityByID(int SubCityID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblSubCity> results = e.tblSubCities.Where(x => x.ID == SubCityID).ToList();

            List<BusinessEntity.Lookup.SubCityEntity> entities = new List<BusinessEntity.Lookup.SubCityEntity>();
            foreach (DataAccessLogic.tblSubCity SubCity in results)
            {
                entities.Add(new BusinessEntity.Lookup.SubCityEntity(SubCity));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveSubCity(BusinessEntity.Lookup.SubCityEntity SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblSubCities.Add(SubCity.MapToModel<DataAccessLogic.tblSubCity>());
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

        public BusinessEntity.Result UpdateSubCity(BusinessEntity.Lookup.SubCityEntity SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblSubCities.Find(SubCity.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(SubCity);
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

        public BusinessEntity.Result DeleteSubCity(BusinessEntity.Lookup.SubCityEntity SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblSubCities.Find(SubCity.ID);
                if (original != null)
                {
                    e.tblSubCities.Remove(e.tblSubCities.Where(x => x.ID == SubCity.ID).First());
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

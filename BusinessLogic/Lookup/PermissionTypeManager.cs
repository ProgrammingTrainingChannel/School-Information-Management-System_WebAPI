using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class PermissionTypeManager
    {
        public List<BusinessEntity.Lookup.PermissionTypeEntity> GetPermissionTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPermissionType> results = e.tblPermissionTypes.ToList();

            List<BusinessEntity.Lookup.PermissionTypeEntity> entities = new List<BusinessEntity.Lookup.PermissionTypeEntity>();
            foreach (DataAccessLogic.tblPermissionType PermissionType in results)
            {
                entities.Add(new BusinessEntity.Lookup.PermissionTypeEntity(PermissionType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.PermissionTypeEntity GetPermissionTypeByID(int PermissionTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblPermissionType> results = e.tblPermissionTypes.Where(x => x.ID == PermissionTypeID).ToList();

            List<BusinessEntity.Lookup.PermissionTypeEntity> entities = new List<BusinessEntity.Lookup.PermissionTypeEntity>();
            foreach (DataAccessLogic.tblPermissionType PermissionType in results)
            {
                entities.Add(new BusinessEntity.Lookup.PermissionTypeEntity(PermissionType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SavePermissionType(BusinessEntity.Lookup.PermissionTypeEntity PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblPermissionTypes.Add(PermissionType.MapToModel<DataAccessLogic.tblPermissionType>());
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

        public BusinessEntity.Result UpdatePermissionType(BusinessEntity.Lookup.PermissionTypeEntity PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPermissionTypes.Find(PermissionType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(PermissionType);
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

        public BusinessEntity.Result DeletePermissionType(BusinessEntity.Lookup.PermissionTypeEntity PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblPermissionTypes.Find(PermissionType.ID);
                if (original != null)
                {
                    e.tblPermissionTypes.Remove(e.tblPermissionTypes.Where(x => x.ID == PermissionType.ID).First());
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

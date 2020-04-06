using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class WoredaManager
    {
        public List<BusinessEntity.Lookup.WoredaEntity> GetWoredas()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblWoreda> results = e.tblWoredas.ToList();

            List<BusinessEntity.Lookup.WoredaEntity> entities = new List<BusinessEntity.Lookup.WoredaEntity>();
            foreach (DataAccessLogic.tblWoreda Woreda in results)
            {
                entities.Add(new BusinessEntity.Lookup.WoredaEntity(Woreda));
            }

            return entities;
        }

        public BusinessEntity.Lookup.WoredaEntity GetWoredaByID(int WoredaID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblWoreda> results = e.tblWoredas.Where(x => x.ID == WoredaID).ToList();

            List<BusinessEntity.Lookup.WoredaEntity> entities = new List<BusinessEntity.Lookup.WoredaEntity>();
            foreach (DataAccessLogic.tblWoreda Woreda in results)
            {
                entities.Add(new BusinessEntity.Lookup.WoredaEntity(Woreda));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveWoreda(BusinessEntity.Lookup.WoredaEntity Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblWoredas.Add(Woreda.MapToModel<DataAccessLogic.tblWoreda>());
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

        public BusinessEntity.Result UpdateWoreda(BusinessEntity.Lookup.WoredaEntity Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblWoredas.Find(Woreda.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Woreda);
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

        public BusinessEntity.Result DeleteWoreda(BusinessEntity.Lookup.WoredaEntity Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblWoredas.Find(Woreda.ID);
                if (original != null)
                {
                    e.tblWoredas.Remove(e.tblWoredas.Where(x => x.ID == Woreda.ID).First());
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

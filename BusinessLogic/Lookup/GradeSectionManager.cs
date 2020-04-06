using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class GradeSectionManager
    {
        public List<BusinessEntity.Lookup.GradeSectionEntity> GetGradeSections()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGradeSection> results = e.tblGradeSections.ToList();

            List<BusinessEntity.Lookup.GradeSectionEntity> entities = new List<BusinessEntity.Lookup.GradeSectionEntity>();
            foreach (DataAccessLogic.tblGradeSection GradeSection in results)
            {
                entities.Add(new BusinessEntity.Lookup.GradeSectionEntity(GradeSection));
            }

            return entities;
        }

        public BusinessEntity.Lookup.GradeSectionEntity GetGradeSectionByID(int GradeSectionID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGradeSection> results = e.tblGradeSections.Where(x => x.ID == GradeSectionID).ToList();

            List<BusinessEntity.Lookup.GradeSectionEntity> entities = new List<BusinessEntity.Lookup.GradeSectionEntity>();
            foreach (DataAccessLogic.tblGradeSection GradeSection in results)
            {
                entities.Add(new BusinessEntity.Lookup.GradeSectionEntity(GradeSection));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveGradeSection(BusinessEntity.Lookup.GradeSectionEntity GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblGradeSections.Add(GradeSection.MapToModel<DataAccessLogic.tblGradeSection>());
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

        public BusinessEntity.Result UpdateGradeSection(BusinessEntity.Lookup.GradeSectionEntity GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGradeSections.Find(GradeSection.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(GradeSection);
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

        public BusinessEntity.Result DeleteGradeSection(BusinessEntity.Lookup.GradeSectionEntity GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGradeSections.Find(GradeSection.ID);
                if (original != null)
                {
                    e.tblGradeSections.Remove(e.tblGradeSections.Where(x => x.ID == GradeSection.ID).First());
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class GradeCourseController : ApiController
    {
        [HttpGet]
        [Route("api/GradeCourse/GetGradeCourses")]
        public List<Models.ClassTeacherSchedule.GradeCourseModel> GetGradeCourses()
        {
            BusinessLogic.ClassTeacherSchedule.GradeCourseManager GradeCourseManager = new BusinessLogic.ClassTeacherSchedule.GradeCourseManager();

            List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity> GradeCourses = GradeCourseManager.GetGradeCourses();
            List<Models.ClassTeacherSchedule.GradeCourseModel> GradeCourseModels = new List<Models.ClassTeacherSchedule.GradeCourseModel>();

            foreach (BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GradeCourse in GradeCourses)
            {
                GradeCourseModels.Add(new Models.ClassTeacherSchedule.GradeCourseModel(GradeCourse));
            }

            return GradeCourseModels;
        }

        [HttpGet]
        [Route("api/GradeCourse/GetGradeCourseByID")]
        public Models.ClassTeacherSchedule.GradeCourseModel GetGradeCourseByID(int GradeCourseID)
        {
            BusinessLogic.ClassTeacherSchedule.GradeCourseManager GradeCourseManager = new BusinessLogic.ClassTeacherSchedule.GradeCourseManager();
            BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GradeCourse = GradeCourseManager.GetGradeCourseByID(GradeCourseID);

            return new Models.ClassTeacherSchedule.GradeCourseModel(GradeCourse);
        }

        [HttpPost]
        [Route("api/GradeCourse/SaveGradeCourse")]
        public BusinessEntity.Result SaveGradeCourse(Models.ClassTeacherSchedule.GradeCourseModel GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ClassTeacherSchedule.GradeCourseManager GradeCourseManager = new BusinessLogic.ClassTeacherSchedule.GradeCourseManager();
                result = GradeCourseManager.SaveGradeCourse(GradeCourse.MapToEntity<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeCourse save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/GradeCourse/UpdateGradeCourse")]
        public BusinessEntity.Result UpdateGradeCourse(Models.ClassTeacherSchedule.GradeCourseModel GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ClassTeacherSchedule.GradeCourseManager GradeCourseManager = new BusinessLogic.ClassTeacherSchedule.GradeCourseManager();
                result = GradeCourseManager.UpdateGradeCourse(GradeCourse.MapToEntity<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeCourse update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/GradeCourse/DeleteGradeCourse")]
        public BusinessEntity.Result DeleteGradeCourse(Models.ClassTeacherSchedule.GradeCourseModel GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ClassTeacherSchedule.GradeCourseManager GradeCourseManager = new BusinessLogic.ClassTeacherSchedule.GradeCourseManager();
                result = GradeCourseManager.DeleteGradeCourse(GradeCourse.MapToEntity<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeCourse delete failed.";

                return result;
            }
        }
    }
}

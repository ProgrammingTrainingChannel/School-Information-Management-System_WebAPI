using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/Course/GetCourses")]
        public List<Models.Lookup.CourseModel> GetCourses()
        {
            BusinessLogic.Lookup.CourseManager CourseManager = new BusinessLogic.Lookup.CourseManager();

            List<BusinessEntity.Lookup.CourseEntity> Courses = CourseManager.GetCourses();
            List<Models.Lookup.CourseModel> CourseModels = new List<Models.Lookup.CourseModel>();

            foreach (BusinessEntity.Lookup.CourseEntity Course in Courses)
            {
                CourseModels.Add(new Models.Lookup.CourseModel(Course));
            }

            return CourseModels;
        }

        [HttpGet]
        [Route("api/Course/GetCourseByID")]
        public Models.Lookup.CourseModel GetCourseByID(int CourseID)
        {
            BusinessLogic.Lookup.CourseManager CourseManager = new BusinessLogic.Lookup.CourseManager();
            BusinessEntity.Lookup.CourseEntity Course = CourseManager.GetCourseByID(CourseID);

            return new Models.Lookup.CourseModel(Course);
        }

        [HttpPost]
        [Route("api/Course/SaveCourse")]
        public BusinessEntity.Result SaveCourse(Models.Lookup.CourseModel Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CourseManager CourseManager = new BusinessLogic.Lookup.CourseManager();
                result = CourseManager.SaveCourse(Course.MapToEntity<BusinessEntity.Lookup.CourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Course save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Course/UpdateCourse")]
        public BusinessEntity.Result UpdateCourse(Models.Lookup.CourseModel Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CourseManager CourseManager = new BusinessLogic.Lookup.CourseManager();
                result = CourseManager.UpdateCourse(Course.MapToEntity<BusinessEntity.Lookup.CourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Course update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Course/DeleteCourse")]
        public BusinessEntity.Result DeleteCourse(Models.Lookup.CourseModel Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CourseManager CourseManager = new BusinessLogic.Lookup.CourseManager();
                result = CourseManager.DeleteCourse(Course.MapToEntity<BusinessEntity.Lookup.CourseEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Course delete failed.";

                return result;
            }
        }
    }
}

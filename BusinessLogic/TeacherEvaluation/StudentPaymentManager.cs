using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.StudentPayment
{
    public class StudentPaymentManager
    {
        public List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity> GetStudentPayments()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudentPayment> results = e.tblStudentPayments.ToList();

            List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity> entities = new List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity>();
            foreach (DataAccessLogic.tblStudentPayment StudentPayment in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.StudentPaymentEntity(StudentPayment));
            }

            return entities;
        }

        public BusinessEntity.TeacherEvaluation.StudentPaymentEntity GetStudentPaymentByID(int StudentPaymentID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudentPayment> results = e.tblStudentPayments.Where(x => x.ID == StudentPaymentID).ToList();

            List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity> entities = new List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity>();
            foreach (DataAccessLogic.tblStudentPayment StudentPayment in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.StudentPaymentEntity(StudentPayment));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveStudentPayment(BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblStudentPayments.Add(StudentPayment.MapToModel<DataAccessLogic.tblStudentPayment>());
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

        public BusinessEntity.Result UpdateStudentPayment(BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudentPayments.Find(StudentPayment.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(StudentPayment);
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

        public BusinessEntity.Result DeleteStudentPayment(BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudentPayments.Find(StudentPayment.ID);
                if (original != null)
                {
                    e.tblStudentPayments.Remove(e.tblStudentPayments.Where(x => x.ID == StudentPayment.ID).First());
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

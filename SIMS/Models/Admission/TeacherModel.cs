using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Admission
{
    public class TeacherModel : IBase
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string MotherName { get; set; }
        public int GenderID { get; set; }
        public int CampusID { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FieldOfStudy { get; set; }
        public int DepartmentID { get; set; }
        public int MaritalStatusID { get; set; }
        public int YearOfExperience { get; set; }
        public string SkillDescription { get; set; }
        public int RegionID { get; set; }
        public int SubCityID { get; set; }
        public int WoredaID { get; set; }
        public string HouseNo { get; set; }
        public System.DateTime HiredDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public TeacherModel()
        {

        }

        public TeacherModel(BusinessEntity.Admission.TeacherEntity teacher)
        {
            this.ID = teacher.ID;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Admission.TeacherEntity teacher = new BusinessEntity.Admission.TeacherEntity();
            teacher.ID = this.ID;

            return teacher as T;
        }
    }
}

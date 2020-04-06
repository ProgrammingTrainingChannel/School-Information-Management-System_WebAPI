using BusinessEntity.Lookup;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Admission
{
    public class StudentModel : IBase
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string MotherName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string HouseNo { get; set; }
        public bool IsSponsored { get; set; }
        public bool IsHandicaped { get; set; }
        public int AdmissionYear { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public CampusModel Campus { get; set; }
        public GenderModel Gender { get; set; }
        public GradeSectionModel GradeSection { get; set; }
        public RegionModel Region { get; set; }
        public SubCityModel SubCity { get; set; }
        public WoredaModel Woreda { get; set; }

        public StudentModel()
        {

        }

        public StudentModel(BusinessEntity.Admission.StudentEntity student)
        {
            this.ID = student.ID;
            this.Fullname = student.Fullname;
            this.MotherName = student.MotherName;
            this.BirthDate = student.BirthDate;
            this.HouseNo = student.HouseNo;
            this.IsSponsored = student.IsSponsored;
            this.IsHandicaped = student.IsHandicaped;
            this.AdmissionYear = student.AdmissionYear;

            this.Campus = new CampusModel(student.Campus);
            this.Gender = new GenderModel(student.Gender);
            this.GradeSection = new GradeSectionModel(student.GradeSection);
            this.Region = new RegionModel(student.Region);
            this.SubCity = new SubCityModel(student.SubCity);
            this.Woreda = new WoredaModel(student.Woreda);

            this.CreatedBy = student.CreatedBy;
            this.CreatedDate = student.CreatedDate;
            this.UpdatedBy = student.UpdatedBy;
            this.UpdatedDate = student.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Admission.StudentEntity student = new BusinessEntity.Admission.StudentEntity();
            student.ID = this.ID;
            student.Fullname = this.Fullname;
            student.MotherName = this.MotherName;
            student.BirthDate = this.BirthDate;
            student.HouseNo = this.HouseNo;
            student.IsSponsored = this.IsSponsored;
            student.IsHandicaped = this.IsHandicaped;
            student.AdmissionYear = this.AdmissionYear;

            student.Campus = this.Campus.MapToEntity<BusinessEntity.Lookup.CampusEntity>();
            student.Gender = this.Gender.MapToEntity<BusinessEntity.Lookup.GenderEntity>();
            student.GradeSection = this.GradeSection.MapToEntity<BusinessEntity.Lookup.GradeSectionEntity>();
            student.Region = this.Region.MapToEntity<BusinessEntity.Lookup.RegionEntity>();
            student.SubCity = this.SubCity.MapToEntity<BusinessEntity.Lookup.SubCityEntity>();
            student.Woreda = this.Woreda.MapToEntity<BusinessEntity.Lookup.WoredaEntity>();

            student.CreatedBy = this.CreatedBy;
            student.CreatedDate = this.CreatedDate;
            student.UpdatedBy = this.UpdatedBy;
            student.UpdatedDate = this.UpdatedDate;

            return student as T;
        }
    }
}

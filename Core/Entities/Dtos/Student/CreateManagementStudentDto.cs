using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Student
{
    public class CreateManagementStudentDto : BaseDto
    {
        public CreateManagementStudentDto()
        {
            ModelType = ProjectModelType.Student;
        }

        public IFormFile ProfilePhotoFile { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public string SecurityToken { get; set; }

        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public List<SelectListItem> GenderSelectList { get; set; }
        public List<SelectListItem> TeacherList { get; set; }
        public List<SelectListItem> CourseList { get; set; }
    }
}

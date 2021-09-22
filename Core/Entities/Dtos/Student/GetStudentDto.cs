using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ResultExam;
using Core.Entities.Dtos.StudentStudyingGroup;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Student
{
    public class GetStudentDto : BaseDto
    {
        public GetStudentDto()
        {
            ModelType = ProjectModelType.Student;
        }

        public string ProfilePhotoPath { get; set; }
        public string AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountType AccountType { get; set; }
        public string SecurityToken { get; set; }

        public List<GetStudentStudyingGroupDto> StudentStudyingGroups { get; set; }
        public List<GetResultExamDto> ResultExams { get; set; }
    }
}

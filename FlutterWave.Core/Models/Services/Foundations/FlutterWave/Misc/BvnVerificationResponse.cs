using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class BvnVerificationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public BvnVerificationData Data { get; set; }
        public class BvnData
        {

            public string Nin { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Surname { get; set; }
            public object SerialNo { get; set; }
            public string FaceImage { get; set; }
            public string FirstName { get; set; }
            public object Landmarks { get; set; }
            public object BranchName { get; set; }
            public string MiddleName { get; set; }
            public object NameOnCard { get; set; }
            public string DateOfBirth { get; set; }
            public string LgaOfOrigin { get; set; }
            public string Watchlisted { get; set; }
            public object LgaOfCapture { get; set; }
            public string PhoneNumber1 { get; set; }
            public object PhoneNumber2 { get; set; }
            public string MaritalStatus { get; set; }
            public string StateOfOrigin { get; set; }
            public object EnrollBankCode { get; set; }
            public string EnrollUserName { get; set; }
            public object EnrollmentDate { get; set; }
            public string LgaOfResidence { get; set; }
            public string StateOfCapture { get; set; }
            public object AdditionalInfo1 { get; set; }
            public string ProductReference { get; set; }
            public string StateOfResidence { get; set; }
        }

        public class BvnVerificationData
        {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Status { get; set; }
            public string Reference { get; set; }
            public object CallbackUrl { get; set; }
            public BvnData BvnData { get; set; }
            public DateTime CreatedAt { get; set; }
        }




    }
}

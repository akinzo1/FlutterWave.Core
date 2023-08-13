using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification
{


    internal class ExternalBvnVerificationResponse
    {


        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalBvnVerificationData Data { get; set; }

        public class BvnData
        {
            [JsonProperty("nin")]
            public string Nin { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("surname")]
            public string Surname { get; set; }

            [JsonProperty("serialNo")]
            public object SerialNo { get; set; }

            [JsonProperty("faceImage")]
            public string FaceImage { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("landmarks")]
            public object Landmarks { get; set; }

            [JsonProperty("branchName")]
            public object BranchName { get; set; }

            [JsonProperty("middleName")]
            public string MiddleName { get; set; }

            [JsonProperty("nameOnCard")]
            public object NameOnCard { get; set; }

            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            [JsonProperty("lgaOfOrigin")]
            public string LgaOfOrigin { get; set; }

            [JsonProperty("watchlisted")]
            public string Watchlisted { get; set; }

            [JsonProperty("lgaOfCapture")]
            public object LgaOfCapture { get; set; }

            [JsonProperty("phoneNumber1")]
            public string PhoneNumber1 { get; set; }

            [JsonProperty("phoneNumber2")]
            public object PhoneNumber2 { get; set; }

            [JsonProperty("maritalStatus")]
            public string MaritalStatus { get; set; }

            [JsonProperty("stateOfOrigin")]
            public string StateOfOrigin { get; set; }

            [JsonProperty("enrollBankCode")]
            public object EnrollBankCode { get; set; }

            [JsonProperty("enrollUserName")]
            public string EnrollUserName { get; set; }

            [JsonProperty("enrollmentDate")]
            public object EnrollmentDate { get; set; }

            [JsonProperty("lgaOfResidence")]
            public string LgaOfResidence { get; set; }

            [JsonProperty("stateOfCapture")]
            public string StateOfCapture { get; set; }

            [JsonProperty("additionalInfo1")]
            public object AdditionalInfo1 { get; set; }

            [JsonProperty("productReference")]
            public string ProductReference { get; set; }

            [JsonProperty("stateOfResidence")]
            public string StateOfResidence { get; set; }
        }

        public class ExternalBvnVerificationData
        {
            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("callback_url")]
            public object CallbackUrl { get; set; }

            [JsonProperty("bvn_data")]
            public BvnData BvnData { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }




    }
}

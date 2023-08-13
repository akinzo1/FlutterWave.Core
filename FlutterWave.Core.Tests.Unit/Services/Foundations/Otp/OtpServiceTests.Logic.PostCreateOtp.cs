



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateOtpWithCreateOtpRequestAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomOtpProperties();


            var randomExternalCreateOtpRequest = new ExternalCreateOtpRequest
            {

                Customer = new ExternalCreateOtpRequest.ExternalCustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender

            };


            var randomExternalCreateOtpResponse = new ExternalCreateOtpResponse
            {

                Message = createRandomOtpProperties.Message,
                Status = createRandomOtpProperties.Status,
                Data = ((List<dynamic>)createRandomOtpProperties.Data).Select(data =>
                {
                    return new ExternalCreateOtpResponse.Datum
                    {
                        Expiry = data.Expiry,
                        Medium = data.Medium,
                        Otp = data.Otp,
                        Reference = data.Reference,
                    };

                }).ToList()

            };



            var randomCreateOtpRequest = new CreateOtpRequest
            {

                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender
            };

            var randomCreateOtpResponse = new CreateOtpResponse
            {

                Message = createRandomOtpProperties.Message,
                Status = createRandomOtpProperties.Status,
                Data = ((List<dynamic>)createRandomOtpProperties.Data).Select(data =>
                {
                    return new CreateOtpResponse.Datum
                    {
                        Expiry = data.Expiry,
                        Medium = data.Medium,
                        Otp = data.Otp,
                        Reference = data.Reference,
                    };

                }).ToList()

            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
            };

            CreateOtp inputCreateOtp = randomCreateOtp;
            CreateOtp expectedCreateOtp = inputCreateOtp.DeepClone();
            expectedCreateOtp.Response = randomCreateOtpResponse;

            ExternalCreateOtpRequest mappedExternalCreateOtpRequest =
               randomExternalCreateOtpRequest;

            ExternalCreateOtpResponse returnedExternalCreateOtpResponse =
                randomExternalCreateOtpResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.PostCreateOtpAsync(It.Is(
                 SameExternalCreateOtpRequestRequestAs(mappedExternalCreateOtpRequest))))
                .ReturnsAsync(returnedExternalCreateOtpResponse);

            // when
            CreateOtp actualCreateOtp =
                await this.otpService.PostCreateOtpAsync(inputCreateOtp);

            // then
            actualCreateOtp.Should().BeEquivalentTo(expectedCreateOtp);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateOtpAsync(It.Is(
                   SameExternalCreateOtpRequestRequestAs(mappedExternalCreateOtpRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
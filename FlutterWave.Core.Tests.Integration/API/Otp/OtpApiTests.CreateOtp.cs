using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;

namespace FlutterWave.Core.Tests.Integration.API.Otp
{
    public partial class OtpApiTests
    {
        [Fact]
        public async Task ShouldCreateOtpAsync()
        {
            // given
            var input = new CreateOtp
            {
                Request = new CreateOtpRequest
                {
                    Customer = new CreateOtpRequest.CustomerModel
                    {
                        Email = "slimahmad6@gmail.com",
                        Name = "Ahmad",
                        Phone = "08058382350"
                    },
                    Expiry = 3,
                    Length = 3,
                    Medium = new List<string> { "USSD" },
                    Send = true,
                    Sender = "Panda-tut"

                }
            };

            // when
            CreateOtp retrievedAIModel =
              await this.flutterWaveClient.Otp.CreateOtpAsync(input);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}
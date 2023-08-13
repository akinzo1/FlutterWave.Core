using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldPostCreateVirtualCardAsync()
        {

            // given
            var request = new CreateVirtualCard
            {
                Request = new CreateVirtualCardRequest
                {
                    Amount = 123,
                    Email = "developers@flutterwavego.com",
                    BillingAddress = "010101010",
                    BillingCity = "US",
                    BillingCountry = "uuyyuprer",
                    BillingName = "044",
                    BillingPostalCode = "12345",
                    BillingState = "12345",
                    CallbackUrl = "we",
                    Currency = "NG",
                    DateOfBirth = "1234",
                    DebitCurrency = "12345",
                    FirstName = "12345",
                    Gender = "12345",
                    LastName = "12345",
                    Phone = "12345",
                    Title = "12345",


                }
            };

            // . when
            CreateVirtualCard responseModels =
                await this.flutterWaveClient.VirtualCards.CreateVirtualCardAsync(request);

            // then
            Assert.NotNull(responseModels);
        }
    }
}

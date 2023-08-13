



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdatePayoutSubaccountWithUpdatePayoutSubaccountRequestAsync()
        {
            // given 



            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
              CreateRandomUpdatePayoutSubaccountRequestProperties();

            dynamic createRandomUpdatePayoutSubaccountResponseProperties =
                CreateRandomUpdatePayoutSubaccountResponseProperties();


            var randomExternalUpdatePayoutSubaccountRequest = new ExternalUpdatePayoutSubaccountRequest
            {
                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                Mobilenumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomExternalUpdatePayoutSubaccountResponse = new ExternalUpdatePayoutSubaccountResponse
            {
                Data = new ExternalUpdatePayoutSubaccountResponse.ExternalUpdatePayoutSubaccountData
                {
                    CreatedAt = createRandomUpdatePayoutSubaccountResponseProperties.Data.CreatedAt,
                    AccountName = createRandomUpdatePayoutSubaccountResponseProperties.Data.AccountName,
                    Email = createRandomUpdatePayoutSubaccountResponseProperties.Data.Email,
                    Mobilenumber = createRandomUpdatePayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Country = createRandomUpdatePayoutSubaccountResponseProperties.Data.Country,
                    Status = createRandomUpdatePayoutSubaccountResponseProperties.Data.Status,
                    Nuban = createRandomUpdatePayoutSubaccountResponseProperties.Data.Nuban,
                    Id = createRandomUpdatePayoutSubaccountResponseProperties.Data.Id,
                    AccountReference = createRandomUpdatePayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomUpdatePayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomUpdatePayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomUpdatePayoutSubaccountResponseProperties.Data.BarterId



                },
                Message = createRandomUpdatePayoutSubaccountResponseProperties.Message,
                Status = createRandomUpdatePayoutSubaccountResponseProperties.Status,

            };


            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {
                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber

            };

            var randomUpdatePayoutSubaccountResponse = new UpdatePayoutSubaccountResponse
            {

                Data = new UpdatePayoutSubaccountResponse.UpdatePayoutSubaccountData
                {
                    CreatedAt = createRandomUpdatePayoutSubaccountResponseProperties.Data.CreatedAt,
                    AccountName = createRandomUpdatePayoutSubaccountResponseProperties.Data.AccountName,
                    Email = createRandomUpdatePayoutSubaccountResponseProperties.Data.Email,
                    Mobilenumber = createRandomUpdatePayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Country = createRandomUpdatePayoutSubaccountResponseProperties.Data.Country,
                    Status = createRandomUpdatePayoutSubaccountResponseProperties.Data.Status,
                    Nuban = createRandomUpdatePayoutSubaccountResponseProperties.Data.Nuban,
                    Id = createRandomUpdatePayoutSubaccountResponseProperties.Data.Id,
                    AccountReference = createRandomUpdatePayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomUpdatePayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomUpdatePayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomUpdatePayoutSubaccountResponseProperties.Data.BarterId




                },
                Message = createRandomUpdatePayoutSubaccountResponseProperties.Message,
                Status = createRandomUpdatePayoutSubaccountResponseProperties.Status,
            };


            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest,
            };

            var randomSubaccountId = GetRandomString();

            UpdatePayoutSubaccount inputUpdatePayoutSubaccount = randomUpdatePayoutSubaccount;
            UpdatePayoutSubaccount expectedUpdatePayoutSubaccount = inputUpdatePayoutSubaccount.DeepClone();
            expectedUpdatePayoutSubaccount.Response = randomUpdatePayoutSubaccountResponse;

            ExternalUpdatePayoutSubaccountRequest mappedExternalUpdatePayoutSubaccountRequest =
               randomExternalUpdatePayoutSubaccountRequest;

            ExternalUpdatePayoutSubaccountResponse returnedExternalUpdatePayoutSubaccountResponse =
                randomExternalUpdatePayoutSubaccountResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.Is(
                      SameExternalUpdatePayoutSubaccountRequestAs(mappedExternalUpdatePayoutSubaccountRequest))))
                     .ReturnsAsync(returnedExternalUpdatePayoutSubaccountResponse);

            // when
            UpdatePayoutSubaccount actualCreateUpdatePayoutSubaccount =
               await this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(randomSubaccountId, inputUpdatePayoutSubaccount);

            // then
            actualCreateUpdatePayoutSubaccount.Should().BeEquivalentTo(expectedUpdatePayoutSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.Is(
                   SameExternalUpdatePayoutSubaccountRequestAs(mappedExternalUpdatePayoutSubaccountRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
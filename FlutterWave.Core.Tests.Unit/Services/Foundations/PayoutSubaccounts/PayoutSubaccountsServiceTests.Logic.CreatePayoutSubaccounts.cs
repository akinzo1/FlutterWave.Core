



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
        public async Task ShouldPostCreatePayoutSubaccountWithCreatePayoutSubaccountRequestAsync()
        {
            // given 



            dynamic createRandomCreatePayoutSubaccountRequestProperties =
              CreateRandomCreatePayoutSubaccountRequestProperties();

            dynamic createRandomCreatePayoutSubaccountResponseProperties =
                CreateRandomCreatePayoutSubaccountResponseProperties();


            var randomExternalCreatePayoutSubaccountRequest = new ExternalCreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber

            };

            var randomExternalCreatePayoutSubaccountResponse = new ExternalCreatePayoutSubaccountResponse
            {
                Data = new ExternalCreatePayoutSubaccountResponse.ExternalCreatePayoutSubaccountData
                {
                    AccountName = createRandomCreatePayoutSubaccountResponseProperties.Data.AccountName,
                    Mobilenumber = createRandomCreatePayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Email = createRandomCreatePayoutSubaccountResponseProperties.Data.Email,
                    Country = createRandomCreatePayoutSubaccountResponseProperties.Data.Country,
                    AccountReference = createRandomCreatePayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomCreatePayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomCreatePayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomCreatePayoutSubaccountResponseProperties.Data.BarterId,
                    CreatedAt = createRandomCreatePayoutSubaccountResponseProperties.Data.CreatedAt,
                    Id = createRandomCreatePayoutSubaccountResponseProperties.Data.Id,
                    Nuban = createRandomCreatePayoutSubaccountResponseProperties.Data.Nuban,
                    Status = createRandomCreatePayoutSubaccountResponseProperties.Data.Status


                },
                Message = createRandomCreatePayoutSubaccountResponseProperties.Message,
                Status = createRandomCreatePayoutSubaccountResponseProperties.Status,

            };


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber,



            };

            var randomCreatePayoutSubaccountResponse = new CreatePayoutSubaccountResponse
            {

                Data = new CreatePayoutSubaccountResponse.CreatePayoutSubaccountData
                {
                    AccountName = createRandomCreatePayoutSubaccountResponseProperties.Data.AccountName,
                    MobileNumber = createRandomCreatePayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Email = createRandomCreatePayoutSubaccountResponseProperties.Data.Email,
                    Country = createRandomCreatePayoutSubaccountResponseProperties.Data.Country,
                    AccountReference = createRandomCreatePayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomCreatePayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomCreatePayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomCreatePayoutSubaccountResponseProperties.Data.BarterId,
                    CreatedAt = createRandomCreatePayoutSubaccountResponseProperties.Data.CreatedAt,
                    Id = createRandomCreatePayoutSubaccountResponseProperties.Data.Id,
                    Nuban = createRandomCreatePayoutSubaccountResponseProperties.Data.Nuban,
                    Status = createRandomCreatePayoutSubaccountResponseProperties.Data.Status


                },
                Message = createRandomCreatePayoutSubaccountResponseProperties.Message,
                Status = createRandomCreatePayoutSubaccountResponseProperties.Status,

            };


            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest,
            };



            CreatePayoutSubaccount inputCreatePayoutSubaccount = randomCreatePayoutSubaccount;
            CreatePayoutSubaccount expectedCreatePayoutSubaccount = inputCreatePayoutSubaccount.DeepClone();
            expectedCreatePayoutSubaccount.Response = randomCreatePayoutSubaccountResponse;

            ExternalCreatePayoutSubaccountRequest mappedExternalCreatePayoutSubaccountRequest =
               randomExternalCreatePayoutSubaccountRequest;

            ExternalCreatePayoutSubaccountResponse returnedExternalCreatePayoutSubaccountResponse =
                randomExternalCreatePayoutSubaccountResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.Is(
                      SameExternalCreatePayoutSubaccountRequestAs(mappedExternalCreatePayoutSubaccountRequest))))
                     .ReturnsAsync(returnedExternalCreatePayoutSubaccountResponse);

            // when
            CreatePayoutSubaccount actualCreateCreatePayoutSubaccount =
               await this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(inputCreatePayoutSubaccount);

            // then
            actualCreateCreatePayoutSubaccount.Should().BeEquivalentTo(expectedCreatePayoutSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreatePayoutSubaccountAsync(It.Is(
                   SameExternalCreatePayoutSubaccountRequestAs(mappedExternalCreatePayoutSubaccountRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
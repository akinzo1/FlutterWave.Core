



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldListPayoutSubaccountsAsync()
        {
            // given 
            dynamic createRandomListPayoutSubaccountsResponseProperties =
                 CreateRandomListPayoutSubaccountsResponseProperties();

            var randomSubaccountId = GetRandomNumber();

            var randomExternalListPayoutSubaccountsResponse = new ExternalListPayoutSubaccountsResponse
            {
                Message = createRandomListPayoutSubaccountsResponseProperties.Message,
                Status = createRandomListPayoutSubaccountsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomListPayoutSubaccountsResponseProperties.Data).Select(data =>
                {
                    return new ExternalListPayoutSubaccountsResponse.Datum
                    {
                        Id = data.Id,
                        BarterId = data.BarterId,
                        BankName = data.BankName,
                        BankCode = data.BankCode,
                        AccountReference = data.AccountReference,
                        Nuban = data.Nuban,
                        Status = data.Status,
                        AccountName = data.AccountName,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        Email = data.Email,
                        Mobilenumber = data.Mobilenumber,

                    };

                }).ToList(),




            };

            var randomExpectedListPayoutSubaccountsResponse = new ListPayoutSubaccountsResponse
            {
                Message = createRandomListPayoutSubaccountsResponseProperties.Message,
                Status = createRandomListPayoutSubaccountsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomListPayoutSubaccountsResponseProperties.Data).Select(data =>
                {
                    return new ListPayoutSubaccountsResponse.Datum
                    {
                        Id = data.Id,
                        BarterId = data.BarterId,
                        BankName = data.BankName,
                        BankCode = data.BankCode,
                        AccountReference = data.AccountReference,
                        Nuban = data.Nuban,
                        Status = data.Status,
                        AccountName = data.AccountName,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        Email = data.Email,
                        Mobilenumber = data.Mobilenumber,

                    };

                }).ToList(),

            };


            var expectedInputListPayoutSubaccounts = new ListPayoutSubaccounts
            {
                Response = randomExpectedListPayoutSubaccountsResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetListPayoutSubaccountsAsync())
                    .ReturnsAsync(randomExternalListPayoutSubaccountsResponse);

            // when
            ListPayoutSubaccounts actualListPayoutSubaccounts =
                await this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            // then
            actualListPayoutSubaccounts.Should().BeEquivalentTo(expectedInputListPayoutSubaccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
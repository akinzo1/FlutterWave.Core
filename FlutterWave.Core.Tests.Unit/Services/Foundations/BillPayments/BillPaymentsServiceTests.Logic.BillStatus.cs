using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldBillStatusPaymentWithTransactionReferenceAsync()
        {
            // given 
            string randomRandomReference = GetRandomString();
            string inputReference = randomRandomReference;

            dynamic createRandomBillStatusPaymentsProperties =
                CreateRandomBillStatusPaymentsProperties();

            var randomExternalBillStatusPaymentsResponse = new ExternalBillStatusPaymentResponse
            {

                Message = createRandomBillStatusPaymentsProperties.Message,
                Data = new ExternalBillStatusPaymentResponse.Datum
                {
                    Amount = createRandomBillStatusPaymentsProperties.Data.Amount,
                    Currency = createRandomBillStatusPaymentsProperties.Data.Currency,
                    Extra = createRandomBillStatusPaymentsProperties.Data.Extra,
                    Fee = createRandomBillStatusPaymentsProperties.Data.Fee,
                    FlwRef = createRandomBillStatusPaymentsProperties.Data.FlwRef,
                    Token = createRandomBillStatusPaymentsProperties.Data.Token,
                    TxRef = createRandomBillStatusPaymentsProperties.Data.TxRef,
                },
                Status = createRandomBillStatusPaymentsProperties.Status,
            };

            var randomExpectedBillStatusPaymentResponse = new BillStatusPaymentResponse
            {
                Message = createRandomBillStatusPaymentsProperties.Message,
                Data = new BillStatusPaymentResponse.Datum
                {
                    Amount = createRandomBillStatusPaymentsProperties.Data.Amount,
                    Currency = createRandomBillStatusPaymentsProperties.Data.Currency,
                    Extra = createRandomBillStatusPaymentsProperties.Data.Extra,
                    Fee = createRandomBillStatusPaymentsProperties.Data.Fee,
                    FlwRef = createRandomBillStatusPaymentsProperties.Data.FlwRef,
                    Token = createRandomBillStatusPaymentsProperties.Data.Token,
                    TxRef = createRandomBillStatusPaymentsProperties.Data.TxRef,
                },
                Status = createRandomBillStatusPaymentsProperties.Status,

            };

            var expectedBillPaymentsStatus = new BillPaymentsStatus
            {
                Response = randomExpectedBillStatusPaymentResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillStatusPaymentAsync(inputReference))
                    .ReturnsAsync(randomExternalBillStatusPaymentsResponse);

            // when
            BillPaymentsStatus actualBillPaymentsStatus =
               await this.billPaymentsService.GetBillStatusPaymentAsync(inputReference);

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedBillPaymentsStatus);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(inputReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
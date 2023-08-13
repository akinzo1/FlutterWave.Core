using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBillPaymentRequestAsync()
        {
            // given 

            dynamic createRandomBillPaymentsProperties =
                CreateRandomGetBillPaymentsProperties();

            var randomExternalBillPaymentsResponse = new ExternalBillPaymentsResponse
            {

                Message = createRandomBillPaymentsProperties.Message,
                Data = new ExternalBillPaymentsResponse.Datum
                {
                    Reference = createRandomBillPaymentsProperties.Data.Reference,
                    Summary = ((List<dynamic>)createRandomBillPaymentsProperties.Data.Summary).Select(summary =>
                    {
                        return new ExternalBillPaymentsResponse.Summary
                        {
                            CountAirtime = summary.CountAirtime,
                            CountDstv = summary.CountDstv,
                            Currency = summary.Currency,
                            SumAirtime = summary.SumAirtime,
                            SumBills = summary.SumBills,
                            SumCommission = summary.SumCommission,
                            SumDstv = summary.SumDstv,
                        };
                    }).ToList(),
                    Total = createRandomBillPaymentsProperties.Data.Total,
                    TotalPages = createRandomBillPaymentsProperties.Data.TotalPages,
                },
                Status = createRandomBillPaymentsProperties.Status,
            };

            var randomExpectedBillPaymentResponse = new BillPaymentsResponse
            {

                Message = createRandomBillPaymentsProperties.Message,
                Data = new BillPaymentsResponse.Datum
                {
                    Reference = createRandomBillPaymentsProperties.Data.Reference,
                    Summary = ((List<dynamic>)createRandomBillPaymentsProperties.Data.Summary).Select(summary =>
                    {
                        return new BillPaymentsResponse.Summary
                        {
                            CountAirtime = summary.CountAirtime,
                            CountDstv = summary.CountDstv,
                            Currency = summary.Currency,
                            SumAirtime = summary.SumAirtime,
                            SumBills = summary.SumBills,
                            SumCommission = summary.SumCommission,
                            SumDstv = summary.SumDstv,
                        };
                    }).ToList(),
                    Total = createRandomBillPaymentsProperties.Data.Total,
                    TotalPages = createRandomBillPaymentsProperties.Data.TotalPages,
                },
                Status = createRandomBillPaymentsProperties.Status,

            };

            var expectedBillPayments = new BillPayments
            {
                Response = randomExpectedBillPaymentResponse
            };




            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillPaymentsAsync())
                    .ReturnsAsync(randomExternalBillPaymentsResponse);

            // when
            BillPayments actualBillPayments =
               await this.billPaymentsService.GetBillPaymentsAsync();

            // then
            actualBillPayments.Should().BeEquivalentTo(expectedBillPayments);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillPaymentsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
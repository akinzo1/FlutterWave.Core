using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldBulkBulkBillPaymentWithBulkBillPaymentRequestAsync()
        {
            // given 


            dynamic createRandomBulkBillPaymentsProperties =
                CreateRandomBulkBillPaymentsProperties();


            dynamic createRandomBulkBillPaymentsRequestProperties =
                CreateRandomBulkBillPaymentsRequestProperties();

            var randomExternalBulkBillPaymentRequest = new ExternalBulkBillPaymentsRequest
            {
                BulkData = ((List<dynamic>)createRandomBulkBillPaymentsRequestProperties.BulkData).Select(bulkData =>
                {
                    return new ExternalBulkBillPaymentsRequest.BulkDatum
                    {
                        Amount = bulkData.Amount,
                        Country = bulkData.Country,
                        Customer = bulkData.Customer,
                        Recurrence = bulkData.Recurrence,
                        Reference = bulkData.Reference,
                        Type = bulkData.Type,

                    };
                }).ToList(),
                BulkReference = createRandomBulkBillPaymentsRequestProperties.BulkReference,
                CallbackUrl = createRandomBulkBillPaymentsRequestProperties.CallbackUrl



            };

            var randomExternalBulkBillPaymentsResponse = new ExternalBulkBillPaymentsResponse
            {
                Data = new ExternalBulkBillPaymentsResponse.Datum
                {
                    BatchReference = createRandomBulkBillPaymentsProperties.Data.BatchReference
                },
                Message = createRandomBulkBillPaymentsProperties.Message,
                Status = createRandomBulkBillPaymentsProperties.Status,

            };


            var randomBulkBillPaymentRequest = new BulkBillPaymentsRequest
            {
                BulkData = ((List<dynamic>)createRandomBulkBillPaymentsRequestProperties.BulkData).Select(bulkData =>
                {
                    return new BulkBillPaymentsRequest.BulkDatum
                    {
                        Amount = bulkData.Amount,
                        Country = bulkData.Country,
                        Customer = bulkData.Customer,
                        Recurrence = bulkData.Recurrence,
                        Reference = bulkData.Reference,
                        Type = bulkData.Type,

                    };
                }).ToList(),
                BulkReference = createRandomBulkBillPaymentsRequestProperties.BulkReference,
                CallbackUrl = createRandomBulkBillPaymentsRequestProperties.CallbackUrl

            };

            var randomBulkBillResponse = new BulkBillPaymentsResponse
            {
                Data = new BulkBillPaymentsResponse.Datum
                {
                    BatchReference = createRandomBulkBillPaymentsProperties.Data.BatchReference
                },
                Message = createRandomBulkBillPaymentsProperties.Message,
                Status = createRandomBulkBillPaymentsProperties.Status,

            };

            var randomBulkBillPayments = new BulkBillPayments
            {
                Request = randomBulkBillPaymentRequest,
            };

            BulkBillPayments inputBulkBillPayments = randomBulkBillPayments;
            BulkBillPayments expectedBulkBillPayments = inputBulkBillPayments.DeepClone();
            expectedBulkBillPayments.Response = randomBulkBillResponse;

            ExternalBulkBillPaymentsRequest mappedExternalBulkBillPaymentsRequest =
               randomExternalBulkBillPaymentRequest;

            ExternalBulkBillPaymentsResponse returnedExternalBulkBillPaymentsResponse =
                randomExternalBulkBillPaymentsResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkBillAsync(It.Is(
                     SameExternalBulkBillPaymentsRequestAs(mappedExternalBulkBillPaymentsRequest))))
                        .ReturnsAsync(returnedExternalBulkBillPaymentsResponse);

            // when
            BulkBillPayments actualCreateBillPayments =
               await this.billPaymentsService.PostCreateBulkBillAsync(inputBulkBillPayments);

            // then
            actualCreateBillPayments.Should().BeEquivalentTo(expectedBulkBillPayments);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateBulkBillAsync(It.Is(
                   SameExternalBulkBillPaymentsRequestAs(mappedExternalBulkBillPaymentsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
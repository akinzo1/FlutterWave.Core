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
        public async Task ShouldPostBillPaymentWithBillPaymentRequestAsync()
        {
            // given 
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;

            dynamic createRandomBillPaymentsProperties =
                CreateRandomBillPaymentsProperties();


            var randomExternalCreateBillPaymentRequest = new ExternalCreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomExternalCreateBillResponse = new ExternalCreateBillPaymentResponse
            {
                Data = new ExternalCreateBillPaymentResponse.Datum
                {
                    TxRef = createRandomBillPaymentsProperties.Data.TxRef,
                    Reference = createRandomBillPaymentsProperties.Data.Reference,
                    Amount = createRandomBillPaymentsProperties.Data.Amount,
                    FlwRef = createRandomBillPaymentsProperties.Data.FlwRef,
                    Network = createRandomBillPaymentsProperties.Data.Network,
                    PhoneNumber = createRandomBillPaymentsProperties.Data.PhoneNumber,
                },
                Message = createRandomBillPaymentsProperties.Message,
                Status = createRandomBillPaymentsProperties.Status,

            };


            var randomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomCreateBillResponse = new CreateBillPaymentResponse
            {
                Data = new CreateBillPaymentResponse.Datum
                {
                    TxRef = createRandomBillPaymentsProperties.Data.TxRef,
                    Reference = createRandomBillPaymentsProperties.Data.Reference,
                    Amount = createRandomBillPaymentsProperties.Data.Amount,
                    FlwRef = createRandomBillPaymentsProperties.Data.FlwRef,
                    Network = createRandomBillPaymentsProperties.Data.Network,
                    PhoneNumber = createRandomBillPaymentsProperties.Data.PhoneNumber,
                },
                Message = createRandomBillPaymentsProperties.Message,
                Status = createRandomBillPaymentsProperties.Status,

            };

            var randomPostBillPayments = new PostBillPayments
            {
                Request = randomCreateBillPaymentRequest,
            };

            PostBillPayments inputBillPayments = randomPostBillPayments;
            PostBillPayments expectedBillPayments = inputBillPayments.DeepClone();
            expectedBillPayments.Response = randomCreateBillResponse;

            ExternalCreateBillPaymentRequest mappedExternalCreateBillRequest =
               randomExternalCreateBillPaymentRequest;

            ExternalCreateBillPaymentResponse returnedExternalCreateBillResponse =
                randomExternalCreateBillResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBillPaymentAsync(It.Is(
                     SameExternalCreateBillPaymentRequestAs(mappedExternalCreateBillRequest))))
                        .ReturnsAsync(returnedExternalCreateBillResponse);

            // when
            PostBillPayments actualCreateBillPayments =
               await this.billPaymentsService.PostCreateBillPaymentAsync(inputBillPayments);

            // then
            actualCreateBillPayments.Should().BeEquivalentTo(expectedBillPayments);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateBillPaymentAsync(It.Is(
                   SameExternalCreateBillPaymentRequestAs(mappedExternalCreateBillRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
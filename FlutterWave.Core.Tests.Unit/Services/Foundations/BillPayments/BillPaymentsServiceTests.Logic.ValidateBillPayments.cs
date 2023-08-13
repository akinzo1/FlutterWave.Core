using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldValidateBillPaymentWithTransactionIdAsync()
        {
            // given 
            string randomItemCode = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomCode = GetRandomString();
            string inputItemCode = randomItemCode;
            string inputCustomer = randomItemCode;
            string inputCode = randomCode;

            dynamic createRandomValidateBillServicesProperties =
                CreateRandomValidateBillServicesProperties();

            var randomExternalValidateBillServiceResponse = new ExternalValidateBillServiceResponse
            {

                Message = createRandomValidateBillServicesProperties.Message,
                Data = new ExternalValidateBillServiceResponse.Datum
                {
                    Address = createRandomValidateBillServicesProperties.Data.Address,
                    BillerCode = createRandomValidateBillServicesProperties.Data.BillerCode,
                    Customer = createRandomValidateBillServicesProperties.Data.Customer,
                    Email = createRandomValidateBillServicesProperties.Data.Email,
                    Fee = createRandomValidateBillServicesProperties.Data.Fee,
                    Maximum = createRandomValidateBillServicesProperties.Data.Maximum,
                    Minimum = createRandomValidateBillServicesProperties.Data.Minimum,
                    Name = createRandomValidateBillServicesProperties.Data.Name,
                    ProductCode = createRandomValidateBillServicesProperties.Data.ProductCode,
                    ResponseCode = createRandomValidateBillServicesProperties.Data.ResponseCode,
                    ResponseMessage = createRandomValidateBillServicesProperties.Data.ResponseMessage
                },
                Status = createRandomValidateBillServicesProperties.Status,
            };

            var randomExpectedValidateBillServiceResponse = new ValidateBillServiceResponse
            {
                Message = createRandomValidateBillServicesProperties.Message,
                Data = new ValidateBillServiceResponse.Datum
                {
                    Address = createRandomValidateBillServicesProperties.Data.Address,
                    BillerCode = createRandomValidateBillServicesProperties.Data.BillerCode,
                    Customer = createRandomValidateBillServicesProperties.Data.Customer,
                    Email = createRandomValidateBillServicesProperties.Data.Email,
                    Fee = createRandomValidateBillServicesProperties.Data.Fee,
                    Maximum = createRandomValidateBillServicesProperties.Data.Maximum,
                    Minimum = createRandomValidateBillServicesProperties.Data.Minimum,
                    Name = createRandomValidateBillServicesProperties.Data.Name,
                    ProductCode = createRandomValidateBillServicesProperties.Data.ProductCode,
                    ResponseCode = createRandomValidateBillServicesProperties.Data.ResponseCode,
                    ResponseMessage = createRandomValidateBillServicesProperties.Data.ResponseMessage
                },
                Status = createRandomValidateBillServicesProperties.Status,

            };

            var expectedValidateBillService = new ValidateBillService
            {
                Response = randomExpectedValidateBillServiceResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetValidateBillServiceAsync(inputItemCode, inputCode, inputCustomer))
                    .ReturnsAsync(randomExternalValidateBillServiceResponse);

            // when
            ValidateBillService actualValidateBillPayments =
               await this.billPaymentsService.GetValidateBillServiceAsync(inputItemCode, inputCode, inputCustomer);

            // then
            actualValidateBillPayments.Should().BeEquivalentTo(expectedValidateBillService);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetValidateBillServiceAsync(inputItemCode, inputCode, inputCustomer),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
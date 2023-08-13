



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTokenizedChargeAsync()
        {
            // given 
            dynamic createRandomFetchBulkTokenizedChargeResponseProperties =
                 CreateRandomFetchBulkTokenizedChargeResponseProperties();

            var randomBulkId = GetRandomNumber();

            var randomExternalFetchTokenizedChargeResponse = new ExternalFetchBulkTokenizedChargeResponse
            {
                Message = createRandomFetchBulkTokenizedChargeResponseProperties.Message,
                Status = createRandomFetchBulkTokenizedChargeResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchBulkTokenizedChargeResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchBulkTokenizedChargeResponse.Datum
                    {
                        AccountId = data.AccountId,
                        Amount = data.Amount,
                        AmountSettled = data.AmountSettled,
                        AppFee = data.AppFee,
                        AuthModel = data.AuthModel,
                        Card = new ExternalFetchBulkTokenizedChargeResponse.Card
                        {
                            Country = data.Card.Country,
                            Expiry = data.Card.Expiry,
                            First6digits = data.Card.First6digits,
                            Issuer = data.Card.Issuer,
                            Last4digits = data.Card.Last4digits,
                            Type = data.Card.Type

                        },
                        ChargedAmount = data.ChargedAmount,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Customer = new ExternalFetchBulkTokenizedChargeResponse.Customer
                        {
                            CreatedAt = data.Customer.CreatedAt,
                            Email = data.Customer.Email,
                            Id = data.Customer.Id,
                            Name = data.Customer.Name,
                            PhoneNumber = data.Customer.PhoneNumber,

                        },
                        Id = data.Id,
                        DeviceFingerprint = data.DeviceFingerprint,
                        FlwRef = data.FlwRef,
                        Ip = data.Ip,
                        MerchantFee = data.MerchantFee,
                        Narration = data.Narration,
                        PaymentType = data.PaymentType,
                        ProcessorResponse = data.ProcessorResponse,
                        Status = data.Status,
                        TxRef = data.TxRef,

                    };
                }).ToList(),




            };

            var randomExpectedBulkTokenizedChargeResponse = new FetchBulkTokenizedChargeResponse
            {
                Message = createRandomFetchBulkTokenizedChargeResponseProperties.Message,
                Status = createRandomFetchBulkTokenizedChargeResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchBulkTokenizedChargeResponseProperties.Data).Select(data =>
                {
                    return new FetchBulkTokenizedChargeResponse.Datum
                    {
                        AccountId = data.AccountId,
                        Amount = data.Amount,
                        AmountSettled = data.AmountSettled,
                        AppFee = data.AppFee,
                        AuthModel = data.AuthModel,
                        Card = new FetchBulkTokenizedChargeResponse.Card
                        {
                            Country = data.Card.Country,
                            Expiry = data.Card.Expiry,
                            First6digits = data.Card.First6digits,
                            Issuer = data.Card.Issuer,
                            Last4digits = data.Card.Last4digits,
                            Type = data.Card.Type

                        },
                        ChargedAmount = data.ChargedAmount,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Customer = new FetchBulkTokenizedChargeResponse.Customer
                        {
                            CreatedAt = data.Customer.CreatedAt,
                            Email = data.Customer.Email,
                            Id = data.Customer.Id,
                            Name = data.Customer.Name,
                            PhoneNumber = data.Customer.PhoneNumber,

                        },
                        Id = data.Id,
                        DeviceFingerprint = data.DeviceFingerprint,
                        FlwRef = data.FlwRef,
                        Ip = data.Ip,
                        MerchantFee = data.MerchantFee,
                        Narration = data.Narration,
                        PaymentType = data.PaymentType,
                        ProcessorResponse = data.ProcessorResponse,
                        Status = data.Status,
                        TxRef = data.TxRef,

                    };
                }).ToList(),

            };


            var expectedInputBulkTokenizedCharge = new FetchBulkTokenizedCharge
            {
                Response = randomExpectedBulkTokenizedChargeResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId))
                    .ReturnsAsync(randomExternalFetchTokenizedChargeResponse);

            // when
            FetchBulkTokenizedCharge actualBulkTokenizedCharge =
                await this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            // then
            actualBulkTokenizedCharge.Should().BeEquivalentTo(expectedInputBulkTokenizedCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
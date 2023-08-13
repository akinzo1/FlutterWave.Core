



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTokenizedStatusAsync()
        {
            // given 
            dynamic createRandomFetchBulkTokenizedStatusResponseProperties =
                 CreateRandomFetchBulkTokenizedStatusResponseProperties();

            var randomBulkId = GetRandomNumber();

            var randomExternalFetchTokenizedChargeResponse = new ExternalBulkTokenizedStatusResponse
            {
                Message = createRandomFetchBulkTokenizedStatusResponseProperties.Message,
                Status = createRandomFetchBulkTokenizedStatusResponseProperties.Status,
                Data = new ExternalBulkTokenizedStatusResponse.ExternalBulkTokenizedStatusData
                {
                    Approver = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Approver,
                    Id = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Id,
                    PendingCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.PendingCharges,
                    ProcessedCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.ProcessedCharges,
                    Title = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Title,
                    TotalCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.TotalCharges
                },




            };

            var randomExpectedBulkTokenizedStatusResponse = new BulkTokenizedStatusResponse
            {
                Message = createRandomFetchBulkTokenizedStatusResponseProperties.Message,
                Status = createRandomFetchBulkTokenizedStatusResponseProperties.Status,
                Data = new BulkTokenizedStatusResponse.BulkTokenizedStatusData
                {
                    Approver = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Approver,
                    Id = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Id,
                    PendingCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.PendingCharges,
                    ProcessedCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.ProcessedCharges,
                    Title = createRandomFetchBulkTokenizedStatusResponseProperties.Data.Title,
                    TotalCharges = createRandomFetchBulkTokenizedStatusResponseProperties.Data.TotalCharges
                },

            };


            var expectedInputBulkTokenizedStatus = new BulkTokenizedStatus
            {
                Response = randomExpectedBulkTokenizedStatusResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId))
                    .ReturnsAsync(randomExternalFetchTokenizedChargeResponse);

            // when
            BulkTokenizedStatus actualBulkTokenizedStatus =
                await this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            // then
            actualBulkTokenizedStatus.Should().BeEquivalentTo(expectedInputBulkTokenizedStatus);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
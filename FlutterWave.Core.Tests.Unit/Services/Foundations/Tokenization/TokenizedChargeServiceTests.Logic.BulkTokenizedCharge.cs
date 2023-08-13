



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateBulkTokenizedChargeWithCreateBulkTokenizedChargeRequestAsync()
        {
            // given 



            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
              CreateRandomCreateBulkTokenizedChargeRequestProperties();

            dynamic createRandomCreateBulkTokenizedChargeResponseProperties =
                CreateRandomCreateBulkTokenizedChargeResponseProperties();


            var randomExternalCreateBulkTokenizedChargeRequest = new ExternalCreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
                {
                    return new ExternalCreateBulkTokenizedChargeRequest.BulkDatum
                    {
                        Amount = data.Amount,
                        Country = data.Country,
                        Currency = data.Currency,
                        Email = data.Email,
                        FirstName = data.FirstName,
                        Ip = data.Ip,
                        LastName = data.LastName,
                        Token = data.Token,
                        TxRef = data.TxRef,
                    };
                }).ToList(),
                RetryStrategy = new ExternalCreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomExternalCreateBulkTokenizedChargeResponse = new ExternalCreateBulkTokenizedChargeResponse
            {
                Data = new ExternalCreateBulkTokenizedChargeResponse.ExternalCreateBulkTokenizedChargeData
                {

                    Approver = createRandomCreateBulkTokenizedChargeResponseProperties.Data.Approver,
                    CreatedAt = createRandomCreateBulkTokenizedChargeResponseProperties.Data.CreatedAt,
                    Id = createRandomCreateBulkTokenizedChargeResponseProperties.Data.Id


                },
                Message = createRandomCreateBulkTokenizedChargeResponseProperties.Message,
                Status = createRandomCreateBulkTokenizedChargeResponseProperties.Status,

            };


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
                {
                    return new CreateBulkTokenizedChargeRequest.BulkDatum
                    {
                        Amount = data.Amount,
                        Country = data.Country,
                        Currency = data.Currency,
                        Email = data.Email,
                        FirstName = data.FirstName,
                        Ip = data.Ip,
                        LastName = data.LastName,
                        Token = data.Token,
                        TxRef = data.TxRef,
                    };
                }).ToList(),

                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title

            };

            var randomCreateBulkTokenizedChargeResponse = new CreateBulkTokenizedChargeResponse
            {

                Data = new CreateBulkTokenizedChargeResponse.CreateBulkTokenizedChargeData
                {

                    Approver = createRandomCreateBulkTokenizedChargeResponseProperties.Data.Approver,
                    CreatedAt = createRandomCreateBulkTokenizedChargeResponseProperties.Data.CreatedAt,
                    Id = createRandomCreateBulkTokenizedChargeResponseProperties.Data.Id


                },
                Message = createRandomCreateBulkTokenizedChargeResponseProperties.Message,
                Status = createRandomCreateBulkTokenizedChargeResponseProperties.Status,

            };


            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest,
            };

            CreateBulkTokenizedCharge inputCreateBulkTokenizedCharge = randomCreateBulkTokenizedCharge;
            CreateBulkTokenizedCharge expectedCreateBulkTokenizedCharge = inputCreateBulkTokenizedCharge.DeepClone();
            expectedCreateBulkTokenizedCharge.Response = randomCreateBulkTokenizedChargeResponse;

            ExternalCreateBulkTokenizedChargeRequest mappedExternalCreateBulkTokenizedChargeRequest =
               randomExternalCreateBulkTokenizedChargeRequest;

            ExternalCreateBulkTokenizedChargeResponse returnedExternalCreateBulkTokenizedChargeResponse =
                randomExternalCreateBulkTokenizedChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.Is(
                      SameExternalCreateBulkTokenizedChargeRequestAs(mappedExternalCreateBulkTokenizedChargeRequest))))
                     .ReturnsAsync(returnedExternalCreateBulkTokenizedChargeResponse);

            // when
            CreateBulkTokenizedCharge actualCreateCreateBulkTokenizedCharge =
               await this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(inputCreateBulkTokenizedCharge);

            // then
            actualCreateCreateBulkTokenizedCharge.Should().BeEquivalentTo(expectedCreateBulkTokenizedCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateBulkTokenizedChargeAsync(It.Is(
                   SameExternalCreateBulkTokenizedChargeRequestAs(mappedExternalCreateBulkTokenizedChargeRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
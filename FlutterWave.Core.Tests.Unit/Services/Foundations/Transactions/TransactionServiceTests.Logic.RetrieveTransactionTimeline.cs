



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTransactionTimelineWithTransactionIdAsync()
        {
            // given 
            string randomNumber = GetRandomString();
            string randomTransactionId = randomNumber;
            string inputTransactionId = randomTransactionId;

            dynamic createTransactionTimelineRandomProperties =
                CreateRandomTransactionTimelineProperties();

            var randomExternalTransactionTimelineResponse = new ExternalTransactionTimelineResponse
            {
                Message = createTransactionTimelineRandomProperties.Message,
                Status = createTransactionTimelineRandomProperties.Status,
                Data = ((List<dynamic>)createTransactionTimelineRandomProperties.Data).Select(items =>
                {
                    return new ExternalTransactionTimelineResponse.Datum
                    {
                        Note = items.Note,
                        Actor = items.Actor,
                        Object = items.Object,
                        Action = items.Action,
                        Context = items.Context,
                        CreatedAt = items.CreatedAt,
                    };
                }).ToList()

            };

            var randomTransactionTimelineResponse = new TransactionTimelineResponse
            {
                Message = createTransactionTimelineRandomProperties.Message,
                Status = createTransactionTimelineRandomProperties.Status,
                Data = ((List<dynamic>)createTransactionTimelineRandomProperties.Data).Select(items =>
                {
                    return new TransactionTimelineResponse.Datum
                    {
                        Note = items.Note,
                        Actor = items.Actor,
                        Object = items.Object,
                        Action = items.Action,
                        Context = items.Context,
                        CreatedAt = items.CreatedAt,
                    };
                }).ToList()

            };

            TransactionTimeline expectedTransactionTimeline = new TransactionTimeline
            {
                Response = randomTransactionTimelineResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionTimelineAsync(inputTransactionId))
                    .ReturnsAsync(randomExternalTransactionTimelineResponse);

            // when
            TransactionTimeline actualTransactionTimeline =
                await this.transactionsService.GetTransactionTimelineAsync(inputTransactionId);

            // then
            actualTransactionTimeline.Should().BeEquivalentTo(expectedTransactionTimeline);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldDeleteSubaccountAsync()
        {
            // given 
            dynamic createRandomDeleteSubaccountResponseProperties =
                 CreateRandomDeleteSubaccountResponseProperties();

            var randomSubaccountId = GetRandomNumber();

            var randomExternalDeleteSubaccountResponse = new ExternalDeleteSubaccountResponse
            {
                Message = createRandomDeleteSubaccountResponseProperties.Message,
                Status = createRandomDeleteSubaccountResponseProperties.Status,
                Data = createRandomDeleteSubaccountResponseProperties.Data,




            };

            var randomExpectedDeleteSubaccountResponse = new DeleteSubaccountResponse
            {
                Message = createRandomDeleteSubaccountResponseProperties.Message,
                Status = createRandomDeleteSubaccountResponseProperties.Status,
                Data = createRandomDeleteSubaccountResponseProperties.Data,

            };


            var expectedInputDeleteSubaccount = new DeleteSubaccount
            {
                Response = randomExpectedDeleteSubaccountResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                    .ReturnsAsync(randomExternalDeleteSubaccountResponse);

            // when
            DeleteSubaccount actualDeleteSubaccount =
                await this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            // then
            actualDeleteSubaccount.Should().BeEquivalentTo(expectedInputDeleteSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
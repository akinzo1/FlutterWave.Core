using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.CollectionSubaccounts
{
    public partial class CollectionSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPostCreateCollectionSubaccountAsync()
        {

            // given
            var request = new CreateCollectionSubaccount
            {
                Request = new CreateCollectionSubaccountRequest
                {
                    AccountBank = "044",
                    AccountNumber = "0690000037",
                    BusinessName = "Eternal Blue",
                    BusinessEmail = "petya@stux.net",
                    BusinessContact = "Anonymous",
                    BusinessContactMobile = "090890382",
                    BusinessMobile = "09087930450",
                    Country = "NG",
                    Meta = new List<CreateCollectionSubaccountRequest.Metum>
                    {
                        new CreateCollectionSubaccountRequest.Metum
                        {
                           MetaName = "mem_adr",
                           MetaValue = "0x16241F327213"
                        }
                    },
                    SplitType = "perecentage",
                    SplitValue = 0.1
                }
            };

            // . when
            CreateCollectionSubaccount responseAIModels =
                await this.flutterWaveClient.CollectionSubaccounts.CreateCollectionSubaccountAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}

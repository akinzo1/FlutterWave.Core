using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldCreateBulkTransfersAsync()
        {
            // given

            var BulkTransfers = new BulkCreateTransfers
            {
                Request = new CreateBulkTransferRequest
                {
                    Title = "Test run",
                    BulkData = new List<CreateBulkTransferRequest.BulkDatum> {
                        new CreateBulkTransferRequest.BulkDatum
                     {
                            BankCode = "FNB",
                            AccountNumber = "0031625807099",
                            Amount = 6950,
                            Currency = "ZAR",
                            Narration = "Test transfer to Flutterwave Developers",
                            Reference = "bulk_Transfers_0021_PMCK",

                            Meta = new List<CreateBulkTransferRequest.Metum>
                            {
                                new CreateBulkTransferRequest.Metum
                             {

                                FirstName = "Flutterwave",
                                LastName = "Developers",
                                Email = "developers@flutterwavego.com",
                                MobileNumber = "+23457558595",
                                RecipientAddress = "234 Kings road, Cape Town"
                             },
                                 new CreateBulkTransferRequest.Metum
                             {

                                FirstName = "Flutterwave",
                                LastName = "Developers",
                                Email = "developers@flutterwavego.com",
                                MobileNumber = "+23457558595",
                                RecipientAddress = "234 Kings road, Cape Town",

                             },

                            }

                     },
                        new CreateBulkTransferRequest.BulkDatum
                     {
                            BankCode = "FNB",
                            AccountNumber = "0031625807099",
                            Amount = 6950,
                            Currency = "ZAR",
                            Narration = "Test transfer to Flutterwave Developers",
                            Reference = "bulk_Transfers_0021_PMCK",

                            Meta = new List<CreateBulkTransferRequest.Metum>
                            {
                                new CreateBulkTransferRequest.Metum
                             {

                                FirstName = "Flutterwave",
                                LastName = "Developers",
                                Email = "developers@flutterwavego.com",
                                MobileNumber = "+23457558595",
                                RecipientAddress = "234 Kings road, Cape Town"
                             },
                                 new CreateBulkTransferRequest.Metum
                             {

                                FirstName = "Flutterwave",
                                LastName = "Developers",
                                Email = "developers@flutterwavego.com",
                                MobileNumber = "+23457558595",
                                RecipientAddress = "234 Kings road, Cape Town",

                             },

                            }

                     }



                }
                }
            };

            // when
            BulkCreateTransfers retrievedAIModel =
                await this.flutterWaveClient.Transfers.CreateBulkTransferAsync(BulkTransfers);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}
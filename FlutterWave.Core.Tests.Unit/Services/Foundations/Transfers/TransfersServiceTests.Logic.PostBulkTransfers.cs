



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostBulkCreateVirtualAccountWithBulkCreateTransfersRequestAsync()
        {
            // given
            string inputEmail = GetRandomString();
            int inputAccounts = GetRandomNumber();
            string inputTxRef = GetRandomString();
            bool inputIsPermanent = GetRandomBoolean();

            var request = CreateRandomBulkTransferRequest();

            dynamic createRandomBulkTransfersProperties =
                   CreateRandomBulkTransferProperties();


            var randomExternalCreateBulkTransfersRequest = new ExternalCreateBulkTransferRequest
            {

                BulkData = request.BulkData.Select(data =>
                {
                    return new ExternalCreateBulkTransferRequest.BulkDatum
                    {
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankCode = data.BankCode,
                        Currency = data.Currency,
                        Meta = data.Meta.Select(meta =>
                       {
                           return new ExternalCreateBulkTransferRequest.Metum
                           {
                               Email = meta.Email,
                               FirstName = meta.FirstName,
                               LastName = meta.LastName,
                               MobileNumber = meta.MobileNumber,
                               RecipientAddress = meta.RecipientAddress,
                           };
                       }).ToList(),
                        Narration = data.Narration,
                        Reference = data.Reference,
                    };
                }).ToList(),
                Title = request.Title

            };



            var randomExternalBulkCreateTransfersResponse = new ExternalCreateBulkTransferResponse
            {

                Message = createRandomBulkTransfersProperties.Message,
                Status = createRandomBulkTransfersProperties.Status,
                Data = new ExternalCreateBulkTransferResponse.Datum
                {
                    Approver = createRandomBulkTransfersProperties.Data.Approver,
                    CreatedAt = createRandomBulkTransfersProperties.Data.CreatedAt,
                    Id = createRandomBulkTransfersProperties.Data.Id
                }

            };



            var randomBulkCreateTransferRequest = new CreateBulkTransferRequest
            {

                BulkData = request.BulkData.Select(data =>
                {
                    return new CreateBulkTransferRequest.BulkDatum
                    {
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankCode = data.BankCode,
                        Currency = data.Currency,
                        Meta = data.Meta.Select(meta =>
                        {
                            return new CreateBulkTransferRequest.Metum
                            {
                                Email = meta.Email,
                                FirstName = meta.FirstName,
                                LastName = meta.LastName,
                                MobileNumber = meta.MobileNumber,
                                RecipientAddress = meta.RecipientAddress,
                            };
                        }).ToList(),
                        Narration = data.Narration,
                        Reference = data.Reference,
                    };
                }).ToList(),
                Title = request.Title

            };




            var randomBulkCreateTransfersResponse = new CreateBulkTransferResponse
            {

                Message = createRandomBulkTransfersProperties.Message,
                Status = createRandomBulkTransfersProperties.Status,
                Data = new CreateBulkTransferResponse.Datum
                {
                    Approver = createRandomBulkTransfersProperties.Data.Approver,
                    CreatedAt = createRandomBulkTransfersProperties.Data.CreatedAt,
                    Id = createRandomBulkTransfersProperties.Data.Id
                }

            };



            var randomBulkCreateTransfers = new BulkCreateTransfers
            {
                Request = randomBulkCreateTransferRequest,
            };

            BulkCreateTransfers inputBulkCreateTransfers = randomBulkCreateTransfers;
            BulkCreateTransfers expectedBulkCreateTransfers = inputBulkCreateTransfers.DeepClone();
            expectedBulkCreateTransfers.Response = randomBulkCreateTransfersResponse;

            ExternalCreateBulkTransferRequest mappedExternalBulkCreateTransfersRequest =
               randomExternalCreateBulkTransfersRequest;

            ExternalCreateBulkTransferResponse returnedExternalBulkCreateTransfersResponse =
                randomExternalBulkCreateTransfersResponse;


            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTransferAsync(It.Is(
                 SameExternalCreateBulkTransferRequestAs(mappedExternalBulkCreateTransfersRequest))))
                .ReturnsAsync(randomExternalBulkCreateTransfersResponse);


            // when
            BulkCreateTransfers actualBulkCreateTransfers =
                await this.transfersService.PostCreateBulkTransferAsync(inputBulkCreateTransfers);

            // then
            actualBulkCreateTransfers.Should().BeEquivalentTo(expectedBulkCreateTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateBulkTransferAsync(It.Is(
                   SameExternalCreateBulkTransferRequestAs(mappedExternalBulkCreateTransfersRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
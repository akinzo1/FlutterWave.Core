using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostBankTransferWithBankTransferRequestAsync()
        {
            // given 



            dynamic createRandomBankTransferRequestProperties =
              CreateRandomBankTransferRequestProperties();

            dynamic createRandomBankTransferResponseProperties =
                CreateRandomBankTransferResponseProperties();


            var randomExternalBankTransferRequest = new ExternalBankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomExternalBankTransferResponse = new ExternalBankTransferResponse
            {
                Meta = new ExternalBankTransferResponse.ExternalBankTransferMeta
                {

                    Authorization = new ExternalBankTransferResponse.Authorization
                    {
                        AccountExpiration = createRandomBankTransferResponseProperties.Meta.Authorization.AccountExpiration,
                        Mode = createRandomBankTransferResponseProperties.Meta.Authorization.Mode,
                        TransferAccount = createRandomBankTransferResponseProperties.Meta.Authorization.TransferAccount,
                        TransferAmount = createRandomBankTransferResponseProperties.Meta.Authorization.TransferAmount,
                        TransferBank = createRandomBankTransferResponseProperties.Meta.Authorization.TransferBank,
                        TransferNote = createRandomBankTransferResponseProperties.Meta.Authorization.TransferNote,
                        TransferReference = createRandomBankTransferResponseProperties.Meta.Authorization.TransferReference
                    }

                },

                Message = createRandomBankTransferResponseProperties.Message,
                Status = createRandomBankTransferResponseProperties.Status,

            };


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransferResponse = new BankTransferResponse
            {
                Meta = new BankTransferResponse.BankTransferMeta
                {

                    Authorization = new BankTransferResponse.Authorization
                    {
                        AccountExpiration = createRandomBankTransferResponseProperties.Meta.Authorization.AccountExpiration,
                        Mode = createRandomBankTransferResponseProperties.Meta.Authorization.Mode,
                        TransferAccount = createRandomBankTransferResponseProperties.Meta.Authorization.TransferAccount,
                        TransferAmount = createRandomBankTransferResponseProperties.Meta.Authorization.TransferAmount,
                        TransferBank = createRandomBankTransferResponseProperties.Meta.Authorization.TransferBank,
                        TransferNote = createRandomBankTransferResponseProperties.Meta.Authorization.TransferNote,
                        TransferReference = createRandomBankTransferResponseProperties.Meta.Authorization.TransferReference
                    }

                },

                Message = createRandomBankTransferResponseProperties.Message,
                Status = createRandomBankTransferResponseProperties.Status,

            };


            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest,
            };

            BankTransfer inputBankTransfer = randomBankTransfer;
            BankTransfer expectedBankTransfer = inputBankTransfer.DeepClone();
            expectedBankTransfer.Response = randomBankTransferResponse;

            ExternalBankTransferRequest mappedExternalBankTransferRequest =
               randomExternalBankTransferRequest;

            ExternalBankTransferResponse returnedExternalBankTransferResponse =
                randomExternalBankTransferResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeBankTransferAsync(It.Is(
                     SameExternalBankTransferRequestAs(mappedExternalBankTransferRequest))))
                     .ReturnsAsync(returnedExternalBankTransferResponse);

            // when
            BankTransfer actualCreateBankTransfer =
               await this.chargeService.PostChargeBankTransferRequestAsync(inputBankTransfer);

            // then
            actualCreateBankTransfer.Should().BeEquivalentTo(expectedBankTransfer);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeBankTransferAsync(It.Is(
                   SameExternalBankTransferRequestAs(mappedExternalBankTransferRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}




using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualCardsClient
{
    public partial class VirtualCardsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public VirtualCardsClientTests()
        {
            this.apiKey = GetRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTime GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
        new IntRange(min: 2, max: 10).GetValue();

        private FetchVirtualCard ConvertToVirtualCardResponse(ExternalFetchVirtualCardResponse externalFetchVirtualCardResponse)
        {
            return new FetchVirtualCard
            {
                Response = new FetchVirtualCardResponse
                {
                    Message = externalFetchVirtualCardResponse.Message,
                    Data = new FetchVirtualCardResponse.FetchVirtualCardData
                    {
                        AccountId = externalFetchVirtualCardResponse.Data.AccountId,
                        Amount = externalFetchVirtualCardResponse.Data.Amount,
                        Address1 = externalFetchVirtualCardResponse.Data.Address1,
                        Address2 = externalFetchVirtualCardResponse.Data.Address2,
                        BinCheckName = externalFetchVirtualCardResponse.Data.BinCheckName,
                        CallbackUrl = externalFetchVirtualCardResponse.Data.CallbackUrl,
                        CardHash = externalFetchVirtualCardResponse.Data.CardHash,
                        CardPan = externalFetchVirtualCardResponse.Data.CardPan,
                        CardType = externalFetchVirtualCardResponse.Data.CardType,
                        City = externalFetchVirtualCardResponse.Data.City,
                        CreatedAt = externalFetchVirtualCardResponse.Data.CreatedAt,
                        Currency = externalFetchVirtualCardResponse.Data.Currency,
                        Cvv = externalFetchVirtualCardResponse.Data.Cvv,
                        Expiration = externalFetchVirtualCardResponse.Data.Expiration,
                        Id = externalFetchVirtualCardResponse.Data.Id,
                        IsActive = externalFetchVirtualCardResponse.Data.IsActive,
                        MaskedPan = externalFetchVirtualCardResponse.Data.MaskedPan,
                        NameOnCard = externalFetchVirtualCardResponse.Data.NameOnCard,
                        SendTo = externalFetchVirtualCardResponse.Data.SendTo,
                        State = externalFetchVirtualCardResponse.Data.State,
                        ZipCode = externalFetchVirtualCardResponse.Data.ZipCode


                    },
                    Status = externalFetchVirtualCardResponse.Status,


                }

            };
        }
        private FetchVirtualCards ConvertToVirtualCardResponse(ExternalFetchVirtualCardsResponse externalFetchVirtualCardsResponse)
        {
            return new FetchVirtualCards
            {
                Response = new FetchVirtualCardsResponse
                {
                    Message = externalFetchVirtualCardsResponse.Message,
                    Data = externalFetchVirtualCardsResponse.Data.Select(data =>
                    {
                        return new FetchVirtualCardsResponse.Datum
                        {
                            AccountId = data.AccountId,
                            Amount = data.Amount,
                            Address1 = data.Address1,
                            Address2 = data.Address2,
                            BinCheckName = data.BinCheckName,
                            CallbackUrl = data.CallbackUrl,
                            CardHash = data.CardHash,
                            CardPan = data.CardPan,
                            CardType = data.CardType,
                            City = data.City,
                            CreatedAt = data.CreatedAt,
                            Currency = data.Currency,
                            Cvv = data.Cvv,
                            Expiration = data.Expiration,
                            Id = data.Id,
                            IsActive = data.IsActive,
                            MaskedPan = data.MaskedPan,
                            NameOnCard = data.NameOnCard,
                            SendTo = data.SendTo,
                            State = data.State,
                            ZipCode = data.ZipCode
                        };


                    }).ToList(),
                    Status = externalFetchVirtualCardsResponse.Status,


                }

            };
        }
        private VirtualCardTransactions ConvertToVirtualCardResponse(ExternalVirtualCardTransactionsResponse externalVirtualCardTransactionsResponse)
        {
            return new VirtualCardTransactions
            {
                Response = new VirtualCardTransactionsResponse
                {
                    Message = externalVirtualCardTransactionsResponse.Message,
                    Data = externalVirtualCardTransactionsResponse.Data,
                    Status = externalVirtualCardTransactionsResponse.Status,


                }

            };
        }
        private BlockUnblockVirtualCard ConvertToVirtualCardResponse(ExternalBlockUnblockVirtualCardResponse externalBlockUnblockVirtualCardResponse)
        {
            return new BlockUnblockVirtualCard
            {
                Response = new BlockUnblockVirtualCardResponse
                {
                    Message = externalBlockUnblockVirtualCardResponse.Message,
                    Data = externalBlockUnblockVirtualCardResponse.Data,
                    Status = externalBlockUnblockVirtualCardResponse.Status,


                }

            };
        }
        private TerminateVirtualCard ConvertToVirtualCardResponse(ExternalTerminateVirtualCardResponse externalTerminateVirtualCardResponse)
        {
            return new TerminateVirtualCard
            {
                Response = new TerminateVirtualCardResponse
                {
                    Message = externalTerminateVirtualCardResponse.Message,
                    Data = externalTerminateVirtualCardResponse.Data,
                    Status = externalTerminateVirtualCardResponse.Status,


                }

            };
        }

        private ExternalCreateVirtualCardRequest ConvertToVirtualCardRequest(CreateVirtualCard createVirtualCard)
        {
            return new ExternalCreateVirtualCardRequest
            {
                Amount = createVirtualCard.Request.Amount,
                Currency = createVirtualCard.Request.Currency,
                Email = createVirtualCard.Request.Email,
                BillingAddress = createVirtualCard.Request.BillingAddress,
                BillingCity = createVirtualCard.Request.BillingCity,
                BillingCountry = createVirtualCard.Request.BillingCountry,
                BillingName = createVirtualCard.Request.BillingName,
                BillingPostalCode = createVirtualCard.Request.BillingPostalCode,
                BillingState = createVirtualCard.Request.BillingState,
                CallbackUrl = createVirtualCard.Request.CallbackUrl,
                DateOfBirth = createVirtualCard.Request.DateOfBirth,
                DebitCurrency = createVirtualCard.Request.DebitCurrency,
                FirstName = createVirtualCard.Request.FirstName,
                Gender = createVirtualCard.Request.Gender,
                LastName = createVirtualCard.Request.LastName,
                Phone = createVirtualCard.Request.Phone,
                Title = createVirtualCard.Request.Title,



            };
        }
        private CreateVirtualCard ConvertToVirtualCardResponse(CreateVirtualCard createVirtualCard, ExternalCreateVirtualCardResponse externalCreateVirtualCardResponse)
        {

            createVirtualCard.Response = new CreateVirtualCardResponse
            {
                Message = externalCreateVirtualCardResponse.Message,
                Data = new CreateVirtualCardResponse.CreateVirtualCardData
                {
                    AccountId = externalCreateVirtualCardResponse.Data.AccountId,
                    Amount = externalCreateVirtualCardResponse.Data.Amount,
                    Address1 = externalCreateVirtualCardResponse.Data.Address1,
                    Address2 = externalCreateVirtualCardResponse.Data.Address2,
                    BinCheckName = externalCreateVirtualCardResponse.Data.BinCheckName,
                    CallbackUrl = externalCreateVirtualCardResponse.Data.CallbackUrl,
                    ZipCode = externalCreateVirtualCardResponse.Data.ZipCode,
                    CardPan = externalCreateVirtualCardResponse.Data.CardPan,
                    CardType = externalCreateVirtualCardResponse.Data.CardType,
                    City = externalCreateVirtualCardResponse.Data.City,
                    CreatedAt = externalCreateVirtualCardResponse.Data.CreatedAt,
                    Currency = externalCreateVirtualCardResponse.Data.Currency,
                    Cvv = externalCreateVirtualCardResponse.Data.Cvv,
                    Expiration = externalCreateVirtualCardResponse.Data.Expiration,
                    Id = externalCreateVirtualCardResponse.Data.Id,
                    IsActive = externalCreateVirtualCardResponse.Data.IsActive,
                    MaskedPan = externalCreateVirtualCardResponse.Data.MaskedPan,
                    NameOnCard = externalCreateVirtualCardResponse.Data.NameOnCard,
                    SendTo = externalCreateVirtualCardResponse.Data.SendTo,
                    State = externalCreateVirtualCardResponse.Data.State


                },

                Status = externalCreateVirtualCardResponse.Status,


            };
            return createVirtualCard;

        }

        private ExternalFundVirtualCardRequest ConvertToVirtualCardRequest(FundVirtualCard fundVirtualCard)
        {
            return new ExternalFundVirtualCardRequest
            {
                Amount = fundVirtualCard.Request.Amount,
                DebitCurrency = fundVirtualCard.Request.DebitCurrency



            };
        }
        private FundVirtualCard ConvertToVirtualCardResponse(FundVirtualCard fundVirtualCard, ExternalFundVirtualCardResponse externalFundVirtualCardResponse)
        {

            fundVirtualCard.Response = new FundVirtualCardResponse
            {
                Message = externalFundVirtualCardResponse.Message,
                Data = externalFundVirtualCardResponse.Data,
                Status = externalFundVirtualCardResponse.Status,


            };
            return fundVirtualCard;

        }

        private ExternalVirtualCardWithdrawalRequest ConvertToVirtualCardRequest(VirtualCardWithdrawal virtualCardWithdrawal)
        {
            return new ExternalVirtualCardWithdrawalRequest
            {
                Amount = virtualCardWithdrawal.Request.Amount,

            };
        }
        private VirtualCardWithdrawal ConvertToVirtualCardResponse(VirtualCardWithdrawal virtualCardWithdrawal, ExternalVirtualCardWithdrawalResponse externalVirtualCardWithdrawalResponse)
        {

            virtualCardWithdrawal.Response = new VirtualCardWithdrawalResponse
            {
                Message = externalVirtualCardWithdrawalResponse.Message,
                Data = externalVirtualCardWithdrawalResponse.Data,
                Status = externalVirtualCardWithdrawalResponse.Status,


            };
            return virtualCardWithdrawal;

        }





        private static ExternalVirtualCardWithdrawalResponse CreateRandomExternalVirtualCardWithdrawalResponseResult() =>
         CreateExternalVirtualCardWithdrawalResponseFiller().Create();
        private static ExternalFundVirtualCardResponse CreateRandomExternalFundVirtualCardResponseResult() =>
         CreateExternalFundVirtualCardResponseFiller().Create();
        private static ExternalCreateVirtualCardResponse CreateRandomExternalCreateVirtualCardResponseResult() =>
         CreateExternalCreateVirtualCardResponseFiller().Create();
        private static ExternalFetchVirtualCardResponse CreateRandomExternalFetchVirtualCardResponseResult() =>
         CreateExternalFetchVirtualCardResponseFiller().Create();
        private static ExternalFetchVirtualCardsResponse CreateRandomExternalFetchVirtualCardsResponseResult() =>
          CreateExternalFetchVirtualCardsResponseFiller().Create();
        private static ExternalVirtualCardTransactionsResponse CreateRandomExternalVirtualCardTransactionsResponseResult() =>
            CreateExternalVirtualCardTransactionsResponseFiller().Create();
        private static ExternalBlockUnblockVirtualCardResponse CreateRandomExternalBlockUnblockVirtualCardResponseResult() =>
         CreateExternalBlockUnblockVirtualCardResponseFiller().Create();
        private static ExternalTerminateVirtualCardResponse CreateRandomExternalTerminateVirtualCardResponseResult() =>
            CreateExternalTerminateVirtualCardResponseFiller().Create();



        private static VirtualCardWithdrawal CreateRandomVirtualCardWithdrawalResult() =>
                 CreateVirtualCardWithdrawalFiller().Create();
        private static FundVirtualCard CreateRandomFundVirtualCardResult() =>
         CreateFundVirtualCardFiller().Create();
        private static CreateVirtualCard CreateRandomCreateVirtualCardResult() =>
            CreateCreateVirtualCardFiller().Create();



        private static Filler<ExternalVirtualCardWithdrawalResponse> CreateExternalVirtualCardWithdrawalResponseFiller()
        {
            var filler = new Filler<ExternalVirtualCardWithdrawalResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFundVirtualCardResponse> CreateExternalFundVirtualCardResponseFiller()
        {
            var filler = new Filler<ExternalFundVirtualCardResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCreateVirtualCardResponse> CreateExternalCreateVirtualCardResponseFiller()
        {
            var filler = new Filler<ExternalCreateVirtualCardResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchVirtualCardResponse> CreateExternalFetchVirtualCardResponseFiller()
        {
            var filler = new Filler<ExternalFetchVirtualCardResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchVirtualCardsResponse> CreateExternalFetchVirtualCardsResponseFiller()
        {
            var filler = new Filler<ExternalFetchVirtualCardsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalVirtualCardTransactionsResponse> CreateExternalVirtualCardTransactionsResponseFiller()
        {
            var filler = new Filler<ExternalVirtualCardTransactionsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBlockUnblockVirtualCardResponse> CreateExternalBlockUnblockVirtualCardResponseFiller()
        {
            var filler = new Filler<ExternalBlockUnblockVirtualCardResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalTerminateVirtualCardResponse> CreateExternalTerminateVirtualCardResponseFiller()
        {
            var filler = new Filler<ExternalTerminateVirtualCardResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }




        private static Filler<VirtualCardWithdrawal> CreateVirtualCardWithdrawalFiller()
        {
            var filler = new Filler<VirtualCardWithdrawal>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<FundVirtualCard> CreateFundVirtualCardFiller()
        {
            var filler = new Filler<FundVirtualCard>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreateVirtualCard> CreateCreateVirtualCardFiller()
        {
            var filler = new Filler<CreateVirtualCard>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}

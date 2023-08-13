



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TokenizedChargeClient
{
    public partial class TokenizedChargeClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public TokenizedChargeClientTests()
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

        private BulkTokenizedStatus ConvertToTokenizedChargeResponse(ExternalBulkTokenizedStatusResponse externalBulkTokenizedStatusResponse)
        {
            return new BulkTokenizedStatus
            {
                Response = new BulkTokenizedStatusResponse
                {
                    Message = externalBulkTokenizedStatusResponse.Message,
                    Data = new BulkTokenizedStatusResponse.BulkTokenizedStatusData
                    {
                        Approver = externalBulkTokenizedStatusResponse.Data.Approver,
                        Id = externalBulkTokenizedStatusResponse.Data.Id,
                        PendingCharges = externalBulkTokenizedStatusResponse.Data.PendingCharges,
                        ProcessedCharges = externalBulkTokenizedStatusResponse.Data.ProcessedCharges,
                        Title = externalBulkTokenizedStatusResponse.Data.Title,
                        TotalCharges = externalBulkTokenizedStatusResponse.Data.TotalCharges
                    },


                    Status = externalBulkTokenizedStatusResponse.Status,


                }

            };
        }
        private FetchBulkTokenizedCharge ConvertToTokenizedChargeResponse(ExternalFetchBulkTokenizedChargeResponse externalFetchBulkTokenizedChargeResponse)
        {
            return new FetchBulkTokenizedCharge
            {
                Response = new FetchBulkTokenizedChargeResponse
                {
                    Message = externalFetchBulkTokenizedChargeResponse.Message,
                    Data = externalFetchBulkTokenizedChargeResponse.Data.Select(data =>
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
                                Type = data.Card.Type,
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
                                PhoneNumber = data.Customer.PhoneNumber
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



                    Status = externalFetchBulkTokenizedChargeResponse.Status,


                }

            };
        }

        private ExternalCreateBulkTokenizedChargeRequest ConvertToTokenizedChargeRequest(CreateBulkTokenizedCharge createBulkTokenizedCharge)
        {
            return new ExternalCreateBulkTokenizedChargeRequest
            {

                Title = createBulkTokenizedCharge.Request.Title,
                BulkData = createBulkTokenizedCharge.Request.BulkData.Select(data =>
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
                    RetryAmountVariable = createBulkTokenizedCharge.Request.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createBulkTokenizedCharge.Request.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createBulkTokenizedCharge.Request.RetryStrategy.RetryInterval
                }


            };
        }
        private CreateBulkTokenizedCharge ConvertToTokenizedChargeResponse(CreateBulkTokenizedCharge createBulkTokenizedCharge, ExternalCreateBulkTokenizedChargeResponse externalCreateBulkTokenizedChargeResponse)
        {

            createBulkTokenizedCharge.Response = new CreateBulkTokenizedChargeResponse
            {
                Message = externalCreateBulkTokenizedChargeResponse.Message,
                Data = new CreateBulkTokenizedChargeResponse.CreateBulkTokenizedChargeData
                {
                    Approver = externalCreateBulkTokenizedChargeResponse.Data.Approver,
                    CreatedAt = externalCreateBulkTokenizedChargeResponse.Data.CreatedAt,
                    Id = externalCreateBulkTokenizedChargeResponse.Data.Id,


                },

                Status = externalCreateBulkTokenizedChargeResponse.Status,


            };
            return createBulkTokenizedCharge;

        }

        private ExternalCreateTokenizedChargeRequest ConvertToTokenizedChargeRequest(CreateTokenizedCharge createTokenizedCharge)
        {
            return new ExternalCreateTokenizedChargeRequest
            {
                Amount = createTokenizedCharge.Request.Amount,
                Country = createTokenizedCharge.Request.Country,
                Currency = createTokenizedCharge.Request.Currency,
                Email = createTokenizedCharge.Request.Email,
                FirstName = createTokenizedCharge.Request.FirstName,
                Ip = createTokenizedCharge.Request.Ip,
                LastName = createTokenizedCharge.Request.LastName,
                Narration = createTokenizedCharge.Request.Narration,
                Token = createTokenizedCharge.Request.Token,
                TxRef = createTokenizedCharge.Request.TxRef,



            };
        }
        private CreateTokenizedCharge ConvertToTokenizedChargeResponse(
            CreateTokenizedCharge createTokenizedCharge,
            ExternalCreateTokenizedChargeResponse externalCreateTokenizedChargeResponse)
        {

            createTokenizedCharge.Response = new CreateTokenizedChargeResponse
            {
                Message = externalCreateTokenizedChargeResponse.Message,
                Data = new CreateTokenizedChargeResponse.CreateTokenizedChargeData
                {
                    TxRef = externalCreateTokenizedChargeResponse.Data.TxRef,
                    Currency = externalCreateTokenizedChargeResponse.Data.Currency,
                    AccountId = externalCreateTokenizedChargeResponse.Data.AccountId,
                    Amount = externalCreateTokenizedChargeResponse.Data.Amount,
                    Narration = externalCreateTokenizedChargeResponse.Data.Narration,
                    Ip = externalCreateTokenizedChargeResponse.Data.Ip,
                    AppFee = externalCreateTokenizedChargeResponse.Data.AppFee,
                    AuthModel = externalCreateTokenizedChargeResponse.Data.AuthModel,
                    ChargedAmount = externalCreateTokenizedChargeResponse.Data.ChargedAmount,
                    CreatedAt = externalCreateTokenizedChargeResponse.Data.CreatedAt,
                    DeviceFingerprint = externalCreateTokenizedChargeResponse.Data.DeviceFingerprint,
                    FlwRef = externalCreateTokenizedChargeResponse.Data.FlwRef,
                    Id = externalCreateTokenizedChargeResponse.Data.Id,
                    MerchantFee = externalCreateTokenizedChargeResponse.Data.MerchantFee,
                    PaymentType = externalCreateTokenizedChargeResponse.Data.PaymentType,
                    ProcessorResponse = externalCreateTokenizedChargeResponse.Data.ProcessorResponse,
                    RedirectUrl = externalCreateTokenizedChargeResponse.Data.RedirectUrl,
                    Status = externalCreateTokenizedChargeResponse.Data.Status,
                    Customer = new CreateTokenizedChargeResponse.Customer
                    {
                        Id = externalCreateTokenizedChargeResponse.Data.Customer.Id,
                        CreatedAt = externalCreateTokenizedChargeResponse.Data.Customer.CreatedAt,
                        Email = externalCreateTokenizedChargeResponse.Data.Customer.Email,
                        Name = externalCreateTokenizedChargeResponse.Data.Customer.Name,
                        PhoneNumber = externalCreateTokenizedChargeResponse.Data.Customer.PhoneNumber
                    },
                    Card = new CreateTokenizedChargeResponse.Card
                    {
                        Country = externalCreateTokenizedChargeResponse.Data.Card.Country,
                        Expiry = externalCreateTokenizedChargeResponse.Data.Card.Expiry,
                        First6digits = externalCreateTokenizedChargeResponse.Data.Card.First6digits,
                        Issuer = externalCreateTokenizedChargeResponse.Data.Card.Issuer,
                        Last4digits = externalCreateTokenizedChargeResponse.Data.Card.Last4digits,
                        Token = externalCreateTokenizedChargeResponse.Data.Card.Token,
                        Type = externalCreateTokenizedChargeResponse.Data.Card.Type
                    }





                },
                Status = externalCreateTokenizedChargeResponse.Status,


            };
            return createTokenizedCharge;

        }

        private ExternalUpdateCardTokenRequest ConvertToTokenizedChargeRequest(UpdateCardToken updateCardToken)
        {
            return new ExternalUpdateCardTokenRequest
            {
                Email = updateCardToken.Request.Email,
                FullName = updateCardToken.Request.FullName,
                PhoneNumber = updateCardToken.Request.PhoneNumber,

            };
        }
        private UpdateCardToken ConvertToTokenizedChargeResponse(UpdateCardToken updateCardToken, ExternalUpdateCardTokenResponse externalUpdateCardTokenResponse)
        {

            updateCardToken.Response = new UpdateCardTokenResponse
            {
                Message = externalUpdateCardTokenResponse.Message,
                Data = new UpdateCardTokenResponse.UpdateCardTokenData
                {
                    CreatedAt = externalUpdateCardTokenResponse.Data.CreatedAt,
                    CustomerEmail = externalUpdateCardTokenResponse.Data.CustomerEmail,
                    CustomerFullName = externalUpdateCardTokenResponse.Data.CustomerFullName,
                    CustomerPhoneNumber = externalUpdateCardTokenResponse.Data.CustomerPhoneNumber
                },
                Status = externalUpdateCardTokenResponse.Status,


            };
            return updateCardToken;

        }






        private static ExternalCreateBulkTokenizedChargeResponse CreateRandomExternalCreateBulkTokenizedChargeResponseResult() =>
         CreateExternalCreateBulkTokenizedChargeResponseFiller().Create();
        private static ExternalUpdateCardTokenResponse CreateRandomExternalUpdateCardTokenResponseResult() =>
         CreateExternalUpdateCardTokenResponseFiller().Create();
        private static ExternalCreateTokenizedChargeResponse CreateRandomExternalCreateTokenizedChargeResponseResult() =>
         CreateExternalCreateTokenizedChargeResponseFiller().Create();
        private static ExternalFetchBulkTokenizedChargeResponse CreateRandomExternalFetchBulkTokenizedChargeResponseResult() =>
         CreateExternalFetchBulkTokenizedChargeResponseFiller().Create();
        private static ExternalBulkTokenizedStatusResponse CreateRandomExternalBulkTokenizedStatusResponseResult() =>
          CreateExternalBulkTokenizedStatusResponseFiller().Create();




        private static CreateBulkTokenizedCharge CreateRandomCreateBulkTokenizedChargeResult() =>
                 CreateCreateBulkTokenizedChargeFiller().Create();
        private static UpdateCardToken CreateRandomUpdateCardTokenResult() =>
         CreateUpdateCardTokenFiller().Create();
        private static CreateTokenizedCharge CreateRandomCreateTokenizedChargeResult() =>
         CreateCreateTokenizedChargeFiller().Create();




        private static Filler<ExternalCreateBulkTokenizedChargeResponse> CreateExternalCreateBulkTokenizedChargeResponseFiller()
        {
            var filler = new Filler<ExternalCreateBulkTokenizedChargeResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalUpdateCardTokenResponse> CreateExternalUpdateCardTokenResponseFiller()
        {
            var filler = new Filler<ExternalUpdateCardTokenResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCreateTokenizedChargeResponse> CreateExternalCreateTokenizedChargeResponseFiller()
        {
            var filler = new Filler<ExternalCreateTokenizedChargeResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchBulkTokenizedChargeResponse> CreateExternalFetchBulkTokenizedChargeResponseFiller()
        {
            var filler = new Filler<ExternalFetchBulkTokenizedChargeResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBulkTokenizedStatusResponse> CreateExternalBulkTokenizedStatusResponseFiller()
        {
            var filler = new Filler<ExternalBulkTokenizedStatusResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }




        private static Filler<CreateBulkTokenizedCharge> CreateCreateBulkTokenizedChargeFiller()
        {
            var filler = new Filler<CreateBulkTokenizedCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<UpdateCardToken> CreateUpdateCardTokenFiller()
        {
            var filler = new Filler<UpdateCardToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreateTokenizedCharge> CreateCreateTokenizedChargeFiller()
        {
            var filler = new Filler<CreateTokenizedCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        public void Dispose() => this.wireMockServer.Stop();
    }
}

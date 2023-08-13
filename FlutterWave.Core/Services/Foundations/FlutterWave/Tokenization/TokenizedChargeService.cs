using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using System.Linq;
using System.Threading.Tasks;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService
{
    internal partial class TokenizedChargeService : ITokenizedChargeService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public TokenizedChargeService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<CreateTokenizedCharge> PostCreateTokenizedChargeRequestAsync(CreateTokenizedCharge createTokenizedCharge) =>
           TryCatch(async () =>
           {
               ValidateCreateTokenizedCharge(createTokenizedCharge);
               ExternalCreateTokenizedChargeRequest externalCreateTokenizedChargeRequest = ConvertToTokenizedChargeRequest(createTokenizedCharge);
               ExternalCreateTokenizedChargeResponse externalCreateTokenizedChargeResponse = await flutterWaveBroker.PostCreateTokenizedChargeAsync(
                  externalCreateTokenizedChargeRequest);
               return ConvertToTokenizedChargeResponse(createTokenizedCharge, externalCreateTokenizedChargeResponse);
           });

        public ValueTask<CreateBulkTokenizedCharge> PostCreateBulkTokenizedChargeRequestAsync(CreateBulkTokenizedCharge createBulkTokenizedCharge) =>
           TryCatch(async () =>
           {
               ValidateCreateBulkTokenizedCharge(createBulkTokenizedCharge);
               ExternalCreateBulkTokenizedChargeRequest externalCreateBulkTokenizedChargeRequest = ConvertToTokenizedChargeRequest(createBulkTokenizedCharge);
               ExternalCreateBulkTokenizedChargeResponse externalCreateBulkTokenizedChargeResponse = await flutterWaveBroker.PostCreateBulkTokenizedChargeAsync(
                  externalCreateBulkTokenizedChargeRequest);
               return ConvertToTokenizedChargeResponse(createBulkTokenizedCharge, externalCreateBulkTokenizedChargeResponse);
           });

        public ValueTask<FetchBulkTokenizedCharge> GetBulkTokenizedChargesRequestAsync(int bulkId) =>
           TryCatch(async () =>
           {
               ValidateFetchBulkTokenizedChargeId(bulkId);
               ExternalFetchBulkTokenizedChargeResponse externalFetchBulkTokenizedChargeResponse = await flutterWaveBroker.GetBulkTokenizedChargesAsync(
                  bulkId);
               return ConvertToTokenizedChargeResponse(externalFetchBulkTokenizedChargeResponse);
           });

        public ValueTask<BulkTokenizedStatus> GetBulkTokenizedStatusRequestAsync(int bulkId) =>
           TryCatch(async () =>
           {
               ValidateBulkTokenizedStatusId(bulkId);
               ExternalBulkTokenizedStatusResponse externalBulkTokenizedStatusResponse = await flutterWaveBroker.GetBulkTokenizedStatusAsync(
                  bulkId);
               return ConvertToTokenizedChargeResponse(externalBulkTokenizedStatusResponse);
           });

        public ValueTask<UpdateCardToken> PostUpdateCardTokenRequestAsync(string token, UpdateCardToken updateCardToken) =>
           TryCatch(async () =>
           {
               ValidateUpdateCardToken(updateCardToken);
               ValidateUpdateCardTokenId(token);
               ExternalUpdateCardTokenRequest externalUpdateCardTokenRequest = ConvertToTokenizedChargeRequest(updateCardToken);
               ExternalUpdateCardTokenResponse externalUpdateCardTokenResponse = await flutterWaveBroker.PostUpdateCardTokenAsync(
                  token, externalUpdateCardTokenRequest);
               return ConvertToTokenizedChargeResponse(updateCardToken, externalUpdateCardTokenResponse);
           });



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


    }



}

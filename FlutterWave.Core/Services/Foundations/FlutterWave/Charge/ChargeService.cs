using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static PayloadEncryptor;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService
{
    internal partial class ChargeService : IChargeService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ChargeService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<BankTransfer> PostChargeBankTransferRequestAsync(BankTransfer bankTransfer) =>
        TryCatch(async () =>
        {
            ValidateBankTransfer(bankTransfer);
            ExternalBankTransferRequest externalBankTransferRequest = ConvertToChargeRequest(bankTransfer);
            ExternalBankTransferResponse externalBankTransferResponse = await flutterWaveBroker.PostChargeBankTransferAsync(
               externalBankTransferRequest);
            return ConvertToChargeResponse(bankTransfer, externalBankTransferResponse);
        });

        public ValueTask<ValidateCharge> PostValidateChargeRequestAsync(ValidateCharge validateCharge) =>
        TryCatch(async () =>
        {
            ValidateCharge(validateCharge);
            ExternalValidateChargeRequest externalValidateChargeRequest = ConvertToChargeRequest(validateCharge);
            ExternalValidateChargeResponse externalValidateChargeResponse = await flutterWaveBroker.PostValidateChargeAsync(
               externalValidateChargeRequest);
            return ConvertToChargeResponse(validateCharge, externalValidateChargeResponse);
        });

        public ValueTask<CardCharge> PostChargeCardRequestAsync(CardCharge cardCharge, string encryptionKey) =>
        TryCatch(async () =>
        {
            ValidateCardCharge(cardCharge);
            ExternalCardChargeRequest externalCardChargeRequest = ConvertToChargeRequest(cardCharge);
            var encryptRequested = JsonConvert.SerializeObject(externalCardChargeRequest);
            var encrypted = Encrypt(encryptionKey, encryptRequested);
            ExternalEncryptedChargeRequest externalEncryptedKey = ConvertToEncryptedRequest(encrypted);
            ExternalCardChargeResponse externalCardChargeResponse = await flutterWaveBroker.PostChargeCardAsync(
               externalEncryptedKey);
            return ConvertToChargeResponse(cardCharge, externalCardChargeResponse);
        });

        public ValueTask<NGBankAccounts> PostChargeNGBankAccountRequestAsync(NGBankAccounts nGBankAccounts) =>
        TryCatch(async () =>
        {
            ValidateNGBankAccount(nGBankAccounts);
            ExternalNGBankAccountsRequest externalNGBankAccountsRequest = ConvertToChargeRequest(nGBankAccounts);
            ExternalNGBankAccountsResponse externalNGBankAccountsResponse = await flutterWaveBroker.PostChargeNGBankAccountAsync(
               externalNGBankAccountsRequest);
            return ConvertToChargeResponse(nGBankAccounts, externalNGBankAccountsResponse);
        });

        public ValueTask<Mpesa> PostChargeMpesaRequestAsync(Mpesa mpesa) =>
        TryCatch(async () =>
        {
            ValidateMpesa(mpesa);
            ExternalMpesaRequest externalMpesaRequest = ConvertToChargeRequest(mpesa);
            ExternalMpesaResponse externalMpesaResponse = await flutterWaveBroker.PostChargeMpesaAsync(
               externalMpesaRequest);
            return ConvertToChargeResponse(mpesa, externalMpesaResponse);
        });

        public ValueTask<GhanaMobileMoney> PostChargeGhanaMobileMoneyRequestAsync(GhanaMobileMoney ghanaMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateGhanaMobileMoney(ghanaMobileMoney);
            ExternalGhanaMobileMoneyRequest externalGhanaMobileMoneyRequest = ConvertToChargeRequest(ghanaMobileMoney);
            ExternalGhanaMobileMoneyResponse externalGhanaMobileMoneyResponse = await flutterWaveBroker.PostChargeGhanaMobileMoneyAsync(
               externalGhanaMobileMoneyRequest);
            return ConvertToChargeResponse(ghanaMobileMoney, externalGhanaMobileMoneyResponse);
        });

        public ValueTask<UgandaMobileMoney> PostChargeUgandaMobileMoneyRequestAsync(UgandaMobileMoney ugandaMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateUgandaMobileMoney(ugandaMobileMoney);
            ExternalUgandaMobileMoneyRequest externalUgandaMobileMoneyRequest = ConvertToChargeRequest(ugandaMobileMoney);
            ExternalUgandaMobileMoneyResponse externalUgandaMobileMoneyResponse = await flutterWaveBroker.PostChargeUgandaMobileMoneyAsync(
               externalUgandaMobileMoneyRequest);
            return ConvertToChargeResponse(ugandaMobileMoney, externalUgandaMobileMoneyResponse);
        });

        public ValueTask<FrancophoneMobileMoney> PostChargeFrancophoneMobileMoneyRequestAsync(FrancophoneMobileMoney francophoneMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateFrancophoneMobileMoney(francophoneMobileMoney);
            ExternalFrancophoneMobileMoneyRequest externalFrancophoneMobileMoneyRequest = ConvertToChargeRequest(francophoneMobileMoney);
            ExternalFrancophoneMobileMoneyResponse externalFrancophoneMobileMoneyResponse = await flutterWaveBroker.PostChargeFrancophoneMobileMoneyAsync(
               externalFrancophoneMobileMoneyRequest);
            return ConvertToChargeResponse(francophoneMobileMoney, externalFrancophoneMobileMoneyResponse);
        });

        public ValueTask<TanzaniaMobileMoney> PostChargeTanzaniaMobileMoneyRequestAsync(TanzaniaMobileMoney tanzaniaMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateTanzaniaMobileMoney(tanzaniaMobileMoney);
            ExternalTanzaniaMobileMoneyRequest externalTanzaniaMobileMoneyRequest = ConvertToChargeRequest(tanzaniaMobileMoney);
            ExternalTanzaniaMobileMoneyResponse externalTanzaniaMobileMoneyResponse = await flutterWaveBroker.PostChargeTanzaniaMobileMoneyAsync(
               externalTanzaniaMobileMoneyRequest);
            return ConvertToChargeResponse(tanzaniaMobileMoney, externalTanzaniaMobileMoneyResponse);
        });

        public ValueTask<RwandaMobileMoney> PostChargeRwandaMobileMoneyRequestAsync(RwandaMobileMoney rwandaMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateRwandaMobileMoney(rwandaMobileMoney);
            ExternalRwandaMobileMoneyRequest externalRwandaMobileMoneyRequest = ConvertToChargeRequest(rwandaMobileMoney);
            ExternalRwandaMobileMoneyResponse externalRwandaMobileMoneyResponse = await flutterWaveBroker.PostChargeRwandaMobileMoneyAsync(
               externalRwandaMobileMoneyRequest);
            return ConvertToChargeResponse(rwandaMobileMoney, externalRwandaMobileMoneyResponse);
        });

        public ValueTask<ZambiaMobileMoney> PostChargeZambiaMobileMoneyRequestAsync(ZambiaMobileMoney zambiaMobileMoney) =>
        TryCatch(async () =>
        {
            ValidateZambiaMobileMoney(zambiaMobileMoney);
            ExternalZambiaMobileMoneyRequest externalZambiaMobileMoneyRequest = ConvertToChargeRequest(zambiaMobileMoney);
            ExternalZambiaMobileMoneyResponse externalZambiaMobileMoneyResponse = await flutterWaveBroker.PostChargeZambiaMobileMoneyAsync(
               externalZambiaMobileMoneyRequest);
            return ConvertToChargeResponse(zambiaMobileMoney, externalZambiaMobileMoneyResponse);
        });

        public ValueTask<USSD> PostChargeUSSDRequestAsync(USSD uSSD) =>
        TryCatch(async () =>
        {
            ValidateUSSD(uSSD);
            ExternalUSSDRequest externalUSSDRequest = ConvertToChargeRequest(uSSD);
            ExternalUSSDResponse externalUSSDResponse = await flutterWaveBroker.PostChargeUSSDAsync(
               externalUSSDRequest);
            return ConvertToChargeResponse(uSSD, externalUSSDResponse);
        });

        public ValueTask<UkEuBankAccounts> PostChargeUkEuBankAccountsRequestAsync(UkEuBankAccounts ukEuBankAccounts) =>
        TryCatch(async () =>
        {
            ValidateUkEuBankAccounts(ukEuBankAccounts);
            ExternalUkEuBankAccountsRequest externalUkEuBankAccountsRequest = ConvertToChargeRequest(ukEuBankAccounts);
            ExternalUkEuBankAccountsResponse externalUkEuBankAccountsResponse = await flutterWaveBroker.PostChargeUkEuBankAccountsAsync(
               externalUkEuBankAccountsRequest);
            return ConvertToChargeResponse(ukEuBankAccounts, externalUkEuBankAccountsResponse);
        });

        public ValueTask<ACHPayments> PostChargeACHPaymentsRequestAsync(ACHPayments aCHPayments) =>
        TryCatch(async () =>
        {
            ValidateACHPayments(aCHPayments);
            ExternalACHPaymentsRequest externalACHPaymentsRequest = ConvertToChargeRequest(aCHPayments);
            ExternalACHPaymentsResponse externalACHPaymentsResponse = await flutterWaveBroker.PostChargeACHPaymentsAsync(
               externalACHPaymentsRequest);
            return ConvertToChargeResponse(aCHPayments, externalACHPaymentsResponse);
        });

        public ValueTask<ApplePay> PostChargeApplePayRequestAsync(ApplePay applePay) =>
        TryCatch(async () =>
        {
            ValidateApplePay(applePay);
            ExternalApplePayRequest externalApplePayRequest = ConvertToChargeRequest(applePay);
            ExternalApplePayResponse externalApplePayResponse = await flutterWaveBroker.PostChargeApplePayAsync(
               externalApplePayRequest);
            return ConvertToChargeResponse(applePay, externalApplePayResponse);
        });

        public ValueTask<GooglePay> PostChargeGooglePayRequestAsync(GooglePay googlePay) =>
        TryCatch(async () =>
        {
            ValidateGooglePay(googlePay);
            ExternalGooglePayRequest externalGooglePayRequest = ConvertToChargeRequest(googlePay);
            ExternalGooglePayResponse externalGooglePayResponse = await flutterWaveBroker.PostChargeGooglePayAsync(
               externalGooglePayRequest);
            return ConvertToChargeResponse(googlePay, externalGooglePayResponse);
        });

        public ValueTask<ENaira> PostChargeENairaRequestAsync(ENaira eNaira) =>
        TryCatch(async () =>
        {
            ValidateENaira(eNaira);
            ExternalENairaRequest externalENairaRequest = ConvertToChargeRequest(eNaira);
            ExternalENairaResponse externalENairaResponse = await flutterWaveBroker.PostChargeENairaAsync(
               externalENairaRequest);
            return ConvertToChargeResponse(eNaira, externalENairaResponse);
        });

        public ValueTask<Fawry> PostChargeFawryRequestAsync(Fawry fawry) =>
        TryCatch(async () =>
        {
            ValidateFawry(fawry);
            ExternalFawryRequest externalFawryRequest = ConvertToChargeRequest(fawry);
            ExternalFawryResponse externalFawryResponse = await flutterWaveBroker.PostChargeFawryAsync(
               externalFawryRequest);
            return ConvertToChargeResponse(fawry, externalFawryResponse);
        });

        public ValueTask<PayPal> PostChargePayPalRequestAsync(PayPal payPal) =>
        TryCatch(async () =>
        {
            ValidatePayPal(payPal);
            ExternalPayPalRequest externalPayPalRequest = ConvertToChargeRequest(payPal);
            ExternalPayPalResponse externalPayPalResponse = await flutterWaveBroker.PostChargePayPalAsync(
               externalPayPalRequest);
            return ConvertToChargeResponse(payPal, externalPayPalResponse);
        });


        private ExternalBankTransferRequest ConvertToChargeRequest(BankTransfer bankTransfer)
        {
            return new ExternalBankTransferRequest
            {
                Amount = bankTransfer.Request.Amount,
                ClientIp = bankTransfer.Request.ClientIp,
                Currency = bankTransfer.Request.Currency,
                DeviceFingerprint = bankTransfer.Request.DeviceFingerprint,
                Email = bankTransfer.Request.Email,
                IsPermanent = bankTransfer.Request.IsPermanent,
                Narration = bankTransfer.Request.Narration,
                PhoneNumber = bankTransfer.Request.PhoneNumber,
                TxRef = bankTransfer.Request.TxRef,
            };
        }
        private BankTransfer ConvertToChargeResponse(BankTransfer bankTransfer, ExternalBankTransferResponse externalBankTransferResponse)
        {

            bankTransfer.Response = new BankTransferResponse
            {
                Message = externalBankTransferResponse.Message,
                Meta = new BankTransferResponse.BankTransferMeta
                {
                    Authorization = new BankTransferResponse.Authorization
                    {
                        AccountExpiration = externalBankTransferResponse.Meta.Authorization.AccountExpiration,
                        Mode = externalBankTransferResponse.Meta.Authorization.Mode,
                        TransferAccount = externalBankTransferResponse.Meta.Authorization.TransferAccount,
                        TransferAmount = externalBankTransferResponse.Meta.Authorization.TransferAmount,
                        TransferBank = externalBankTransferResponse.Meta.Authorization.TransferBank,
                        TransferNote = externalBankTransferResponse.Meta.Authorization.TransferNote,
                        TransferReference = externalBankTransferResponse.Meta.Authorization.TransferReference
                    },

                },
                Status = externalBankTransferResponse.Status,



            };
            return bankTransfer;
        }
        private ExternalValidateChargeRequest ConvertToChargeRequest(ValidateCharge validateCharge)
        {
            return new ExternalValidateChargeRequest
            {
                FlwRef = validateCharge.Request.FlwRef,
                Otp = validateCharge.Request.Otp,
                Type = validateCharge.Request.Type,
            };
        }

        private ExternalEncryptedChargeRequest ConvertToEncryptedRequest(string encryptedKey)
        {
            return new ExternalEncryptedChargeRequest
            {
                Client = encryptedKey,

            };
        }
        private ValidateCharge ConvertToChargeResponse(ValidateCharge validateCharge, ExternalValidateChargeResponse externalValidateChargeResponse)
        {

            validateCharge.Response = new ValidateChargeResponse
            {
                Message = externalValidateChargeResponse.Message,
                Data = new ValidateChargeResponse.Datum
                {
                    FlwRef = externalValidateChargeResponse.Data.FlwRef,
                    AccountId = externalValidateChargeResponse.Data.AccountId,
                    Amount = externalValidateChargeResponse.Data.Amount,
                    AppFee = externalValidateChargeResponse.Data.AppFee,
                    AuthModel = externalValidateChargeResponse.Data.AuthModel,
                    AuthUrl = externalValidateChargeResponse.Data.AuthUrl,
                    ChargedAmount = externalValidateChargeResponse.Data.ChargedAmount,
                    ChargeType = externalValidateChargeResponse.Data.ChargeType,
                    CreatedAt = externalValidateChargeResponse.Data.CreatedAt,
                    Currency = externalValidateChargeResponse.Data.Currency,
                    DeviceFingerprint = externalValidateChargeResponse.Data.DeviceFingerprint,
                    FraudStatus = externalValidateChargeResponse.Data.FraudStatus,
                    Id = externalValidateChargeResponse.Data.Id,
                    Ip = externalValidateChargeResponse.Data.Ip,
                    Narration = externalValidateChargeResponse.Data.Narration,
                    MerchantFee = externalValidateChargeResponse.Data.MerchantFee,
                    PaymentType = externalValidateChargeResponse.Data.PaymentType,
                    ProcessorResponse = externalValidateChargeResponse.Data.ProcessorResponse,
                    Status = externalValidateChargeResponse.Data.Status,
                    TxRef = externalValidateChargeResponse.Data.TxRef,
                    Card = new ValidateChargeResponse.Card
                    {
                        Country = externalValidateChargeResponse.Data.Card.Country,
                        Expiry = externalValidateChargeResponse.Data.Card.Expiry,
                        First6digits = externalValidateChargeResponse.Data.Card.First6digits,
                        Issuer = externalValidateChargeResponse.Data.Card.Issuer,
                        Last4digits = externalValidateChargeResponse.Data.Card.Last4digits,
                        Type = externalValidateChargeResponse.Data.Card.Type
                    },
                    Customer = new ValidateChargeResponse.Customer
                    {
                        CreatedAt = externalValidateChargeResponse.Data.Customer.CreatedAt,
                        Email = externalValidateChargeResponse.Data.Customer.Email,
                        Id = externalValidateChargeResponse.Data.Customer.Id,
                        Name = externalValidateChargeResponse.Data.Customer.Name,
                        PhoneNumber = externalValidateChargeResponse.Data.Customer.PhoneNumber
                    }

                },

                Status = externalValidateChargeResponse.Status,



            };
            return validateCharge;
        }
        private ExternalCardChargeRequest ConvertToChargeRequest(CardCharge CardCharge)
        {
            return new ExternalCardChargeRequest
            {
                Amount = CardCharge.Request.Amount,
                CardNumber = CardCharge.Request.CardNumber,
                Currency = CardCharge.Request.Currency,
                Cvv = CardCharge.Request.Cvv,
                Email = CardCharge.Request.Email,
                ExpiryMonth = CardCharge.Request.ExpiryMonth,
                ExpiryYear = CardCharge.Request.ExpiryYear,
                FullName = CardCharge.Request.FullName,
                TxRef = CardCharge.Request.TxRef,
                RedirectUrl = CardCharge.Request.RedirectUrl,
                Authorization = new ExternalCardChargeRequest.ExternalAuthorizationData
                {
                    Address = CardCharge.Request.Authorization.Address,
                    City = CardCharge.Request.Authorization.City,
                    Country = CardCharge.Request.Authorization.Country,
                    Mode = CardCharge.Request.Authorization.Mode,
                    Pin = CardCharge.Request.Authorization.Pin,
                    State = CardCharge.Request.Authorization.State,
                    ZipCode = CardCharge.Request.Authorization.ZipCode
                },
                ClientIp = CardCharge.Request.ClientIp,
                DeviceFingerprint = CardCharge.Request.DeviceFingerprint,
                PaymentPlan = CardCharge.Request.PaymentPlan,
                Preauthorize = CardCharge.Request.Preauthorize,
                Meta = new ExternalCardChargeRequest.ExternalMeta
                {
                    FlightId = CardCharge.Request.Meta.FlightId,
                    SideNote = CardCharge.Request.Meta.SideNote,
                }


            };
        }
        private CardCharge ConvertToChargeResponse(CardCharge cardCharge, ExternalCardChargeResponse externalCardChargeResponse)
        {

            cardCharge.Response = new CardChargeResponse
            {
                Message = externalCardChargeResponse.Message,
                Meta = new CardChargeResponse.CardChargeMeta
                {
                    Authorization = new CardChargeResponse.Authorization
                    {
                        Endpoint = externalCardChargeResponse.Meta.Authorization.Endpoint,
                        Mode = externalCardChargeResponse.Meta.Authorization.Mode
                    }

                },
                Status = externalCardChargeResponse.Status,
                Data = new CardChargeResponse.CardChargeData
                {
                    AccountId = externalCardChargeResponse.Data.AccountId,
                    Amount = externalCardChargeResponse.Data.Amount,
                    AppFee = externalCardChargeResponse.Data.AppFee,
                    AuthModel = externalCardChargeResponse.Data.AuthModel,
                    AuthUrl = externalCardChargeResponse.Data.AuthUrl,
                    ChargedAmount = externalCardChargeResponse.Data.ChargedAmount,
                    ChargeType = externalCardChargeResponse.Data.ChargeType,
                    CreatedAt = externalCardChargeResponse.Data.CreatedAt,
                    Currency = externalCardChargeResponse.Data.Currency,
                    Customer = new CardChargeResponse.Customer
                    {
                        CreatedAt = externalCardChargeResponse.Data.Customer.CreatedAt,
                        Email = externalCardChargeResponse.Data.Customer.Email,
                        Id = externalCardChargeResponse.Data.Customer.Id,
                        Name = externalCardChargeResponse.Data.Customer.Name,
                        PhoneNumber = externalCardChargeResponse.Data.Customer.PhoneNumber
                    },
                    Id = externalCardChargeResponse.Data.Id,
                    DeviceFingerprint = externalCardChargeResponse.Data.DeviceFingerprint,
                    FlwRef = externalCardChargeResponse.Data.FlwRef,
                    FraudStatus = externalCardChargeResponse.Data.FraudStatus,
                    Ip = externalCardChargeResponse.Data.Ip,
                    MerchantFee = externalCardChargeResponse.Data.MerchantFee,
                    Narration = externalCardChargeResponse.Data.Narration,
                    PaymentType = externalCardChargeResponse.Data.PaymentType,
                    ProcessorResponse = externalCardChargeResponse.Data.ProcessorResponse,
                    Status = externalCardChargeResponse.Data.Status,
                    TxRef = externalCardChargeResponse.Data.TxRef,
                    Card = new CardChargeResponse.Card
                    {
                        Country = externalCardChargeResponse.Data.Card.Country,
                        Expiry = externalCardChargeResponse.Data.Card.Expiry,
                        First6digits = externalCardChargeResponse.Data.Card.First6digits,
                        Last4digits = externalCardChargeResponse.Data.Card.Last4digits,
                        Issuer = externalCardChargeResponse.Data.Card.Issuer,
                        Type = externalCardChargeResponse.Data.Card.Type
                    }
                }



            };

            return cardCharge;
        }
        private ExternalNGBankAccountsRequest ConvertToChargeRequest(NGBankAccounts nGBankAccounts)
        {
            return new ExternalNGBankAccountsRequest
            {
                Amount = nGBankAccounts.Request.Amount,
                AccountBank = nGBankAccounts.Request.AccountBank,
                Currency = nGBankAccounts.Request.Currency,
                AccountNumber = nGBankAccounts.Request.AccountNumber,
                Email = nGBankAccounts.Request.Email,
                FullName = nGBankAccounts.Request.FullName,
                PhoneNumber = nGBankAccounts.Request.PhoneNumber,
                TxRef = nGBankAccounts.Request.TxRef,

            };
        }
        private NGBankAccounts ConvertToChargeResponse(NGBankAccounts nGBankAccounts, ExternalNGBankAccountsResponse externalNGBankAccountsResponse)
        {

            nGBankAccounts.Response = new NGBankAccountsResponse
            {
                Message = externalNGBankAccountsResponse.Message,
                Data = new NGBankAccountsResponse.NGBankAccountsData
                {
                    Account = new NGBankAccountsResponse.Account
                    {
                        AccountName = externalNGBankAccountsResponse.Data.Account.AccountName,
                        AccountNumber = externalNGBankAccountsResponse.Data.Account.AccountNumber,
                        BankCode = externalNGBankAccountsResponse.Data.Account.BankCode
                    },
                    AccountId = externalNGBankAccountsResponse.Data.AccountId,
                    Amount = externalNGBankAccountsResponse.Data.Amount,
                    TxRef = externalNGBankAccountsResponse.Data.TxRef,
                    Id = externalNGBankAccountsResponse.Data.Id,
                    AppFee = externalNGBankAccountsResponse.Data.AppFee,
                    AuthModel = externalNGBankAccountsResponse.Data.AuthModel,
                    AuthUrl = externalNGBankAccountsResponse.Data.AuthUrl,
                    ChargedAmount = externalNGBankAccountsResponse.Data.ChargedAmount,
                    CreatedAt = externalNGBankAccountsResponse.Data.CreatedAt,
                    Currency = externalNGBankAccountsResponse.Data.Currency,
                    Customer = new NGBankAccountsResponse.Customer
                    {
                        Email = externalNGBankAccountsResponse.Data.Customer.Email,
                        Id = externalNGBankAccountsResponse.Data.Customer.Id
                    },
                    DeviceFingerprint = externalNGBankAccountsResponse.Data.DeviceFingerprint,
                    FlwRef = externalNGBankAccountsResponse.Data.FlwRef,
                    FraudStatus = externalNGBankAccountsResponse.Data.FraudStatus,
                    Ip = externalNGBankAccountsResponse.Data.Ip,
                    MerchantFee = externalNGBankAccountsResponse.Data.MerchantFee,
                    Meta = new NGBankAccountsResponse.Meta
                    {
                        Authorization = new NGBankAccountsResponse.Authorization
                        {
                            Mode = externalNGBankAccountsResponse.Data.Meta.Authorization.Mode,
                            ValidateInstructions = externalNGBankAccountsResponse.Data.Meta.Authorization.ValidateInstructions
                        }
                    },
                    Narration = externalNGBankAccountsResponse.Data.Narration,
                    PaymentType = externalNGBankAccountsResponse.Data.PaymentType,
                    Status = externalNGBankAccountsResponse.Data.Status



                },
                Status = externalNGBankAccountsResponse.Status,




            };
            return nGBankAccounts;
        }
        private ExternalMpesaRequest ConvertToChargeRequest(Mpesa mpesa)
        {
            return new ExternalMpesaRequest
            {
                Amount = mpesa.Request.Amount,
                Currency = mpesa.Request.Currency,
                Email = mpesa.Request.Email,
                FullName = mpesa.Request.FullName,
                PhoneNumber = mpesa.Request.PhoneNumber,
                TxRef = mpesa.Request.TxRef,


            };
        }
        private Mpesa ConvertToChargeResponse(Mpesa mpesa, ExternalMpesaResponse externalMpesaResponse)
        {

            mpesa.Response = new MpesaResponse
            {
                Message = externalMpesaResponse.Message,
                Data = new MpesaResponse.MpesaData
                {
                    ChargeType = externalMpesaResponse.Data.ChargeType,
                    ProcessorResponse = externalMpesaResponse.Data.ProcessorResponse,
                    AccountId = externalMpesaResponse.Data.AccountId,
                    Amount = externalMpesaResponse.Data.Amount,
                    TxRef = externalMpesaResponse.Data.TxRef,
                    Id = externalMpesaResponse.Data.Id,
                    AppFee = externalMpesaResponse.Data.AppFee,
                    AuthModel = externalMpesaResponse.Data.AuthModel,
                    AuthUrl = externalMpesaResponse.Data.AuthUrl,
                    ChargedAmount = externalMpesaResponse.Data.ChargedAmount,
                    CreatedAt = externalMpesaResponse.Data.CreatedAt,
                    Currency = externalMpesaResponse.Data.Currency,
                    Customer = new MpesaResponse.Customer
                    {
                        Email = externalMpesaResponse.Data.Customer.Email,
                        Id = externalMpesaResponse.Data.Customer.Id,
                        PhoneNumber = externalMpesaResponse.Data.Customer.PhoneNumber,
                        CreatedAt = externalMpesaResponse.Data.Customer.CreatedAt,
                        Name = externalMpesaResponse.Data.Customer.Name


                    },
                    DeviceFingerprint = externalMpesaResponse.Data.DeviceFingerprint,
                    FlwRef = externalMpesaResponse.Data.FlwRef,
                    FraudStatus = externalMpesaResponse.Data.FraudStatus,
                    Ip = externalMpesaResponse.Data.Ip,
                    MerchantFee = externalMpesaResponse.Data.MerchantFee,
                    Narration = externalMpesaResponse.Data.Narration,
                    PaymentType = externalMpesaResponse.Data.PaymentType,
                    Status = externalMpesaResponse.Data.Status,




                },
                Status = externalMpesaResponse.Status,




            };
            return mpesa;
        }
        private ExternalGhanaMobileMoneyRequest ConvertToChargeRequest(GhanaMobileMoney ghanaMobileMoney)
        {
            return new ExternalGhanaMobileMoneyRequest
            {
                Amount = ghanaMobileMoney.Request.Amount,
                Currency = ghanaMobileMoney.Request.Currency,
                Email = ghanaMobileMoney.Request.Email,
                Fullname = ghanaMobileMoney.Request.FullName,
                PhoneNumber = ghanaMobileMoney.Request.PhoneNumber,
                TxRef = ghanaMobileMoney.Request.TxRef,
                Meta = new ExternalGhanaMobileMoneyRequest.ExternalGhanaMobileMoneyMeta
                {
                    FlightID = ghanaMobileMoney.Request.Meta.FlightID
                },
                ClientIp = ghanaMobileMoney.Request.ClientIp,
                DeviceFingerprint = ghanaMobileMoney.Request.DeviceFingerprint,
                Network = ghanaMobileMoney.Request.Network,
                Voucher = ghanaMobileMoney.Request.Voucher

            };
        }
        private GhanaMobileMoney ConvertToChargeResponse(GhanaMobileMoney ghanaMobileMoney, ExternalGhanaMobileMoneyResponse externalGhanaMobileMoneyResponse)
        {

            ghanaMobileMoney.Response = new GhanaMobileMoneyResponse
            {
                Message = externalGhanaMobileMoneyResponse.Message,
                Meta = new GhanaMobileMoneyResponse.GhanaMobileMoneyMeta
                {
                    Authorization = new GhanaMobileMoneyResponse.Authorization
                    {
                        Mode = externalGhanaMobileMoneyResponse.Meta.Authorization.Mode,
                        Redirect = externalGhanaMobileMoneyResponse.Meta.Authorization.Redirect
                    }

                },
                Status = externalGhanaMobileMoneyResponse.Status,


            };
            return ghanaMobileMoney;
        }
        private ExternalUgandaMobileMoneyRequest ConvertToChargeRequest(UgandaMobileMoney ugandaMobileMoney)
        {
            return new ExternalUgandaMobileMoneyRequest
            {
                Amount = ugandaMobileMoney.Request.Amount,
                Currency = ugandaMobileMoney.Request.Currency,
                Email = ugandaMobileMoney.Request.Email,
                Fullname = ugandaMobileMoney.Request.FullName,
                PhoneNumber = ugandaMobileMoney.Request.PhoneNumber,
                TxRef = ugandaMobileMoney.Request.TxRef,
                Meta = new ExternalUgandaMobileMoneyRequest.ExternalUgandaMobileMoneyMeta
                {
                    FlightID = ugandaMobileMoney.Request.Meta.FlightID
                },
                ClientIp = ugandaMobileMoney.Request.ClientIp,
                DeviceFingerprint = ugandaMobileMoney.Request.DeviceFingerprint,
                Network = ugandaMobileMoney.Request.Network,
                Voucher = ugandaMobileMoney.Request.Voucher,


            };
        }
        private UgandaMobileMoney ConvertToChargeResponse(UgandaMobileMoney ugandaMobileMoney, ExternalUgandaMobileMoneyResponse externalUgandaMobileMoneyResponse)
        {

            ugandaMobileMoney.Response = new UgandaMobileMoneyResponse
            {
                Message = externalUgandaMobileMoneyResponse.Message,
                Meta = new UgandaMobileMoneyResponse.UgandaMobileMoneyMeta
                {
                    Authorization = new UgandaMobileMoneyResponse.Authorization
                    {
                        Mode = externalUgandaMobileMoneyResponse.Meta.Authorization.Mode,
                        Redirect = externalUgandaMobileMoneyResponse.Meta.Authorization.Redirect,

                    }

                },

                Status = externalUgandaMobileMoneyResponse.Status,


            };
            return ugandaMobileMoney;
        }
        private ExternalFrancophoneMobileMoneyRequest ConvertToChargeRequest(FrancophoneMobileMoney francophoneMobileMoney)
        {
            return new ExternalFrancophoneMobileMoneyRequest
            {
                Amount = francophoneMobileMoney.Request.Amount,
                Currency = francophoneMobileMoney.Request.Currency,
                Email = francophoneMobileMoney.Request.Email,
                FullName = francophoneMobileMoney.Request.FullName,
                PhoneNumber = francophoneMobileMoney.Request.PhoneNumber,
                TxRef = francophoneMobileMoney.Request.TxRef,
                Country = francophoneMobileMoney.Request.Country,



            };
        }
        private FrancophoneMobileMoney ConvertToChargeResponse(
            FrancophoneMobileMoney francophoneMobileMoney,
            ExternalFrancophoneMobileMoneyResponse externalFrancophoneMobileMoneyResponse)
        {

            francophoneMobileMoney.Response = new FrancophoneMobileMoneyResponse
            {
                Message = externalFrancophoneMobileMoneyResponse.Message,
                Meta = new FrancophoneMobileMoneyResponse.FrancophoneMobileMoneyMeta
                {
                    Authorization = new FrancophoneMobileMoneyResponse.Authorization
                    {
                        Mode = externalFrancophoneMobileMoneyResponse.Meta.Authorization.Mode,
                        RedirectUrl = externalFrancophoneMobileMoneyResponse.Meta.Authorization.RedirectUrl
                    }

                },
                Data = new FrancophoneMobileMoneyResponse.FrancophoneMobileMoneyData
                {
                    AccountId = externalFrancophoneMobileMoneyResponse.Data.AccountId,
                    Amount = externalFrancophoneMobileMoneyResponse.Data.Amount,
                    AppFee = externalFrancophoneMobileMoneyResponse.Data.AppFee,
                    AuthModel = externalFrancophoneMobileMoneyResponse.Data.AuthModel,
                    ChargedAmount = externalFrancophoneMobileMoneyResponse.Data.ChargedAmount,
                    ChargeType = externalFrancophoneMobileMoneyResponse.Data.ChargeType,
                    CreatedAt = externalFrancophoneMobileMoneyResponse.Data.CreatedAt,
                    Currency = externalFrancophoneMobileMoneyResponse.Data.Currency,
                    DeviceFingerprint = externalFrancophoneMobileMoneyResponse.Data.DeviceFingerprint,
                    Id = externalFrancophoneMobileMoneyResponse.Data.Id,
                    FlwRef = externalFrancophoneMobileMoneyResponse.Data.FlwRef,
                    FraudStatus = externalFrancophoneMobileMoneyResponse.Data.FraudStatus,
                    Ip = externalFrancophoneMobileMoneyResponse.Data.Ip,
                    MerchantFee = externalFrancophoneMobileMoneyResponse.Data.MerchantFee,
                    Narration = externalFrancophoneMobileMoneyResponse.Data.Narration,
                    OrderId = externalFrancophoneMobileMoneyResponse.Data.OrderId,
                    PaymentType = externalFrancophoneMobileMoneyResponse.Data.PaymentType,
                    ProcessorResponse = externalFrancophoneMobileMoneyResponse.Data.ProcessorResponse,
                    Status = externalFrancophoneMobileMoneyResponse.Data.Status,
                    TxRef = externalFrancophoneMobileMoneyResponse.Data.TxRef,
                    Customer = new FrancophoneMobileMoneyResponse.Customer
                    {
                        CreatedAt = externalFrancophoneMobileMoneyResponse.Data.Customer.CreatedAt,
                        Email = externalFrancophoneMobileMoneyResponse.Data.Customer.Email,
                        Id = externalFrancophoneMobileMoneyResponse.Data.Customer.Id,
                        Name = externalFrancophoneMobileMoneyResponse.Data.Customer.Name,
                        PhoneNumber = externalFrancophoneMobileMoneyResponse.Data.Customer.PhoneNumber
                    }

                },

                Status = externalFrancophoneMobileMoneyResponse.Status,


            };
            return francophoneMobileMoney;
        }
        private ExternalTanzaniaMobileMoneyRequest ConvertToChargeRequest(TanzaniaMobileMoney tanzaniaMobileMoney)
        {
            return new ExternalTanzaniaMobileMoneyRequest
            {
                Amount = tanzaniaMobileMoney.Request.Amount,
                Currency = tanzaniaMobileMoney.Request.Currency,
                Email = tanzaniaMobileMoney.Request.Email,
                Fullname = tanzaniaMobileMoney.Request.FullName,
                PhoneNumber = tanzaniaMobileMoney.Request.PhoneNumber,
                TxRef = tanzaniaMobileMoney.Request.TxRef,
                Meta = new ExternalTanzaniaMobileMoneyRequest.ExternalTanzaniaMobileMoneyMeta
                {
                    FlightID = tanzaniaMobileMoney.Request.Meta.FlightID
                },
                ClientIp = tanzaniaMobileMoney.Request.ClientIp,
                DeviceFingerprint = tanzaniaMobileMoney.Request.DeviceFingerprint,
                Network = tanzaniaMobileMoney.Request.Network,


            };
        }
        private TanzaniaMobileMoney ConvertToChargeResponse(TanzaniaMobileMoney tanzaniaMobileMoney, ExternalTanzaniaMobileMoneyResponse externalTanzaniaMobileMoneyResponse)
        {

            tanzaniaMobileMoney.Response = new TanzaniaMobileMoneyResponse
            {
                Message = externalTanzaniaMobileMoneyResponse.Message,
                Data = new TanzaniaMobileMoneyResponse.TanzaniaMobileMoneyData
                {
                    AccountId = externalTanzaniaMobileMoneyResponse.Data.AccountId,
                    Amount = externalTanzaniaMobileMoneyResponse.Data.Amount,
                    AppFee = externalTanzaniaMobileMoneyResponse.Data.AppFee,
                    AuthModel = externalTanzaniaMobileMoneyResponse.Data.AuthModel,
                    ChargedAmount = externalTanzaniaMobileMoneyResponse.Data.ChargedAmount,
                    ChargeType = externalTanzaniaMobileMoneyResponse.Data.ChargeType,
                    CreatedAt = externalTanzaniaMobileMoneyResponse.Data.CreatedAt,
                    Currency = externalTanzaniaMobileMoneyResponse.Data.Currency,
                    DeviceFingerprint = externalTanzaniaMobileMoneyResponse.Data.DeviceFingerprint,
                    Id = externalTanzaniaMobileMoneyResponse.Data.Id,
                    FlwRef = externalTanzaniaMobileMoneyResponse.Data.FlwRef,
                    FraudStatus = externalTanzaniaMobileMoneyResponse.Data.FraudStatus,
                    Ip = externalTanzaniaMobileMoneyResponse.Data.Ip,
                    MerchantFee = externalTanzaniaMobileMoneyResponse.Data.MerchantFee,
                    Narration = externalTanzaniaMobileMoneyResponse.Data.Narration,
                    PaymentType = externalTanzaniaMobileMoneyResponse.Data.PaymentType,
                    ProcessorResponse = externalTanzaniaMobileMoneyResponse.Data.ProcessorResponse,
                    Status = externalTanzaniaMobileMoneyResponse.Data.Status,
                    TxRef = externalTanzaniaMobileMoneyResponse.Data.TxRef,

                    Customer = new TanzaniaMobileMoneyResponse.Customer
                    {
                        CreatedAt = externalTanzaniaMobileMoneyResponse.Data.Customer.CreatedAt,
                        Email = externalTanzaniaMobileMoneyResponse.Data.Customer.Email,
                        Id = externalTanzaniaMobileMoneyResponse.Data.Customer.Id,
                        Name = externalTanzaniaMobileMoneyResponse.Data.Customer.Name,
                        PhoneNumber = externalTanzaniaMobileMoneyResponse.Data.Customer.PhoneNumber,

                    }
                },
                Status = externalTanzaniaMobileMoneyResponse.Status,


            };
            return tanzaniaMobileMoney;
        }
        private ExternalRwandaMobileMoneyRequest ConvertToChargeRequest(RwandaMobileMoney tanzaniaMobileMoney)
        {
            return new ExternalRwandaMobileMoneyRequest
            {
                Amount = tanzaniaMobileMoney.Request.Amount,
                Currency = tanzaniaMobileMoney.Request.Currency,
                Email = tanzaniaMobileMoney.Request.Email,
                FullName = tanzaniaMobileMoney.Request.FullName,
                PhoneNumber = tanzaniaMobileMoney.Request.PhoneNumber,
                TxRef = tanzaniaMobileMoney.Request.TxRef,
                OrderId = tanzaniaMobileMoney.Request.OrderId

            };
        }
        private RwandaMobileMoney ConvertToChargeResponse(RwandaMobileMoney tanzaniaMobileMoney, ExternalRwandaMobileMoneyResponse externalRwandaMobileMoneyResponse)
        {

            tanzaniaMobileMoney.Response = new RwandaMobileMoneyResponse
            {
                Message = externalRwandaMobileMoneyResponse.Message,
                Meta = new RwandaMobileMoneyResponse.RwandaMobileMoneyMeta
                {
                    Authorization = new RwandaMobileMoneyResponse.Authorization
                    {
                        Mode = externalRwandaMobileMoneyResponse.Meta.Authorization.Mode,
                        Redirect = externalRwandaMobileMoneyResponse.Meta.Authorization.Redirect
                    }
                },

                Status = externalRwandaMobileMoneyResponse.Status,


            };
            return tanzaniaMobileMoney;
        }
        private ExternalZambiaMobileMoneyRequest ConvertToChargeRequest(ZambiaMobileMoney zambiaMobileMoney)
        {
            return new ExternalZambiaMobileMoneyRequest
            {
                Amount = zambiaMobileMoney.Request.Amount,
                Currency = zambiaMobileMoney.Request.Currency,
                Email = zambiaMobileMoney.Request.Email,
                Fullname = zambiaMobileMoney.Request.FullName,
                PhoneNumber = zambiaMobileMoney.Request.PhoneNumber,
                TxRef = zambiaMobileMoney.Request.TxRef,
                OrderId = zambiaMobileMoney.Request.OrderId,
                Meta = new ExternalZambiaMobileMoneyRequest.ExternalZambiaMobileMoneyMeta
                {
                    FlightID = zambiaMobileMoney.Request.Meta.FlightID
                },
                ClientIp = zambiaMobileMoney.Request.ClientIp,
                DeviceFingerprint = zambiaMobileMoney.Request.DeviceFingerprint,
                Network = zambiaMobileMoney.Request.Network,


            };
        }
        private ZambiaMobileMoney ConvertToChargeResponse(ZambiaMobileMoney zambiaMobileMoney, ExternalZambiaMobileMoneyResponse externalZambiaMobileMoneyResponse)
        {

            zambiaMobileMoney.Response = new ZambiaMobileMoneyResponse
            {

                Message = externalZambiaMobileMoneyResponse.Message,
                Status = externalZambiaMobileMoneyResponse.Status,
                Meta = new ZambiaMobileMoneyResponse.ZambiaMobileMoneyMeta
                {
                    Authorization = new ZambiaMobileMoneyResponse.Authorization
                    {
                        Redirect = externalZambiaMobileMoneyResponse.Meta.Authorization.Redirect,
                        Mode = externalZambiaMobileMoneyResponse.Meta.Authorization.Mode
                    }
                }

            };
            return zambiaMobileMoney;
        }
        private ExternalUSSDRequest ConvertToChargeRequest(USSD uSSD)
        {
            return new ExternalUSSDRequest
            {
                Amount = uSSD.Request.Amount,
                Currency = uSSD.Request.Currency,
                Email = uSSD.Request.Email,
                FullName = uSSD.Request.FullName,
                PhoneNumber = uSSD.Request.PhoneNumber,
                TxRef = uSSD.Request.TxRef,
                AccountBank = uSSD.Request.AccountBank,



            };
        }
        private USSD ConvertToChargeResponse(USSD uSSD, ExternalUSSDResponse externalUSSDResponse)
        {

            uSSD.Response = new USSDResponse
            {
                Message = externalUSSDResponse.Message,
                Data = new USSDResponse.USSDData
                {
                    AccountId = externalUSSDResponse.Data.AccountId,
                    Amount = externalUSSDResponse.Data.Amount,
                    AppFee = externalUSSDResponse.Data.AppFee,
                    AuthModel = externalUSSDResponse.Data.AuthModel,
                    ChargedAmount = externalUSSDResponse.Data.ChargedAmount,
                    ChargeType = externalUSSDResponse.Data.ChargeType,
                    CreatedAt = externalUSSDResponse.Data.CreatedAt,
                    Currency = externalUSSDResponse.Data.Currency,
                    DeviceFingerprint = externalUSSDResponse.Data.DeviceFingerprint,
                    Id = externalUSSDResponse.Data.Id,
                    FlwRef = externalUSSDResponse.Data.FlwRef,
                    FraudStatus = externalUSSDResponse.Data.FraudStatus,
                    Ip = externalUSSDResponse.Data.Ip,
                    MerchantFee = externalUSSDResponse.Data.MerchantFee,
                    Narration = externalUSSDResponse.Data.Narration,
                    PaymentType = externalUSSDResponse.Data.PaymentType,
                    ProcessorResponse = externalUSSDResponse.Data.ProcessorResponse,
                    Status = externalUSSDResponse.Data.Status,
                    TxRef = externalUSSDResponse.Data.TxRef,
                    PaymentCode = externalUSSDResponse.Data.PaymentCode,
                    Customer = new USSDResponse.Customer
                    {
                        CreatedAt = externalUSSDResponse.Data.Customer.CreatedAt,
                        Email = externalUSSDResponse.Data.Customer.Email,
                        Id = externalUSSDResponse.Data.Customer.Id,
                        Name = externalUSSDResponse.Data.Customer.Name,
                        PhoneNumber = externalUSSDResponse.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new USSDResponse.USSDMeta
                {
                    Authorization = new USSDResponse.Authorization
                    {
                        Mode = externalUSSDResponse.Meta.Authorization.Mode,
                        Note = externalUSSDResponse.Meta.Authorization.Note
                    }
                },
                Status = externalUSSDResponse.Status,


            };
            return uSSD;
        }
        private ExternalUkEuBankAccountsRequest ConvertToChargeRequest(UkEuBankAccounts ukEuBankAccounts)
        {
            return new ExternalUkEuBankAccountsRequest
            {
                Amount = ukEuBankAccounts.Request.Amount,
                Currency = ukEuBankAccounts.Request.Currency,
                Email = ukEuBankAccounts.Request.Email,
                FullName = ukEuBankAccounts.Request.FullName,
                PhoneNumber = ukEuBankAccounts.Request.PhoneNumber,
                TxRef = ukEuBankAccounts.Request.TxRef,
                IsTokenIo = ukEuBankAccounts.Request.IsTokenIo,
                RedirectUrl = ukEuBankAccounts.Request.RedirectUrl


            };
        }
        private UkEuBankAccounts ConvertToChargeResponse(UkEuBankAccounts ukEuBankAccounts, ExternalUkEuBankAccountsResponse externalUkEuBankAccountsResponse)
        {

            ukEuBankAccounts.Response = new UkEuBankAccountsResponse
            {
                Message = externalUkEuBankAccountsResponse.Message,
                Data = new UkEuBankAccountsResponse.UkEuBankAccountsData
                {
                    AccountId = externalUkEuBankAccountsResponse.Data.AccountId,
                    Amount = externalUkEuBankAccountsResponse.Data.Amount,
                    AppFee = externalUkEuBankAccountsResponse.Data.AppFee,
                    AuthModel = externalUkEuBankAccountsResponse.Data.AuthModel,
                    ChargedAmount = externalUkEuBankAccountsResponse.Data.ChargedAmount,
                    ChargeType = externalUkEuBankAccountsResponse.Data.ChargeType,
                    CreatedAt = externalUkEuBankAccountsResponse.Data.CreatedAt,
                    Currency = externalUkEuBankAccountsResponse.Data.Currency,
                    DeviceFingerprint = externalUkEuBankAccountsResponse.Data.DeviceFingerprint,
                    Id = externalUkEuBankAccountsResponse.Data.Id,
                    FlwRef = externalUkEuBankAccountsResponse.Data.FlwRef,
                    FraudStatus = externalUkEuBankAccountsResponse.Data.FraudStatus,
                    Ip = externalUkEuBankAccountsResponse.Data.Ip,
                    MerchantFee = externalUkEuBankAccountsResponse.Data.MerchantFee,
                    Narration = externalUkEuBankAccountsResponse.Data.Narration,
                    PaymentType = externalUkEuBankAccountsResponse.Data.PaymentType,
                    ProcessorResponse = externalUkEuBankAccountsResponse.Data.ProcessorResponse,
                    Status = externalUkEuBankAccountsResponse.Data.Status,
                    TxRef = externalUkEuBankAccountsResponse.Data.TxRef,

                    Customer = new UkEuBankAccountsResponse.Customer
                    {
                        CreatedAt = externalUkEuBankAccountsResponse.Data.Customer.CreatedAt,
                        Email = externalUkEuBankAccountsResponse.Data.Customer.Email,
                        Id = externalUkEuBankAccountsResponse.Data.Customer.Id,
                        Name = externalUkEuBankAccountsResponse.Data.Customer.Name,
                        PhoneNumber = externalUkEuBankAccountsResponse.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new UkEuBankAccountsResponse.UkEuBankAccountsMeta
                {
                    Authorization = new UkEuBankAccountsResponse.Authorization
                    {
                        Mode = externalUkEuBankAccountsResponse.Meta.Authorization.Mode,
                        Redirect = externalUkEuBankAccountsResponse.Meta.Authorization.Redirect
                    }
                },
                Status = externalUkEuBankAccountsResponse.Status,


            };
            return ukEuBankAccounts;
        }
        private ExternalACHPaymentsRequest ConvertToChargeRequest(ACHPayments aCHPayments)
        {
            return new ExternalACHPaymentsRequest
            {
                Amount = aCHPayments.Request.Amount,
                Currency = aCHPayments.Request.Currency,
                Email = aCHPayments.Request.Email,
                FullName = aCHPayments.Request.FullName,
                PhoneNumber = aCHPayments.Request.PhoneNumber,
                TxRef = aCHPayments.Request.TxRef,
                Meta = new ExternalACHPaymentsRequest.ExternalACHPaymentsMeta
                {
                    FlightID = aCHPayments.Request.Meta.FlightID
                },
                ClientIp = aCHPayments.Request.ClientIp,
                DeviceFingerprint = aCHPayments.Request.DeviceFingerprint,
                Country = aCHPayments.Request.Country,
                RedirectUrl = aCHPayments.Request.RedirectUrl


            };
        }
        private ACHPayments ConvertToChargeResponse(ACHPayments aCHPayments, ExternalACHPaymentsResponse externalACHPaymentsResponse)
        {

            aCHPayments.Response = new ACHPaymentsResponse
            {
                Message = externalACHPaymentsResponse.Message,
                Data = new ACHPaymentsResponse.ACHPaymentsData
                {
                    AccountId = externalACHPaymentsResponse.Data.AccountId,
                    Amount = externalACHPaymentsResponse.Data.Amount,
                    AppFee = externalACHPaymentsResponse.Data.AppFee,
                    AuthModel = externalACHPaymentsResponse.Data.AuthModel,
                    ChargedAmount = externalACHPaymentsResponse.Data.ChargedAmount,
                    ChargeType = externalACHPaymentsResponse.Data.ChargeType,
                    CreatedAt = externalACHPaymentsResponse.Data.CreatedAt,
                    Currency = externalACHPaymentsResponse.Data.Currency,
                    DeviceFingerprint = externalACHPaymentsResponse.Data.DeviceFingerprint,
                    Id = externalACHPaymentsResponse.Data.Id,
                    FlwRef = externalACHPaymentsResponse.Data.FlwRef,
                    FraudStatus = externalACHPaymentsResponse.Data.FraudStatus,
                    Ip = externalACHPaymentsResponse.Data.Ip,
                    MerchantFee = externalACHPaymentsResponse.Data.MerchantFee,
                    Narration = externalACHPaymentsResponse.Data.Narration,
                    PaymentType = externalACHPaymentsResponse.Data.PaymentType,
                    ProcessorResponse = externalACHPaymentsResponse.Data.ProcessorResponse,
                    Status = externalACHPaymentsResponse.Data.Status,
                    TxRef = externalACHPaymentsResponse.Data.TxRef,
                    RedirectUrl = externalACHPaymentsResponse.Data.RedirectUrl,
                    AuthUrl = externalACHPaymentsResponse.Data.AuthUrl,
                    Customer = new ACHPaymentsResponse.Customer
                    {
                        CreatedAt = externalACHPaymentsResponse.Data.Customer.CreatedAt,
                        Email = externalACHPaymentsResponse.Data.Customer.Email,
                        Id = externalACHPaymentsResponse.Data.Customer.Id,
                        Name = externalACHPaymentsResponse.Data.Customer.Name,
                        PhoneNumber = externalACHPaymentsResponse.Data.Customer.PhoneNumber,

                    }
                },

                Status = externalACHPaymentsResponse.Status,


            };
            return aCHPayments;
        }
        private ExternalApplePayRequest ConvertToChargeRequest(ApplePay applePay)
        {
            return new ExternalApplePayRequest
            {
                Amount = applePay.Request.Amount,
                Currency = applePay.Request.Currency,
                Email = applePay.Request.Email,
                FullName = applePay.Request.FullName,
                PhoneNumber = applePay.Request.PhoneNumber,
                TxRef = applePay.Request.TxRef,
                Meta = new ExternalApplePayRequest.ExternalApplePayMeta
                {
                    Metaname = applePay.Request.Meta.Metaname,
                    Metavalue = applePay.Request.Meta.Metavalue
                },
                ClientIp = applePay.Request.ClientIp,
                DeviceFingerprint = applePay.Request.DeviceFingerprint,
                RedirectUrl = applePay.Request.RedirectUrl,
                BillingAddress = applePay.Request.BillingAddress,
                BillingCity = applePay.Request.BillingCity,
                BillingCountry = applePay.Request.BillingCountry,
                BillingState = applePay.Request.BillingState,
                BillingZip = applePay.Request.BillingZip,
                Narration = applePay.Request.Narration,



            };
        }
        private ApplePay ConvertToChargeResponse(ApplePay applePay, ExternalApplePayResponse externalApplePayResponse)
        {

            applePay.Response = new ApplePayResponse
            {
                Message = externalApplePayResponse.Message,
                Data = new ApplePayResponse.ApplePayData
                {
                    AccountId = externalApplePayResponse.Data.AccountId,
                    Amount = externalApplePayResponse.Data.Amount,
                    AppFee = externalApplePayResponse.Data.AppFee,
                    AuthModel = externalApplePayResponse.Data.AuthModel,
                    ChargedAmount = externalApplePayResponse.Data.ChargedAmount,
                    ChargeType = externalApplePayResponse.Data.ChargeType,
                    CreatedAt = externalApplePayResponse.Data.CreatedAt,
                    Currency = externalApplePayResponse.Data.Currency,
                    DeviceFingerprint = externalApplePayResponse.Data.DeviceFingerprint,
                    Id = externalApplePayResponse.Data.Id,
                    FlwRef = externalApplePayResponse.Data.FlwRef,
                    FraudStatus = externalApplePayResponse.Data.FraudStatus,
                    Ip = externalApplePayResponse.Data.Ip,
                    MerchantFee = externalApplePayResponse.Data.MerchantFee,
                    Narration = externalApplePayResponse.Data.Narration,
                    PaymentType = externalApplePayResponse.Data.PaymentType,
                    ProcessorResponse = externalApplePayResponse.Data.ProcessorResponse,
                    Status = externalApplePayResponse.Data.Status,
                    TxRef = externalApplePayResponse.Data.TxRef,
                    AuthUrl = externalApplePayResponse.Data.AuthUrl,
                    Meta = new ApplePayResponse.Meta
                    {
                        Authorization = new ApplePayResponse.Authorization
                        {
                            Mode = externalApplePayResponse.Data.Meta.Authorization.Mode,
                            Redirect = externalApplePayResponse.Data.Meta.Authorization.Redirect
                        }
                    },
                    Customer = new ApplePayResponse.Customer
                    {
                        CreatedAt = externalApplePayResponse.Data.Customer.CreatedAt,
                        Email = externalApplePayResponse.Data.Customer.Email,
                        Id = externalApplePayResponse.Data.Customer.Id,
                        Name = externalApplePayResponse.Data.Customer.Name,
                        PhoneNumber = externalApplePayResponse.Data.Customer.PhoneNumber,

                    }
                },

                Status = externalApplePayResponse.Status,


            };
            return applePay;
        }
        private ExternalGooglePayRequest ConvertToChargeRequest(GooglePay googlePay)
        {
            return new ExternalGooglePayRequest
            {
                Amount = googlePay.Request.Amount,
                Currency = googlePay.Request.Currency,
                Email = googlePay.Request.Email,
                Fullname = googlePay.Request.FullName,
                TxRef = googlePay.Request.TxRef,
                Meta = new ExternalGooglePayRequest.ExternalGooglePayMeta
                {
                    MetaName = googlePay.Request.Meta.MetaName,
                    MetaValue = googlePay.Request.Meta.MetaValue,

                },
                ClientIp = googlePay.Request.ClientIp,
                DeviceFingerprint = googlePay.Request.DeviceFingerprint,
                RedirectUrl = googlePay.Request.RedirectUrl,
                BillingAddress = googlePay.Request.BillingAddress,
                BillingCity = googlePay.Request.BillingCity,
                BillingCountry = googlePay.Request.BillingCountry,
                BillingState = googlePay.Request.BillingState,
                BillingZip = googlePay.Request.BillingZip,
                Narration = googlePay.Request.Narration,



            };
        }
        private GooglePay ConvertToChargeResponse(GooglePay googlePay, ExternalGooglePayResponse externalGooglePayResponse)
        {

            googlePay.Response = new GooglePayResponse
            {
                Message = externalGooglePayResponse.Message,
                Data = new GooglePayResponse.GooglePayData
                {
                    AccountId = externalGooglePayResponse.Data.AccountId,
                    Amount = externalGooglePayResponse.Data.Amount,
                    AppFee = externalGooglePayResponse.Data.AppFee,
                    AuthModel = externalGooglePayResponse.Data.AuthModel,
                    ChargedAmount = externalGooglePayResponse.Data.ChargedAmount,
                    ChargeType = externalGooglePayResponse.Data.ChargeType,
                    CreatedAt = externalGooglePayResponse.Data.CreatedAt,
                    Currency = externalGooglePayResponse.Data.Currency,
                    DeviceFingerprint = externalGooglePayResponse.Data.DeviceFingerprint,
                    Id = externalGooglePayResponse.Data.Id,
                    FlwRef = externalGooglePayResponse.Data.FlwRef,
                    FraudStatus = externalGooglePayResponse.Data.FraudStatus,
                    Ip = externalGooglePayResponse.Data.Ip,
                    MerchantFee = externalGooglePayResponse.Data.MerchantFee,
                    Narration = externalGooglePayResponse.Data.Narration,
                    PaymentType = externalGooglePayResponse.Data.PaymentType,
                    ProcessorResponse = externalGooglePayResponse.Data.ProcessorResponse,
                    Status = externalGooglePayResponse.Data.Status,
                    TxRef = externalGooglePayResponse.Data.TxRef,
                    AuthUrl = externalGooglePayResponse.Data.AuthUrl,

                    Meta = new GooglePayResponse.Meta
                    {
                        Authorization = new GooglePayResponse.Authorization
                        {
                            Mode = externalGooglePayResponse.Data.Meta.Authorization.Mode,
                            Redirect = externalGooglePayResponse.Data.Meta.Authorization.Redirect
                        }
                    },
                    Customer = new GooglePayResponse.Customer
                    {
                        CreatedAt = externalGooglePayResponse.Data.Customer.CreatedAt,
                        Email = externalGooglePayResponse.Data.Customer.Email,
                        Id = externalGooglePayResponse.Data.Customer.Id,
                        Name = externalGooglePayResponse.Data.Customer.Name,
                        PhoneNumber = externalGooglePayResponse.Data.Customer.PhoneNumber,

                    }
                },

                Status = externalGooglePayResponse.Status,


            };
            return googlePay;
        }
        private ExternalENairaRequest ConvertToChargeRequest(ENaira eNaira)
        {
            return new ExternalENairaRequest
            {
                Amount = eNaira.Request.Amount,
                Currency = eNaira.Request.Currency,
                Email = eNaira.Request.Email,
                Fullname = eNaira.Request.FullName,
                PhoneNumber = eNaira.Request.PhoneNumber,
                TxRef = eNaira.Request.TxRef,
                RedirectUrl = eNaira.Request.RedirectUrl,




            };
        }
        private ENaira ConvertToChargeResponse(ENaira eNaira, ExternalENairaResponse externalENairaResponse)
        {

            eNaira.Response = new ENairaResponse
            {
                Message = externalENairaResponse.Message,
                Data = new ENairaResponse.ENairaData
                {
                    AccountId = externalENairaResponse.Data.AccountId,
                    Amount = externalENairaResponse.Data.Amount,
                    AppFee = externalENairaResponse.Data.AppFee,
                    AuthModel = externalENairaResponse.Data.AuthModel,
                    ChargedAmount = externalENairaResponse.Data.ChargedAmount,
                    ChargeType = externalENairaResponse.Data.ChargeType,
                    CreatedAt = externalENairaResponse.Data.CreatedAt,
                    Currency = externalENairaResponse.Data.Currency,
                    DeviceFingerprint = externalENairaResponse.Data.DeviceFingerprint,
                    Id = externalENairaResponse.Data.Id,
                    FlwRef = externalENairaResponse.Data.FlwRef,
                    FraudStatus = externalENairaResponse.Data.FraudStatus,
                    Ip = externalENairaResponse.Data.Ip,
                    MerchantFee = externalENairaResponse.Data.MerchantFee,
                    Narration = externalENairaResponse.Data.Narration,
                    PaymentType = externalENairaResponse.Data.PaymentType,
                    ProcessorResponse = externalENairaResponse.Data.ProcessorResponse,
                    Status = externalENairaResponse.Data.Status,
                    TxRef = externalENairaResponse.Data.TxRef,

                    Meta = new ENairaResponse.Meta
                    {
                        Authorization = new ENairaResponse.Authorization
                        {
                            Mode = externalENairaResponse.Data.Meta.Authorization.Mode,
                            Redirect = externalENairaResponse.Data.Meta.Authorization.Redirect
                        }
                    },
                    Customer = new ENairaResponse.Customer
                    {
                        CreatedAt = externalENairaResponse.Data.Customer.CreatedAt,
                        Email = externalENairaResponse.Data.Customer.Email,
                        Id = externalENairaResponse.Data.Customer.Id,
                        Name = externalENairaResponse.Data.Customer.Name,
                        PhoneNumber = externalENairaResponse.Data.Customer.PhoneNumber,

                    }
                },

                Status = externalENairaResponse.Status,


            };
            return eNaira;
        }
        private ExternalFawryRequest ConvertToChargeRequest(Fawry fawry)
        {
            return new ExternalFawryRequest
            {
                Amount = fawry.Request.Amount,
                Currency = fawry.Request.Currency,
                Email = fawry.Request.Email,
                RedirectUrl = fawry.Request.RedirectUrl,
                PhoneNumber = fawry.Request.PhoneNumber,
                TxRef = fawry.Request.TxRef,
                Meta = new ExternalFawryRequest.ExternalFawryMeta
                {
                    Name = fawry.Request.Meta.Name,
                    Tools = fawry.Request.Meta.Tools
                },





            };
        }
        private Fawry ConvertToChargeResponse(Fawry fawry, ExternalFawryResponse externalFawryResponse)
        {

            fawry.Response = new FawryResponse
            {
                Message = externalFawryResponse.Message,
                Data = new FawryResponse.FawryData
                {
                    AccountId = externalFawryResponse.Data.AccountId,
                    Amount = externalFawryResponse.Data.Amount,
                    AppFee = externalFawryResponse.Data.AppFee,
                    OrderRef = externalFawryResponse.Data.OrderRef,
                    ChargedAmount = externalFawryResponse.Data.ChargedAmount,
                    ChargeType = externalFawryResponse.Data.ChargeType,
                    CreatedAt = externalFawryResponse.Data.CreatedAt,
                    Currency = externalFawryResponse.Data.Currency,
                    DeviceFingerprint = externalFawryResponse.Data.DeviceFingerprint,
                    Id = externalFawryResponse.Data.Id,
                    FlwRef = externalFawryResponse.Data.FlwRef,
                    FraudStatus = externalFawryResponse.Data.FraudStatus,
                    MerchantFee = externalFawryResponse.Data.MerchantFee,
                    Narration = externalFawryResponse.Data.Narration,
                    PaymentType = externalFawryResponse.Data.PaymentType,
                    ProcessorResponse = externalFawryResponse.Data.ProcessorResponse,
                    Status = externalFawryResponse.Data.Status,
                    TxRef = externalFawryResponse.Data.TxRef,
                    AuthUrl = externalFawryResponse.Data.AuthUrl,

                    Customer = new FawryResponse.Customer
                    {
                        CreatedAt = externalFawryResponse.Data.Customer.CreatedAt,
                        Email = externalFawryResponse.Data.Customer.Email,
                        Id = externalFawryResponse.Data.Customer.Id,
                        Name = externalFawryResponse.Data.Customer.Name,
                        PhoneNumber = externalFawryResponse.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new FawryResponse.FawryMeta
                {
                    Authorization = new FawryResponse.Authorization
                    {
                        Instruction = externalFawryResponse.Meta.Authorization.Instruction,
                        Mode = externalFawryResponse.Meta.Authorization.Mode
                    }
                },
                Status = externalFawryResponse.Status,


            };
            return fawry;
        }
        private ExternalPayPalRequest ConvertToChargeRequest(PayPal payPal)
        {
            return new ExternalPayPalRequest
            {
                Amount = payPal.Request.Amount,
                Currency = payPal.Request.Currency,
                Email = payPal.Request.Email,
                Fullname = payPal.Request.FullName,
                PhoneNumber = payPal.Request.PhoneNumber,
                TxRef = payPal.Request.TxRef,
                ClientIp = payPal.Request.ClientIp,
                DeviceFingerprint = payPal.Request.DeviceFingerprint,
                RedirectUrl = payPal.Request.RedirectUrl,
                BillingAddress = payPal.Request.BillingAddress,
                BillingCity = payPal.Request.BillingCity,
                BillingCountry = payPal.Request.BillingCountry,
                BillingState = payPal.Request.BillingState,
                BillingZip = payPal.Request.BillingZip,
                Country = payPal.Request.Country,
                ShippingAddress = payPal.Request.ShippingAddress,
                ShippingCity = payPal.Request.ShippingCity,
                ShippingCountry = payPal.Request.ShippingCountry,
                ShippingName = payPal.Request.ShippingName,
                ShippingState = payPal.Request.ShippingState,
                ShippingZip = payPal.Request.ShippingZip




            };
        }
        private PayPal ConvertToChargeResponse(PayPal payPal, ExternalPayPalResponse externalPayPalResponse)
        {

            payPal.Response = new PayPalResponse
            {
                Message = externalPayPalResponse.Message,
                Data = new PayPalResponse.PayPalData
                {
                    AccountId = externalPayPalResponse.Data.AccountId,
                    Amount = externalPayPalResponse.Data.Amount,
                    AppFee = externalPayPalResponse.Data.AppFee,
                    AuthModel = externalPayPalResponse.Data.AuthModel,
                    ChargedAmount = externalPayPalResponse.Data.ChargedAmount,
                    ChargeType = externalPayPalResponse.Data.ChargeType,
                    CreatedAt = externalPayPalResponse.Data.CreatedAt,
                    Currency = externalPayPalResponse.Data.Currency,
                    DeviceFingerprint = externalPayPalResponse.Data.DeviceFingerprint,
                    Id = externalPayPalResponse.Data.Id,
                    FlwRef = externalPayPalResponse.Data.FlwRef,
                    FraudStatus = externalPayPalResponse.Data.FraudStatus,
                    Ip = externalPayPalResponse.Data.Ip,
                    MerchantFee = externalPayPalResponse.Data.MerchantFee,
                    Narration = externalPayPalResponse.Data.Narration,
                    PaymentType = externalPayPalResponse.Data.PaymentType,
                    ProcessorResponse = externalPayPalResponse.Data.ProcessorResponse,
                    Status = externalPayPalResponse.Data.Status,
                    TxRef = externalPayPalResponse.Data.TxRef,
                    AuthUrl = externalPayPalResponse.Data.AuthUrl,

                    Meta = new PayPalResponse.Meta
                    {
                        Authorization = new PayPalResponse.Authorization
                        {
                            Mode = externalPayPalResponse.Data.Meta.Authorization.Mode,
                            Redirect = externalPayPalResponse.Data.Meta.Authorization.Redirect

                        }
                    },
                    Customer = new PayPalResponse.Customer
                    {
                        CreatedAt = externalPayPalResponse.Data.Customer.CreatedAt,
                        Email = externalPayPalResponse.Data.Customer.Email,
                        Id = externalPayPalResponse.Data.Customer.Id,
                        Name = externalPayPalResponse.Data.Customer.Name,
                        PhoneNumber = externalPayPalResponse.Data.Customer.PhoneNumber,

                    }
                },

                Status = externalPayPalResponse.Status,


            };
            return payPal;
        }

    }
}

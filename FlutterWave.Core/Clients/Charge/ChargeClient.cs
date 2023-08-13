using FlutterWave.Core.Models.Clients.Charge.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Charge
{
    internal class ChargeClient : IChargeClient
    {

        private readonly IChargeService chargeService;

        public ChargeClient(IChargeService chargeService) =>
        this.chargeService = chargeService;

        public async ValueTask<ACHPayments> ChargeACHPaymentsAsync(ACHPayments aCHPayments)
        {
            try
            {
                return await chargeService.PostChargeACHPaymentsRequestAsync(aCHPayments);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ACHPayments
                    {
                        Response = new ACHPaymentsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ApplePay> ChargeApplePayAsync(ApplePay applePay)
        {
            try
            {
                return await chargeService.PostChargeApplePayRequestAsync(applePay);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ApplePay
                    {
                        Response = new ApplePayResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BankTransfer> ChargeBankTransferAsync(BankTransfer bankTransfer)
        {
            try
            {
                return await chargeService.PostChargeBankTransferRequestAsync(bankTransfer);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BankTransfer
                    {
                        Response = new BankTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CardCharge> ChargeCardAsync(CardCharge cardCharge, string encryptionKey)
        {
            try
            {
                return await chargeService.PostChargeCardRequestAsync(cardCharge, encryptionKey);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CardCharge
                    {
                        Response = new CardChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ENaira> ChargeENairaAsync(ENaira eNaira)
        {
            try
            {
                return await chargeService.PostChargeENairaRequestAsync(eNaira);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ENaira
                    {
                        Response = new ENairaResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Fawry> ChargeFawryAsync(Fawry fawry)
        {
            try
            {
                return await chargeService.PostChargeFawryRequestAsync(fawry);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Fawry
                    {
                        Response = new FawryResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FrancophoneMobileMoney> ChargeFrancophoneMobileMoneyAsync(FrancophoneMobileMoney francophoneMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(francophoneMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FrancophoneMobileMoney
                    {
                        Response = new FrancophoneMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<GhanaMobileMoney> ChargeGhanaMobileMoneyAsync(GhanaMobileMoney ghanaMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeGhanaMobileMoneyRequestAsync(ghanaMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new GhanaMobileMoney
                    {
                        Response = new GhanaMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<GooglePay> ChargeGooglePayAsync(GooglePay googlePay)
        {
            try
            {
                return await chargeService.PostChargeGooglePayRequestAsync(googlePay);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new GooglePay
                    {
                        Response = new GooglePayResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Mpesa> ChargeMpesaAsync(Mpesa Mpesa)
        {
            try
            {
                return await chargeService.PostChargeMpesaRequestAsync(Mpesa);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Mpesa
                    {
                        Response = new MpesaResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<NGBankAccounts> ChargeNGBankAccountAsync(NGBankAccounts nGBankAccounts)
        {
            try
            {
                return await chargeService.PostChargeNGBankAccountRequestAsync(nGBankAccounts);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new NGBankAccounts
                    {
                        Response = new NGBankAccountsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<PayPal> ChargePayPalAsync(PayPal payPal)
        {
            try
            {
                return await chargeService.PostChargePayPalRequestAsync(payPal);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new PayPal
                    {
                        Response = new PayPalResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<RwandaMobileMoney> ChargeRwandaMobileMoneyAsync(RwandaMobileMoney rwandaMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeRwandaMobileMoneyRequestAsync(rwandaMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new RwandaMobileMoney
                    {
                        Response = new RwandaMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TanzaniaMobileMoney> ChargeTanzaniaMobileMoneyAsync(TanzaniaMobileMoney tanzaniaMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(tanzaniaMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TanzaniaMobileMoney
                    {
                        Response = new TanzaniaMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UgandaMobileMoney> ChargeUgandaMobileMoneyAsync(UgandaMobileMoney ugandaMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeUgandaMobileMoneyRequestAsync(ugandaMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UgandaMobileMoney
                    {
                        Response = new UgandaMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UkEuBankAccounts> ChargeUkEuBankAccountsAsync(UkEuBankAccounts ukEuBankAccounts)
        {
            try
            {
                return await chargeService.PostChargeUkEuBankAccountsRequestAsync(ukEuBankAccounts);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UkEuBankAccounts
                    {
                        Response = new UkEuBankAccountsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<USSD> ChargeUSSDAsync(USSD uSSD)
        {
            try
            {
                return await chargeService.PostChargeUSSDRequestAsync(uSSD);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new USSD
                    {
                        Response = new USSDResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ZambiaMobileMoney> ChargeZambiaMobileMoneyAsync(ZambiaMobileMoney zambiaMobileMoney)
        {
            try
            {
                return await chargeService.PostChargeZambiaMobileMoneyRequestAsync(zambiaMobileMoney);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ZambiaMobileMoney
                    {
                        Response = new ZambiaMobileMoneyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ValidateCharge> ValidateChargeAsync(ValidateCharge validateCharge)
        {
            try
            {
                return await chargeService.PostValidateChargeRequestAsync(validateCharge);
            }
            catch (ChargeValidationException chargeValidationException)
            {
                throw new ChargeClientValidationException(
                    chargeValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyValidationException chargeDependencyValidationException)
            {
                var message = chargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ValidateCharge
                    {
                        Response = new ValidateChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new ChargeClientValidationException(
                    chargeDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeDependencyException chargeDependencyException)
            {
                throw new ChargeClientDependencyException(
                    chargeDependencyException.InnerException as Xeption);
            }
            catch (ChargeServiceException chargeServiceException)
            {
                throw new ChargeClientServiceException(
                    chargeServiceException.InnerException as Xeption);
            }
        }
    }
}

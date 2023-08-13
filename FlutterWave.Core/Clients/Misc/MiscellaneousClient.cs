using FlutterWave.Core.Models.Clients.Misc.Exceptions;
using FlutterWave.Core.Models.Clients.Miscellaneous.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using FlutterWave.Core.Services.Foundations.FlutterWave.MiscService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Misc
{
    internal class MiscellaneousClient : IMiscellaneousClient
    {
        private readonly IMiscellaneousService miscellaneousService;

        public MiscellaneousClient(IMiscellaneousService miscellaneousService) =>
              this.miscellaneousService = miscellaneousService;

        public async ValueTask<BalanceByCurrency> BalanceByCurrencyAsync(string externalBalanceByCurrencyRequest)
        {
            try
            {
                return await miscellaneousService.GetBalanceByCurrencyAsync(externalBalanceByCurrencyRequest);
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BalanceByCurrency
                    {
                        Response = new BalanceByCurrencyResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BalanceByCurrencies> BalanceCurrenciesAsync()
        {
            try
            {
                return await miscellaneousService.GetBalanceCurrenciesAsync();
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BalanceByCurrencies
                    {
                        Response = new AllBalanceCurrenciesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BinVerification> CardBinVerificationAsync(string bin)
        {
            try
            {
                return await miscellaneousService.GetCardBinVerificationAsync(bin);
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BinVerification
                    {
                        Response = new CardBinVerificationResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Statement> AccountStatementAsync()
        {
            try
            {
                return await miscellaneousService.GetStatementAsync();
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Statement
                    {
                        Response = new StatementResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BankAccountVerification> BankAccountVerificationAsync(BankAccountVerification bankAccountVerification)
        {
            try
            {
                return await miscellaneousService.PostBankAccountVerificationAsync(bankAccountVerification);
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BankAccountVerification
                    {
                        Response = new BankAccountVerificationResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BvnConsent> BvnConsentAsync(BvnConsent bvnConsent)
        {
            try
            {
                return await miscellaneousService.PostBvnConsentAsync(bvnConsent);
            }
            catch (MiscellaneousValidationException MiscellaneousValidationException)
            {
                throw new MiscellaneousClientValidationException(
                    MiscellaneousValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyValidationException MiscellaneousDependencyValidationException)
            {

                var message = MiscellaneousDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BvnConsent
                    {
                        Response = new BvnConsentResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new MiscellaneousClientValidationException(
                    MiscellaneousDependencyValidationException.InnerException as Xeption);
            }
            catch (MiscellaneousDependencyException MiscellaneousDependencyException)
            {
                throw new MiscellaneousClientDependencyException(
                    MiscellaneousDependencyException.InnerException as Xeption);
            }
            catch (MiscellaneousServiceException MiscellaneousServiceException)
            {
                throw new MiscellaneousClientServiceException(
                    MiscellaneousServiceException.InnerException as Xeption);
            }
        }
    }
}

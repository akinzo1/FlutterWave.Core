using FlutterWave.Core.Models.Clients.Banks.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using FlutterWave.Core.Services.Foundations.FlutterWave.BanksService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Banks
{
    internal class BanksClient : IBanksClient
    {
        private readonly IBanksService bankService;

        public BanksClient(IBanksService bankService) =>
            this.bankService = bankService;

        public async ValueTask<BankBranches> RetrieveAllBankBranchesByBankCodeAsync(int bankCode)
        {
            try
            {
                return await this.bankService.GetAllBankBranchesByBankCodeAsync(bankCode);
            }
            catch (BanksValidationException bankValidationException)
            {
                throw new BankClientValidationException(
                    bankValidationException.InnerException as Xeption);
            }
            catch (BanksDependencyValidationException bankDependencyValidationException)
            {
                var message = bankDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BankBranches
                    {
                        Response = new BankBranchesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BankClientValidationException(
                    bankDependencyValidationException.InnerException as Xeption);
            }
            catch (BanksDependencyException bankDependencyException)
            {
                throw new BankClientDependencyException(
                    bankDependencyException.InnerException as Xeption);
            }
            catch (BanksServiceException BankServiceException)
            {
                throw new BankClientServiceException(
                    BankServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Bank> RetrieveAllBanksByCountryAsync(string country)
        {
            try
            {
                return await bankService.GetAllBanksByCountryAsync(country);
            }
            catch (BanksValidationException bankValidationException)
            {
                throw new BankClientValidationException(
                    bankValidationException.InnerException as Xeption);
            }
            catch (BanksDependencyValidationException bankDependencyValidationException)
            {

                var message = bankDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Bank
                    {
                        Response = new BankResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }
                throw new BankClientValidationException(
                    bankDependencyValidationException.InnerException as Xeption);
            }
            catch (BanksDependencyException bankDependencyException)
            {
                throw new BankClientDependencyException(
                    bankDependencyException.InnerException as Xeption);
            }
            catch (BanksServiceException BankServiceException)
            {
                throw new BankClientServiceException(
                    BankServiceException.InnerException as Xeption);
            }
        }
    }
}

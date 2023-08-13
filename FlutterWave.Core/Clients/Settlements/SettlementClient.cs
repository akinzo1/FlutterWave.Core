using FlutterWave.Core.Models.Clients.Settlement.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.SettlementClient
{
    internal class SettlementClient : ISettlementClient
    {
        private readonly ISettlementsService settlementService;

        public SettlementClient(ISettlementsService settlementService) =>
              this.settlementService = settlementService;

        public async ValueTask<AllSettlements> RetrieveAllSettlementsAsync()
        {
            try
            {
                return await settlementService.GetAllSettlementsAsync();
            }
            catch (SettlementsValidationException SettlementValidationException)
            {
                throw new SettlementClientValidationException(
                    SettlementValidationException.InnerException as Xeption);
            }
            catch (SettlementsDependencyValidationException SettlementDependencyValidationException)
            {

                var message = SettlementDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AllSettlements
                    {
                        Response = new SettlementsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new SettlementClientValidationException(
                    SettlementDependencyValidationException.InnerException as Xeption);
            }
            catch (SettlementsDependencyException SettlementDependencyException)
            {
                throw new SettlementClientDependencyException(
                    SettlementDependencyException.InnerException as Xeption);
            }
            catch (SettlementsServiceException SettlementServiceException)
            {
                throw new SettlementClientServiceException(
                    SettlementServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Settlement> FetchSettlementByIdAsync(string settlementId)
        {
            try
            {
                return await settlementService.GetSettlementsByIdAsync(settlementId);
            }
            catch (SettlementsValidationException SettlementValidationException)
            {
                throw new SettlementClientValidationException(
                    SettlementValidationException.InnerException as Xeption);
            }
            catch (SettlementsDependencyValidationException SettlementDependencyValidationException)
            {

                var message = SettlementDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Settlement
                    {
                        Response = new SettlementResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new SettlementClientValidationException(
                    SettlementDependencyValidationException.InnerException as Xeption);
            }
            catch (SettlementsDependencyException SettlementDependencyException)
            {
                throw new SettlementClientDependencyException(
                    SettlementDependencyException.InnerException as Xeption);
            }
            catch (SettlementsServiceException SettlementServiceException)
            {
                throw new SettlementClientServiceException(
                    SettlementServiceException.InnerException as Xeption);
            }
        }
    }
}

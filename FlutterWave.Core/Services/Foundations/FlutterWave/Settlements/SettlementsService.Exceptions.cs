using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService
{
    internal partial class SettlementsService
    {
        private delegate ValueTask<AllSettlements> ReturningSettlementsFunction();

        private delegate ValueTask<Settlement> ReturningSettlementFunction();

        private async ValueTask<AllSettlements> TryCatch(ReturningSettlementsFunction returningSettlementsFunction)
        {
            try
            {
                return await returningSettlementsFunction();
            }
            catch (NullSettlementsException nullSettlementException)
            {
                throw new SettlementsValidationException(nullSettlementException);
            }
            catch (InvalidSettlementsException invalidSettlementException)
            {
                throw new SettlementsValidationException(invalidSettlementException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSettlementException =
                    new InvalidConfigurationSettlementsException(httpResponseUrlNotFoundException);

                throw new SettlementsDependencyException(invalidConfigurationSettlementException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSettlementException =
                    new UnauthorizedSettlementsException(httpResponseUnauthorizedException);

                throw new SettlementsDependencyException(unauthorizedSettlementException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSettlementException =
                    new UnauthorizedSettlementsException(httpResponseForbiddenException);

                throw new SettlementsDependencyException(unauthorizedSettlementException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSettlementException =
                    new NotFoundSettlementsException(httpResponseNotFoundException);

                throw new SettlementsDependencyValidationException(notFoundSettlementException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSettlementException =
                    new InvalidSettlementsException(httpResponseBadRequestException);

                throw new SettlementsDependencyValidationException(invalidSettlementException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSettlementException =
                    new ExcessiveCallSettlementsException(httpResponseTooManyRequestsException);

                throw new SettlementsDependencyValidationException(excessiveCallSettlementException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSettlementException =
                    new FailedServerSettlementsException(httpResponseException);

                throw new SettlementsDependencyException(failedServerSettlementException);
            }
            catch (Exception exception)
            {
                var failedSettlementServiceException =
                    new FailedSettlementsServiceException(exception);

                throw new SettlementsServiceException(failedSettlementServiceException);
            }
        }

        private async ValueTask<Settlement> TryCatch(ReturningSettlementFunction returningSettlementFunction)
        {
            try
            {
                return await returningSettlementFunction();
            }
            catch (NullSettlementsException nullSettlementException)
            {
                throw new SettlementsValidationException(nullSettlementException);
            }
            catch (InvalidSettlementsException invalidSettlementException)
            {
                throw new SettlementsValidationException(invalidSettlementException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSettlementException =
                    new InvalidConfigurationSettlementsException(httpResponseUrlNotFoundException);

                throw new SettlementsDependencyException(invalidConfigurationSettlementException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSettlementException =
                    new UnauthorizedSettlementsException(httpResponseUnauthorizedException);

                throw new SettlementsDependencyException(unauthorizedSettlementException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSettlementException =
                    new UnauthorizedSettlementsException(httpResponseForbiddenException);

                throw new SettlementsDependencyException(unauthorizedSettlementException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSettlementException =
                    new NotFoundSettlementsException(httpResponseNotFoundException);

                throw new SettlementsDependencyValidationException(notFoundSettlementException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSettlementException =
                    new InvalidSettlementsException(httpResponseBadRequestException);

                throw new SettlementsDependencyValidationException(invalidSettlementException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSettlementException =
                    new ExcessiveCallSettlementsException(httpResponseTooManyRequestsException);

                throw new SettlementsDependencyValidationException(excessiveCallSettlementException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSettlementException =
                    new FailedServerSettlementsException(httpResponseException);

                throw new SettlementsDependencyException(failedServerSettlementException);
            }
            catch (Exception exception)
            {
                var failedSettlementServiceException =
                    new FailedSettlementsServiceException(exception);

                throw new SettlementsServiceException(failedSettlementServiceException);
            }
        }

    }
}
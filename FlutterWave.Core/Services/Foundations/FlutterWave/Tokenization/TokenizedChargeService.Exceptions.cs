using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService
{
    internal partial class TokenizedChargeService
    {
        private delegate ValueTask<BulkTokenizedStatus> ReturningBulkTokenizedStatusFunction();
        private delegate ValueTask<CreateBulkTokenizedCharge> ReturningCreateBulkTokenizedChargeFunction();
        private delegate ValueTask<CreateTokenizedCharge> ReturningCreateTokenizedChargeFunction();
        private delegate ValueTask<FetchBulkTokenizedCharge> ReturningFetchBulkTokenizedChargeFunction();
        private delegate ValueTask<UpdateCardToken> ReturningUpdateCardTokenFunction();


        private async ValueTask<BulkTokenizedStatus> TryCatch(ReturningBulkTokenizedStatusFunction returningBulkTokenizedStatusFunction)
        {
            try
            {
                return await returningBulkTokenizedStatusFunction();
            }
            catch (NullTokenizedChargeException nullTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(nullTokenizedChargeException);
            }
            catch (InvalidTokenizedChargeException invalidTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokenizedChargeException =
                    new InvalidConfigurationTokenizedChargeException(httpResponseUrlNotFoundException);

                throw new TokenizedChargeDependencyException(invalidConfigurationTokenizedChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseUnauthorizedException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseForbiddenException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokenizedChargeException =
                    new NotFoundTokenizedChargeException(httpResponseNotFoundException);

                throw new TokenizedChargeDependencyValidationException(notFoundTokenizedChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokenizedChargeException =
                    new InvalidTokenizedChargeException(httpResponseBadRequestException);

                throw new TokenizedChargeDependencyValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokenizedChargeException =
                    new ExcessiveCallTokenizedChargeException(httpResponseTooManyRequestsException);

                throw new TokenizedChargeDependencyValidationException(excessiveCallTokenizedChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokenizedChargeException =
                    new FailedServerTokenizedChargeException(httpResponseException);

                throw new TokenizedChargeDependencyException(failedServerTokenizedChargeException);
            }
            catch (Exception exception)
            {
                var failedTokenizedChargeServiceException =
                    new FailedTokenizedChargeServiceException(exception);

                throw new TokenizedChargeServiceException(failedTokenizedChargeServiceException);
            }
        }
        private async ValueTask<CreateBulkTokenizedCharge> TryCatch(ReturningCreateBulkTokenizedChargeFunction returningCreateBulkTokenizedChargeFunction)
        {
            try
            {
                return await returningCreateBulkTokenizedChargeFunction();
            }
            catch (NullTokenizedChargeException nullTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(nullTokenizedChargeException);
            }
            catch (InvalidTokenizedChargeException invalidTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokenizedChargeException =
                    new InvalidConfigurationTokenizedChargeException(httpResponseUrlNotFoundException);

                throw new TokenizedChargeDependencyException(invalidConfigurationTokenizedChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseUnauthorizedException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseForbiddenException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokenizedChargeException =
                    new NotFoundTokenizedChargeException(httpResponseNotFoundException);

                throw new TokenizedChargeDependencyValidationException(notFoundTokenizedChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokenizedChargeException =
                    new InvalidTokenizedChargeException(httpResponseBadRequestException);

                throw new TokenizedChargeDependencyValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokenizedChargeException =
                    new ExcessiveCallTokenizedChargeException(httpResponseTooManyRequestsException);

                throw new TokenizedChargeDependencyValidationException(excessiveCallTokenizedChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokenizedChargeException =
                    new FailedServerTokenizedChargeException(httpResponseException);

                throw new TokenizedChargeDependencyException(failedServerTokenizedChargeException);
            }
            catch (Exception exception)
            {
                var failedTokenizedChargeServiceException =
                    new FailedTokenizedChargeServiceException(exception);

                throw new TokenizedChargeServiceException(failedTokenizedChargeServiceException);
            }
        }
        private async ValueTask<CreateTokenizedCharge> TryCatch(ReturningCreateTokenizedChargeFunction returningCreateTokenizedChargeFunction)
        {
            try
            {
                return await returningCreateTokenizedChargeFunction();
            }
            catch (NullTokenizedChargeException nullTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(nullTokenizedChargeException);
            }
            catch (InvalidTokenizedChargeException invalidTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokenizedChargeException =
                    new InvalidConfigurationTokenizedChargeException(httpResponseUrlNotFoundException);

                throw new TokenizedChargeDependencyException(invalidConfigurationTokenizedChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseUnauthorizedException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseForbiddenException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokenizedChargeException =
                    new NotFoundTokenizedChargeException(httpResponseNotFoundException);

                throw new TokenizedChargeDependencyValidationException(notFoundTokenizedChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokenizedChargeException =
                    new InvalidTokenizedChargeException(httpResponseBadRequestException);

                throw new TokenizedChargeDependencyValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokenizedChargeException =
                    new ExcessiveCallTokenizedChargeException(httpResponseTooManyRequestsException);

                throw new TokenizedChargeDependencyValidationException(excessiveCallTokenizedChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokenizedChargeException =
                    new FailedServerTokenizedChargeException(httpResponseException);

                throw new TokenizedChargeDependencyException(failedServerTokenizedChargeException);
            }
            catch (Exception exception)
            {
                var failedTokenizedChargeServiceException =
                    new FailedTokenizedChargeServiceException(exception);

                throw new TokenizedChargeServiceException(failedTokenizedChargeServiceException);
            }
        }
        private async ValueTask<FetchBulkTokenizedCharge> TryCatch(ReturningFetchBulkTokenizedChargeFunction returningFetchBulkTokenizedChargeFunction)
        {
            try
            {
                return await returningFetchBulkTokenizedChargeFunction();
            }
            catch (NullTokenizedChargeException nullTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(nullTokenizedChargeException);
            }
            catch (InvalidTokenizedChargeException invalidTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokenizedChargeException =
                    new InvalidConfigurationTokenizedChargeException(httpResponseUrlNotFoundException);

                throw new TokenizedChargeDependencyException(invalidConfigurationTokenizedChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseUnauthorizedException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseForbiddenException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokenizedChargeException =
                    new NotFoundTokenizedChargeException(httpResponseNotFoundException);

                throw new TokenizedChargeDependencyValidationException(notFoundTokenizedChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokenizedChargeException =
                    new InvalidTokenizedChargeException(httpResponseBadRequestException);

                throw new TokenizedChargeDependencyValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokenizedChargeException =
                    new ExcessiveCallTokenizedChargeException(httpResponseTooManyRequestsException);

                throw new TokenizedChargeDependencyValidationException(excessiveCallTokenizedChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokenizedChargeException =
                    new FailedServerTokenizedChargeException(httpResponseException);

                throw new TokenizedChargeDependencyException(failedServerTokenizedChargeException);
            }
            catch (Exception exception)
            {
                var failedTokenizedChargeServiceException =
                    new FailedTokenizedChargeServiceException(exception);

                throw new TokenizedChargeServiceException(failedTokenizedChargeServiceException);
            }
        }
        private async ValueTask<UpdateCardToken> TryCatch(ReturningUpdateCardTokenFunction returningUpdateCardTokenFunction)
        {
            try
            {
                return await returningUpdateCardTokenFunction();
            }
            catch (NullTokenizedChargeException nullTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(nullTokenizedChargeException);
            }
            catch (InvalidTokenizedChargeException invalidTokenizedChargeException)
            {
                throw new TokenizedChargeValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokenizedChargeException =
                    new InvalidConfigurationTokenizedChargeException(httpResponseUrlNotFoundException);

                throw new TokenizedChargeDependencyException(invalidConfigurationTokenizedChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseUnauthorizedException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokenizedChargeException =
                    new UnauthorizedTokenizedChargeException(httpResponseForbiddenException);

                throw new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokenizedChargeException =
                    new NotFoundTokenizedChargeException(httpResponseNotFoundException);

                throw new TokenizedChargeDependencyValidationException(notFoundTokenizedChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokenizedChargeException =
                    new InvalidTokenizedChargeException(httpResponseBadRequestException);

                throw new TokenizedChargeDependencyValidationException(invalidTokenizedChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokenizedChargeException =
                    new ExcessiveCallTokenizedChargeException(httpResponseTooManyRequestsException);

                throw new TokenizedChargeDependencyValidationException(excessiveCallTokenizedChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokenizedChargeException =
                    new FailedServerTokenizedChargeException(httpResponseException);

                throw new TokenizedChargeDependencyException(failedServerTokenizedChargeException);
            }
            catch (Exception exception)
            {
                var failedTokenizedChargeServiceException =
                    new FailedTokenizedChargeServiceException(exception);

                throw new TokenizedChargeServiceException(failedTokenizedChargeServiceException);
            }
        }


    }
}
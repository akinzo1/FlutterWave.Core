using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService
{
    internal partial class TokenizedChargeService
    {


        private static void ValidateCreateTokenizedCharge(CreateTokenizedCharge createTokenizedCharge)
        {
            ValidateCreateTokenizedChargeNotNull(createTokenizedCharge);
            ValidateCreateTokenizedChargeRequestNotNull(createTokenizedCharge.Request);
            Validate(
                (Rule: IsInvalid(createTokenizedCharge), Parameter: nameof(createTokenizedCharge)));

            Validate(
                (Rule: IsInvalid(createTokenizedCharge.Request.Currency), Parameter: nameof(CreateTokenizedChargeRequest.Currency)),
                (Rule: IsInvalid(createTokenizedCharge.Request.Amount), Parameter: nameof(CreateTokenizedChargeRequest.Amount)),
                (Rule: IsInvalid(createTokenizedCharge.Request.TxRef), Parameter: nameof(CreateTokenizedChargeRequest.TxRef)),
                (Rule: IsInvalid(createTokenizedCharge.Request.Email), Parameter: nameof(CreateTokenizedChargeRequest.Email)),
                (Rule: IsInvalid(createTokenizedCharge.Request.Country), Parameter: nameof(CreateTokenizedChargeRequest.Country)),
                (Rule: IsInvalid(createTokenizedCharge.Request.Token), Parameter: nameof(CreateTokenizedChargeRequest.Token))


                );

        }

        private static void ValidateCreateBulkTokenizedCharge(CreateBulkTokenizedCharge createBulkTokenizedCharge)
        {
            ValidateCreateBulkTokenizedChargeNotNull(createBulkTokenizedCharge);
            ValidateCreateBulkTokenizedChargeRequestNotNull(createBulkTokenizedCharge.Request);
            Validate(
                (Rule: IsInvalid(createBulkTokenizedCharge), Parameter: nameof(createBulkTokenizedCharge)));

            Validate(
                (Rule: IsInvalid(createBulkTokenizedCharge.Request.BulkData), Parameter: nameof(CreateBulkTokenizedChargeRequest.BulkData)),
                (Rule: IsInvalid(createBulkTokenizedCharge.Request.RetryStrategy), Parameter: nameof(CreateBulkTokenizedChargeRequest.RetryStrategy))
                );

        }

        private static void ValidateUpdateCardToken(UpdateCardToken updateCardToken)
        {
            ValidateUpdateUpdateCardTokenNotNull(updateCardToken);
            ValidateUpdateUpdateCardTokenRequestNotNull(updateCardToken.Request);


            Validate(
                (Rule: IsInvalid(updateCardToken), Parameter: nameof(updateCardToken)));

            Validate(
                (Rule: IsInvalid(updateCardToken.Request.FullName), Parameter: nameof(UpdateCardTokenRequest.FullName)),
                (Rule: IsInvalid(updateCardToken.Request.PhoneNumber), Parameter: nameof(UpdateCardTokenRequest.PhoneNumber)),
                (Rule: IsInvalid(updateCardToken.Request.Email), Parameter: nameof(UpdateCardTokenRequest.Email))
                );

        }



        private static void ValidateCreateBulkTokenizedChargeRequestNotNull(CreateBulkTokenizedChargeRequest updateCardToken)
        {
            Validate((Rule: IsInvalid(updateCardToken), Parameter: nameof(CreateBulkTokenizedChargeRequest)));
        }
        private static void ValidateCreateTokenizedChargeRequestNotNull(CreateTokenizedChargeRequest updateCardToken)
        {
            Validate((Rule: IsInvalid(updateCardToken), Parameter: nameof(CreateTokenizedChargeRequest)));
        }

        private static void ValidateUpdateUpdateCardTokenRequestNotNull(UpdateCardTokenRequest updateCardToken)
        {
            Validate((Rule: IsInvalid(updateCardToken), Parameter: nameof(UpdateCardTokenRequest)));
        }

        private static void ValidateCreateTokenizedChargeNotNull(CreateTokenizedCharge updateCardToken)
        {
            if (updateCardToken is null)
            {
                throw new NullTokenizedChargeException();
            }
        }

        private static void ValidateUpdateUpdateCardTokenNotNull(UpdateCardToken updateCardToken)
        {
            if (updateCardToken is null)
            {
                throw new NullTokenizedChargeException();
            }
        }



        private static void ValidateCreateBulkTokenizedChargeNotNull(CreateBulkTokenizedCharge updateCardToken)
        {
            if (updateCardToken is null)
            {
                throw new NullTokenizedChargeException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateBulkTokenizedStatusId(int bulkId) =>
            Validate((Rule: IsInvalid(bulkId), Parameter: nameof(BulkTokenizedStatus)));

        private static void ValidateFetchBulkTokenizedChargeId(int bulkId) =>
            Validate((Rule: IsInvalid(bulkId), Parameter: nameof(FetchBulkTokenizedCharge)));

        private static void ValidateUpdateCardTokenId(string token) =>
           Validate((Rule: IsInvalid(token), Parameter: nameof(UpdateCardToken)));


        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };
        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidVirtualCardException = new InvalidTokenizedChargeException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidVirtualCardException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidVirtualCardException.ThrowIfContainsErrors();
        }
    }
}
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService
{
    internal partial class VirtualCardsService
    {


        private static void ValidateCreateVirtualCard(CreateVirtualCard createVirtualCard)
        {
            ValidateCreateVirtualCardNotNull(createVirtualCard);
            ValidateCreateVirtualCardRequestNotNull(createVirtualCard.Request);
            Validate(
                (Rule: IsInvalid(createVirtualCard), Parameter: nameof(createVirtualCard)));

            Validate(
                (Rule: IsInvalid(createVirtualCard.Request.Currency), Parameter: nameof(CreateVirtualCardRequest.Currency)),
                (Rule: IsInvalid(createVirtualCard.Request.Amount), Parameter: nameof(CreateVirtualCardRequest.Amount)),
                (Rule: IsInvalid(createVirtualCard.Request.FirstName), Parameter: nameof(CreateVirtualCardRequest.FirstName)),
                (Rule: IsInvalid(createVirtualCard.Request.LastName), Parameter: nameof(CreateVirtualCardRequest.LastName)),
                (Rule: IsInvalid(createVirtualCard.Request.Email), Parameter: nameof(CreateVirtualCardRequest.Email)),
                (Rule: IsInvalid(createVirtualCard.Request.Phone), Parameter: nameof(CreateVirtualCardRequest.Phone)),
                (Rule: IsInvalid(createVirtualCard.Request.Title), Parameter: nameof(CreateVirtualCardRequest.Title)),
                (Rule: IsInvalid(createVirtualCard.Request.Gender), Parameter: nameof(CreateVirtualCardRequest.Gender)),
                (Rule: IsInvalid(createVirtualCard.Request.DateOfBirth), Parameter: nameof(CreateVirtualCardRequest.DateOfBirth))

                );

        }

        private static void ValidateVirtualCardWithdrawal(string virtualCardId, VirtualCardWithdrawal virtualCardWithdrawal)
        {
            ValidateVirtualCardWithdrawalNotNull(virtualCardWithdrawal);
            ValidateVirtualCardWithdrawalRequestNotNull(virtualCardWithdrawal.Request);
            Validate(
                (Rule: IsInvalid(virtualCardWithdrawal), Parameter: nameof(virtualCardWithdrawal)));

            Validate(
                (Rule: IsInvalid(virtualCardWithdrawal.Request.Amount), Parameter: nameof(VirtualCardWithdrawalRequest.Amount)),
               (Rule: IsInvalid(virtualCardId), Parameter: nameof(VirtualCardWithdrawal))
                );

        }

        private static void ValidateFundVirtualCard(string virtualCardId, FundVirtualCard virtualCards)
        {
            ValidateUpdateVirtualCardNotNull(virtualCards);
            ValidateUpdateVirtualCardRequestNotNull(virtualCards.Request);


            Validate(
                (Rule: IsInvalid(virtualCards), Parameter: nameof(virtualCards)));

            Validate(
                (Rule: IsInvalid(virtualCards.Request.DebitCurrency), Parameter: nameof(FundVirtualCardRequest.DebitCurrency)),
                (Rule: IsInvalid(virtualCardId), Parameter: nameof(FundVirtualCard)),
                (Rule: IsInvalid(virtualCards.Request.Amount), Parameter: nameof(FundVirtualCardRequest.Amount))
                );

        }



        private static void ValidateVirtualCardWithdrawalRequestNotNull(VirtualCardWithdrawalRequest virtualCards)
        {
            Validate((Rule: IsInvalid(virtualCards), Parameter: nameof(VirtualCardWithdrawalRequest)));
        }
        private static void ValidateCreateVirtualCardRequestNotNull(CreateVirtualCardRequest virtualCards)
        {
            Validate((Rule: IsInvalid(virtualCards), Parameter: nameof(CreateVirtualCardRequest)));
        }

        private static void ValidateUpdateVirtualCardRequestNotNull(FundVirtualCardRequest virtualCards)
        {
            Validate((Rule: IsInvalid(virtualCards), Parameter: nameof(FundVirtualCardRequest)));
        }

        private static void ValidateCreateVirtualCardNotNull(CreateVirtualCard virtualCards)
        {
            if (virtualCards is null)
            {
                throw new NullVirtualCardsException();
            }
        }

        private static void ValidateUpdateVirtualCardNotNull(FundVirtualCard virtualCards)
        {
            if (virtualCards is null)
            {
                throw new NullVirtualCardsException();
            }
        }



        private static void ValidateVirtualCardWithdrawalNotNull(VirtualCardWithdrawal virtualCards)
        {
            if (virtualCards is null)
            {
                throw new NullVirtualCardsException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateFetchVirtualCardId(string virtualCardText) =>
            Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(FetchVirtualCard)));

        private static void ValidateVirtualCardWithdrawalId(string virtualCardText) =>
            Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(VirtualCardWithdrawalRequest)));
        private static void ValidateTerminateVirtualCardId(string virtualCardText) =>
        Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(TerminateVirtualCard)));

        private static void ValidateFundVirtualCardId(string virtualCardText) =>
       Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(FundVirtualCardRequest)));

        private static void ValidateBlockUnblockVirtualCardId(string virtualCardText) =>
       Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(BlockUnblockVirtualCard)));

        private static void ValidateVirtualCardTransactionsId(string virtualCardText) =>
       Validate((Rule: IsInvalid(virtualCardText), Parameter: nameof(VirtualCardTransactions)));



        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };
        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidVirtualCardException = new InvalidVirtualCardsException();

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
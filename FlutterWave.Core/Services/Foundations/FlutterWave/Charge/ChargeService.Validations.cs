using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService
{
    internal partial class ChargeService
    {


        private static void ValidateBankTransfer(BankTransfer bankTransfer)
        {
            ValidateBankTransferNotNull(bankTransfer);
            ValidateBankTransferRequestNotNull(bankTransfer.Request);
            Validate(
                (Rule: IsInvalid(bankTransfer), Parameter: nameof(bankTransfer)));

            Validate(
                (Rule: IsInvalid(bankTransfer.Request.Amount), Parameter: nameof(BankTransferRequest.PhoneNumber)),
                (Rule: IsInvalid(bankTransfer.Request.TxRef), Parameter: nameof(BankTransferRequest.TxRef)),
                (Rule: IsInvalid(bankTransfer.Request.Amount), Parameter: nameof(BankTransferRequest.Amount)),
                (Rule: IsInvalid(bankTransfer.Request.Email), Parameter: nameof(BankTransferRequest.Email))
                );
        }
        private static void ValidateCharge(ValidateCharge validateCharge)
        {
            ValidateChargeNotNull(validateCharge);
            ValidateChargeRequestNotNull(validateCharge.Request);
            Validate(
                (Rule: IsInvalid(validateCharge), Parameter: nameof(validateCharge)));

            Validate(
                (Rule: IsInvalid(validateCharge.Request.Otp), Parameter: nameof(ValidateChargeRequest.Otp)),
                (Rule: IsInvalid(validateCharge.Request.FlwRef), Parameter: nameof(ValidateChargeRequest.FlwRef)),
                (Rule: IsInvalid(validateCharge.Request.Type), Parameter: nameof(ValidateChargeRequest.Type))


                );

        }
        private static void ValidateCardCharge(CardCharge cardCharge)
        {
            ValidateCardChargeNotNull(cardCharge);
            ValidateCardChargeRequestNotNull(cardCharge.Request);


            Validate(
                (Rule: IsInvalid(cardCharge), Parameter: nameof(cardCharge)));

            Validate(
                (Rule: IsInvalid(cardCharge.Request.Amount), Parameter: nameof(CardChargeRequest.Amount)),
                (Rule: IsInvalid(cardCharge.Request.CardNumber), Parameter: nameof(CardChargeRequest.CardNumber)),
                (Rule: IsInvalid(cardCharge.Request.Cvv), Parameter: nameof(CardChargeRequest.Cvv)),
                (Rule: IsInvalid(cardCharge.Request.ExpiryMonth), Parameter: nameof(CardChargeRequest.ExpiryMonth)),
                (Rule: IsInvalid(cardCharge.Request.ExpiryYear), Parameter: nameof(CardChargeRequest.ExpiryYear)),
                (Rule: IsInvalid(cardCharge.Request.Email), Parameter: nameof(CardChargeRequest.Email)),
                (Rule: IsInvalid(cardCharge.Request.TxRef), Parameter: nameof(CardChargeRequest.TxRef))

                );

        }
        private static void ValidateNGBankAccount(NGBankAccounts nGBankAccounts)
        {
            ValidateNGBankAccountsNotNull(nGBankAccounts);
            ValidateNGAccountsRequestNotNull(nGBankAccounts.Request);


            Validate(
                (Rule: IsInvalid(nGBankAccounts), Parameter: nameof(nGBankAccounts)));

            Validate(
                (Rule: IsInvalid(nGBankAccounts.Request.Amount), Parameter: nameof(NGBankAccountsRequest.Amount)),
                (Rule: IsInvalid(nGBankAccounts.Request.Email), Parameter: nameof(NGBankAccountsRequest.Email)),
                (Rule: IsInvalid(nGBankAccounts.Request.TxRef), Parameter: nameof(NGBankAccountsRequest.TxRef))


                );

        }
        private static void ValidateMpesa(Mpesa mpesa)
        {
            ValidateMpesaNotNull(mpesa);
            ValidateMpesaRequestNotNull(mpesa.Request);


            Validate(
                (Rule: IsInvalid(mpesa), Parameter: nameof(mpesa)));

            Validate(
                (Rule: IsInvalid(mpesa.Request.Amount), Parameter: nameof(MpesaRequest.Amount)),
                (Rule: IsInvalid(mpesa.Request.Email), Parameter: nameof(MpesaRequest.Email)),
                (Rule: IsInvalid(mpesa.Request.TxRef), Parameter: nameof(MpesaRequest.TxRef)),
                (Rule: IsInvalid(mpesa.Request.Currency), Parameter: nameof(MpesaRequest.Currency)),
                (Rule: IsInvalid(mpesa.Request.PhoneNumber), Parameter: nameof(MpesaRequest.PhoneNumber))


                );

        }
        private static void ValidateGhanaMobileMoney(GhanaMobileMoney ghanaMobileMoney)
        {
            ValidateGhanaMobileMoneyNotNull(ghanaMobileMoney);
            ValidateGhanaMobileMoneyRequestNotNull(ghanaMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(ghanaMobileMoney), Parameter: nameof(ghanaMobileMoney)));

            Validate(
                (Rule: IsInvalid(ghanaMobileMoney.Request.Amount), Parameter: nameof(GhanaMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(ghanaMobileMoney.Request.Email), Parameter: nameof(GhanaMobileMoneyRequest.Email)),
                (Rule: IsInvalid(ghanaMobileMoney.Request.TxRef), Parameter: nameof(GhanaMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(ghanaMobileMoney.Request.Currency), Parameter: nameof(GhanaMobileMoneyRequest.Currency)),
                (Rule: IsInvalid(ghanaMobileMoney.Request.PhoneNumber), Parameter: nameof(GhanaMobileMoneyRequest.PhoneNumber)),
                (Rule: IsInvalid(ghanaMobileMoney.Request.Network), Parameter: nameof(GhanaMobileMoneyRequest.Network))

                );

        }
        private static void ValidateZambiaMobileMoney(ZambiaMobileMoney zambiaMobileMoney)
        {
            ValidateZambiaMobileMoneyNotNull(zambiaMobileMoney);
            ValidateZambiaMobileMoneyRequestNotNull(zambiaMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(zambiaMobileMoney), Parameter: nameof(zambiaMobileMoney)));

            Validate(
                (Rule: IsInvalid(zambiaMobileMoney.Request.Amount), Parameter: nameof(ZambiaMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(zambiaMobileMoney.Request.Email), Parameter: nameof(ZambiaMobileMoneyRequest.Email)),
                (Rule: IsInvalid(zambiaMobileMoney.Request.TxRef), Parameter: nameof(ZambiaMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(zambiaMobileMoney.Request.Currency), Parameter: nameof(ZambiaMobileMoneyRequest.Currency)),
                (Rule: IsInvalid(zambiaMobileMoney.Request.PhoneNumber), Parameter: nameof(ZambiaMobileMoneyRequest.PhoneNumber)),
                (Rule: IsInvalid(zambiaMobileMoney.Request.Network), Parameter: nameof(ZambiaMobileMoneyRequest.Network))

                );

        }
        private static void ValidateUgandaMobileMoney(UgandaMobileMoney ugandaMobileMoney)
        {
            ValidateUgandaMobileMoneyNotNull(ugandaMobileMoney);
            ValidateUgandaMobileMoneyRequestNotNull(ugandaMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(ugandaMobileMoney), Parameter: nameof(ugandaMobileMoney)));

            Validate(
                (Rule: IsInvalid(ugandaMobileMoney.Request.Amount), Parameter: nameof(UgandaMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(ugandaMobileMoney.Request.Email), Parameter: nameof(UgandaMobileMoneyRequest.Email)),
                (Rule: IsInvalid(ugandaMobileMoney.Request.TxRef), Parameter: nameof(UgandaMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(ugandaMobileMoney.Request.Currency), Parameter: nameof(UgandaMobileMoneyRequest.Currency)),
                (Rule: IsInvalid(ugandaMobileMoney.Request.PhoneNumber), Parameter: nameof(UgandaMobileMoneyRequest.PhoneNumber))


                );

        }
        private static void ValidateTanzaniaMobileMoney(TanzaniaMobileMoney tanzaniaMobileMoney)
        {
            ValidateTanzaniaMobileMoneyNotNull(tanzaniaMobileMoney);
            ValidateTanzaniaMobileMoneyRequestNotNull(tanzaniaMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(tanzaniaMobileMoney), Parameter: nameof(tanzaniaMobileMoney)));

            Validate(
                (Rule: IsInvalid(tanzaniaMobileMoney.Request.Amount), Parameter: nameof(TanzaniaMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(tanzaniaMobileMoney.Request.Email), Parameter: nameof(TanzaniaMobileMoneyRequest.Email)),
                (Rule: IsInvalid(tanzaniaMobileMoney.Request.TxRef), Parameter: nameof(TanzaniaMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(tanzaniaMobileMoney.Request.Currency), Parameter: nameof(TanzaniaMobileMoneyRequest.Currency)),
                (Rule: IsInvalid(tanzaniaMobileMoney.Request.PhoneNumber), Parameter: nameof(TanzaniaMobileMoneyRequest.PhoneNumber))


                );

        }
        private static void ValidateFrancophoneMobileMoney(FrancophoneMobileMoney francophoneMobileMoney)
        {
            ValidateFrancophoneMobileMoneyNotNull(francophoneMobileMoney);
            ValidateFrancophoneMobileMoneyRequestNotNull(francophoneMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(francophoneMobileMoney), Parameter: nameof(francophoneMobileMoney)));

            Validate(
                (Rule: IsInvalid(francophoneMobileMoney.Request.Amount), Parameter: nameof(FrancophoneMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(francophoneMobileMoney.Request.Email), Parameter: nameof(FrancophoneMobileMoneyRequest.Email)),
                (Rule: IsInvalid(francophoneMobileMoney.Request.TxRef), Parameter: nameof(FrancophoneMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(francophoneMobileMoney.Request.Currency), Parameter: nameof(FrancophoneMobileMoneyRequest.Currency)),
                (Rule: IsInvalid(francophoneMobileMoney.Request.PhoneNumber), Parameter: nameof(FrancophoneMobileMoneyRequest.PhoneNumber))


                );

        }
        private static void ValidateFawry(Fawry fawry)
        {
            ValidateFawryNotNull(fawry);
            ValidateFawryRequestNotNull(fawry.Request);


            Validate(
                (Rule: IsInvalid(fawry), Parameter: nameof(fawry)));

            Validate(
                (Rule: IsInvalid(fawry.Request.Amount), Parameter: nameof(FawryRequest.Amount)),
                (Rule: IsInvalid(fawry.Request.Email), Parameter: nameof(FawryRequest.Email)),
                (Rule: IsInvalid(fawry.Request.TxRef), Parameter: nameof(FawryRequest.TxRef)),
                (Rule: IsInvalid(fawry.Request.Currency), Parameter: nameof(FawryRequest.Currency)),
                (Rule: IsInvalid(fawry.Request.PhoneNumber), Parameter: nameof(FawryRequest.PhoneNumber))


                );

        }
        private static void ValidateApplePay(ApplePay applePay)
        {
            ValidateApplePayNotNull(applePay);
            ValidateApplePayRequestNotNull(applePay.Request);


            Validate(
                (Rule: IsInvalid(applePay), Parameter: nameof(applePay)));

            Validate(
                (Rule: IsInvalid(applePay.Request.Amount), Parameter: nameof(ApplePayRequest.Amount)),
                (Rule: IsInvalid(applePay.Request.Email), Parameter: nameof(ApplePayRequest.Email)),
                (Rule: IsInvalid(applePay.Request.TxRef), Parameter: nameof(ApplePayRequest.TxRef)),
                (Rule: IsInvalid(applePay.Request.Currency), Parameter: nameof(ApplePayRequest.Currency)),
                (Rule: IsInvalid(applePay.Request.PhoneNumber), Parameter: nameof(ApplePayRequest.PhoneNumber))


                );

        }
        private static void ValidateGooglePay(GooglePay googlePay)
        {
            ValidateGooglePayNotNull(googlePay);
            ValidateGooglePayRequestNotNull(googlePay.Request);


            Validate(
                (Rule: IsInvalid(googlePay), Parameter: nameof(googlePay)));

            Validate(
                (Rule: IsInvalid(googlePay.Request.Amount), Parameter: nameof(GooglePayRequest.Amount)),
                (Rule: IsInvalid(googlePay.Request.Email), Parameter: nameof(GooglePayRequest.Email)),
                (Rule: IsInvalid(googlePay.Request.TxRef), Parameter: nameof(GooglePayRequest.TxRef)),
                (Rule: IsInvalid(googlePay.Request.Currency), Parameter: nameof(GooglePayRequest.Currency))



                );

        }
        private static void ValidatePayPal(PayPal payPal)
        {
            ValidatePayPalNotNull(payPal);
            ValidatePayPalRequestNotNull(payPal.Request);


            Validate(
                (Rule: IsInvalid(payPal), Parameter: nameof(payPal)));

            Validate(
                (Rule: IsInvalid(payPal.Request.Amount), Parameter: nameof(PayPalRequest.Amount)),
                (Rule: IsInvalid(payPal.Request.Email), Parameter: nameof(PayPalRequest.Email)),
                (Rule: IsInvalid(payPal.Request.TxRef), Parameter: nameof(PayPalRequest.TxRef)),
                (Rule: IsInvalid(payPal.Request.Currency), Parameter: nameof(PayPalRequest.Currency))



                );

        }
        private static void ValidateUSSD(USSD uSSD)
        {
            ValidateUSSDNotNull(uSSD);
            ValidateUSSDRequestNotNull(uSSD.Request);


            Validate(
                (Rule: IsInvalid(uSSD), Parameter: nameof(uSSD)));

            Validate(
                (Rule: IsInvalid(uSSD.Request.Amount), Parameter: nameof(USSDRequest.Amount)),
                (Rule: IsInvalid(uSSD.Request.Email), Parameter: nameof(USSDRequest.Email)),
                (Rule: IsInvalid(uSSD.Request.TxRef), Parameter: nameof(USSDRequest.TxRef)),
                (Rule: IsInvalid(uSSD.Request.Currency), Parameter: nameof(USSDRequest.Currency))



                );

        }
        private static void ValidateENaira(ENaira eNaira)
        {
            ValidateENairaNotNull(eNaira);
            ValidateENairaRequestNotNull(eNaira.Request);


            Validate(
                (Rule: IsInvalid(eNaira), Parameter: nameof(eNaira)));

            Validate(
                (Rule: IsInvalid(eNaira.Request.Amount), Parameter: nameof(ENairaRequest.Amount)),
                (Rule: IsInvalid(eNaira.Request.Email), Parameter: nameof(ENairaRequest.Email)),
                (Rule: IsInvalid(eNaira.Request.TxRef), Parameter: nameof(ENairaRequest.TxRef)),
                (Rule: IsInvalid(eNaira.Request.Currency), Parameter: nameof(ENairaRequest.Currency))



                );

        }
        private static void ValidateACHPayments(ACHPayments aCHPayments)
        {
            ValidateACHPaymentsNotNull(aCHPayments);
            ValidateACHPaymentsRequestNotNull(aCHPayments.Request);


            Validate(
                (Rule: IsInvalid(aCHPayments), Parameter: nameof(aCHPayments)));

            Validate(
                (Rule: IsInvalid(aCHPayments.Request.Amount), Parameter: nameof(ACHPaymentsRequest.Amount)),
                (Rule: IsInvalid(aCHPayments.Request.Email), Parameter: nameof(ACHPaymentsRequest.Email)),
                (Rule: IsInvalid(aCHPayments.Request.TxRef), Parameter: nameof(ACHPaymentsRequest.TxRef)),
                (Rule: IsInvalid(aCHPayments.Request.Currency), Parameter: nameof(ACHPaymentsRequest.Currency))



                );

        }
        private static void ValidateUkEuBankAccounts(UkEuBankAccounts ukEuBankAccounts)
        {
            ValidateUkEuBankAccountsNotNull(ukEuBankAccounts);
            ValidateUkEuBankAccountsRequestNotNull(ukEuBankAccounts.Request);


            Validate(
                (Rule: IsInvalid(ukEuBankAccounts), Parameter: nameof(ukEuBankAccounts)));

            Validate(
                (Rule: IsInvalid(ukEuBankAccounts.Request.Amount), Parameter: nameof(UkEuBankAccountsRequest.Amount)),
                (Rule: IsInvalid(ukEuBankAccounts.Request.Email), Parameter: nameof(UkEuBankAccountsRequest.Email)),
                (Rule: IsInvalid(ukEuBankAccounts.Request.TxRef), Parameter: nameof(UkEuBankAccountsRequest.TxRef)),
                (Rule: IsInvalid(ukEuBankAccounts.Request.Currency), Parameter: nameof(UkEuBankAccountsRequest.Currency))



                );

        }
        private static void ValidateRwandaMobileMoney(RwandaMobileMoney rwandaMobileMoney)
        {
            ValidateRwandaMobileMoneyNotNull(rwandaMobileMoney);
            ValidateRwandaMobileMoneyRequestNotNull(rwandaMobileMoney.Request);


            Validate(
                (Rule: IsInvalid(rwandaMobileMoney), Parameter: nameof(rwandaMobileMoney)));

            Validate(
                (Rule: IsInvalid(rwandaMobileMoney.Request.Amount), Parameter: nameof(RwandaMobileMoneyRequest.Amount)),
                (Rule: IsInvalid(rwandaMobileMoney.Request.Email), Parameter: nameof(RwandaMobileMoneyRequest.Email)),
                (Rule: IsInvalid(rwandaMobileMoney.Request.TxRef), Parameter: nameof(RwandaMobileMoneyRequest.TxRef)),
                (Rule: IsInvalid(rwandaMobileMoney.Request.Currency), Parameter: nameof(RwandaMobileMoneyRequest.Currency))



                );

        }




        private static void ValidateChargeRequestNotNull(ValidateChargeRequest validateCharge)
        {
            Validate((Rule: IsInvalid(validateCharge), Parameter: nameof(ValidateChargeRequest)));
        }
        private static void ValidateBankTransferRequestNotNull(BankTransferRequest bankTransfer)
        {
            Validate((Rule: IsInvalid(bankTransfer), Parameter: nameof(BankTransferRequest)));
        }
        private static void ValidateCardChargeRequestNotNull(CardChargeRequest cardCharge)
        {
            Validate((Rule: IsInvalid(cardCharge), Parameter: nameof(CardChargeRequest)));
        }
        private static void ValidateNGAccountsRequestNotNull(NGBankAccountsRequest nGBankAccounts)
        {
            Validate((Rule: IsInvalid(nGBankAccounts), Parameter: nameof(NGBankAccountsRequest)));
        }
        private static void ValidateMpesaRequestNotNull(MpesaRequest mpesaRequest)
        {
            Validate((Rule: IsInvalid(mpesaRequest), Parameter: nameof(MpesaRequest)));
        }
        private static void ValidateGhanaMobileMoneyRequestNotNull(GhanaMobileMoneyRequest ghanaMobileMoney)
        {
            Validate((Rule: IsInvalid(ghanaMobileMoney), Parameter: nameof(GhanaMobileMoneyRequest)));
        }
        private static void ValidateZambiaMobileMoneyRequestNotNull(ZambiaMobileMoneyRequest zambiaMobileMoney)
        {
            Validate((Rule: IsInvalid(zambiaMobileMoney), Parameter: nameof(ZambiaMobileMoneyRequest)));
        }
        private static void ValidateUgandaMobileMoneyRequestNotNull(UgandaMobileMoneyRequest ugandaMobileMoney)
        {
            Validate((Rule: IsInvalid(ugandaMobileMoney), Parameter: nameof(UgandaMobileMoneyRequest)));
        }
        private static void ValidateTanzaniaMobileMoneyRequestNotNull(TanzaniaMobileMoneyRequest tanzaniaMobileMoney)
        {
            Validate((Rule: IsInvalid(tanzaniaMobileMoney), Parameter: nameof(TanzaniaMobileMoneyRequest)));
        }
        private static void ValidateFrancophoneMobileMoneyRequestNotNull(FrancophoneMobileMoneyRequest francophoneMobileMoney)
        {
            Validate((Rule: IsInvalid(francophoneMobileMoney), Parameter: nameof(FrancophoneMobileMoneyRequest)));
        }
        private static void ValidateFawryRequestNotNull(FawryRequest fawry)
        {
            Validate((Rule: IsInvalid(fawry), Parameter: nameof(FawryRequest)));
        }
        private static void ValidateApplePayRequestNotNull(ApplePayRequest applePay)
        {
            Validate((Rule: IsInvalid(applePay), Parameter: nameof(ApplePayRequest)));
        }
        private static void ValidateGooglePayRequestNotNull(GooglePayRequest googlePay)
        {
            Validate((Rule: IsInvalid(googlePay), Parameter: nameof(GooglePayRequest)));
        }
        private static void ValidatePayPalRequestNotNull(PayPalRequest payPal)
        {
            Validate((Rule: IsInvalid(payPal), Parameter: nameof(PayPalRequest)));
        }
        private static void ValidateUSSDRequestNotNull(USSDRequest uSSD)
        {
            Validate((Rule: IsInvalid(uSSD), Parameter: nameof(USSDRequest)));
        }
        private static void ValidateENairaRequestNotNull(ENairaRequest eNaira)
        {
            Validate((Rule: IsInvalid(eNaira), Parameter: nameof(ENairaRequest)));
        }
        private static void ValidateACHPaymentsRequestNotNull(ACHPaymentsRequest aCHPayments)
        {
            Validate((Rule: IsInvalid(aCHPayments), Parameter: nameof(ACHPaymentsRequest)));
        }
        private static void ValidateUkEuBankAccountsRequestNotNull(UkEuBankAccountsRequest ukEuBankAccounts)
        {
            Validate((Rule: IsInvalid(ukEuBankAccounts), Parameter: nameof(UkEuBankAccountsRequest)));
        }
        private static void ValidateRwandaMobileMoneyRequestNotNull(RwandaMobileMoneyRequest rwandaMobileMoney)
        {
            Validate((Rule: IsInvalid(rwandaMobileMoney), Parameter: nameof(RwandaMobileMoneyRequest)));
        }




        private static void ValidateBankTransferNotNull(BankTransfer bankTransfer)
        {
            if (bankTransfer is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateCardChargeNotNull(CardCharge cardCharge)
        {
            if (cardCharge is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateNGBankAccountsNotNull(NGBankAccounts nGBankAccounts)
        {
            if (nGBankAccounts is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateChargeNotNull(ValidateCharge validateCharge)
        {
            if (validateCharge is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateMpesaNotNull(Mpesa mpesa)
        {
            if (mpesa is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateGhanaMobileMoneyNotNull(GhanaMobileMoney ghanaMobileMoney)
        {
            if (ghanaMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateZambiaMobileMoneyNotNull(ZambiaMobileMoney zambiaMobileMoney)
        {
            if (zambiaMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateUgandaMobileMoneyNotNull(UgandaMobileMoney ugandaMobileMoney)
        {
            if (ugandaMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateTanzaniaMobileMoneyNotNull(TanzaniaMobileMoney tanzaniaMobileMoney)
        {
            if (tanzaniaMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateFrancophoneMobileMoneyNotNull(FrancophoneMobileMoney francophoneMobileMoney)
        {
            if (francophoneMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateFawryNotNull(Fawry fawry)
        {
            if (fawry is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateApplePayNotNull(ApplePay applePay)
        {
            if (applePay is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateGooglePayNotNull(GooglePay googlePay)
        {
            if (googlePay is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidatePayPalNotNull(PayPal payPal)
        {
            if (payPal is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateUSSDNotNull(USSD uSSD)
        {
            if (uSSD is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateENairaNotNull(ENaira eNaira)
        {
            if (eNaira is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateACHPaymentsNotNull(ACHPayments aCHPayments)
        {
            if (aCHPayments is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateUkEuBankAccountsNotNull(UkEuBankAccounts ukEuBankAccounts)
        {
            if (ukEuBankAccounts is null)
            {
                throw new NullChargeException();
            }
        }
        private static void ValidateRwandaMobileMoneyNotNull(RwandaMobileMoney rwandaMobileMoney)
        {
            if (rwandaMobileMoney is null)
            {
                throw new NullChargeException();
            }
        }


        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };
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
            var invalidVirtualAccountException = new InvalidChargeException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidVirtualAccountException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidVirtualAccountException.ThrowIfContainsErrors();
        }
    }
}
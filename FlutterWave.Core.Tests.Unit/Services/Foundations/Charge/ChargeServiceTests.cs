using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IChargeService chargeService;

        public ChargeServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.chargeService = new ChargeService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }



        private Expression<Func<ExternalACHPaymentsRequest, bool>> SameExternalACHPaymentsRequestAs(
            ExternalACHPaymentsRequest expectedExternalACHPaymentsRequest)
        {
            return actualExternalACHPaymentsRequest =>
                this.compareLogic.Compare(
                    expectedExternalACHPaymentsRequest,
                    actualExternalACHPaymentsRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalBankTransferRequest, bool>> SameExternalBankTransferRequestAs(
              ExternalBankTransferRequest expectedExternalBankTransferRequest)
        {
            return actualExternalBankTransferRequest =>
                this.compareLogic.Compare(
                    expectedExternalBankTransferRequest,
                    actualExternalBankTransferRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalEncryptedChargeRequest, bool>> SameExternalEncryptedChargeRequestAs(
              ExternalEncryptedChargeRequest expectedExternalEncryptedChargeRequest)
        {
            return actualExternalEncryptedChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalEncryptedChargeRequest,
                    actualExternalEncryptedChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalApplePayRequest, bool>> SameExternalApplePayRequestAs(
                ExternalApplePayRequest expectedExternalApplePayRequest)
        {
            return actualExternalApplePayRequest =>
                this.compareLogic.Compare(
                    expectedExternalApplePayRequest,
                    actualExternalApplePayRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalENairaRequest, bool>> SameExternalENairaRequestAs(
              ExternalENairaRequest expectedExternalENairaRequest)
        {
            return actualExternalENairaRequest =>
                this.compareLogic.Compare(
                    expectedExternalENairaRequest,
                    actualExternalENairaRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalFawryRequest, bool>> SameExternalFawryRequestAs(
              ExternalFawryRequest expectedExternalFawryRequest)
        {
            return actualExternalFawryRequest =>
                this.compareLogic.Compare(
                    expectedExternalFawryRequest,
                    actualExternalFawryRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalFrancophoneMobileMoneyRequest, bool>> SameExternalFrancophoneMobileMoneyRequestAs(
              ExternalFrancophoneMobileMoneyRequest expectedExternalFrancophoneMobileMoneyRequest)
        {
            return actualExternalFrancophoneMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalFrancophoneMobileMoneyRequest,
                    actualExternalFrancophoneMobileMoneyRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalGhanaMobileMoneyRequest, bool>> SameExternalGhanaMobileMoneyRequestAs(
              ExternalGhanaMobileMoneyRequest expectedExternalGhanaMobileMoneyRequest)
        {
            return actualExternalGhanaMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalGhanaMobileMoneyRequest,
                    actualExternalGhanaMobileMoneyRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalGooglePayRequest, bool>> SameExternalGooglePayRequestAs(
              ExternalGooglePayRequest expectedExternalGooglePayRequest)
        {
            return actualExternalGooglePayRequest =>
                this.compareLogic.Compare(
                    expectedExternalGooglePayRequest,
                    actualExternalGooglePayRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalMpesaRequest, bool>> SameExternalMpesaRequestAs(
              ExternalMpesaRequest expectedExternalMpesaRequest)
        {
            return actualExternalMpesaRequest =>
                this.compareLogic.Compare(
                    expectedExternalMpesaRequest,
                    actualExternalMpesaRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalNGBankAccountsRequest, bool>> SameExternalNGBankAccountsRequestAs(
              ExternalNGBankAccountsRequest expectedExternalNGBankAccountsRequest)
        {
            return actualExternalNGBankAccountsRequest =>
                this.compareLogic.Compare(
                    expectedExternalNGBankAccountsRequest,
                    actualExternalNGBankAccountsRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalPayPalRequest, bool>> SameExternalPayPalRequestAs(
              ExternalPayPalRequest expectedExternalPayPalRequest)
        {
            return actualExternalPayPalRequest =>
                this.compareLogic.Compare(
                    expectedExternalPayPalRequest,
                    actualExternalPayPalRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalRwandaMobileMoneyRequest, bool>> SameExternalRwandaMobileMoneyRequestAs(
              ExternalRwandaMobileMoneyRequest expectedExternalRwandaMobileMoneyRequest)
        {
            return actualExternalRwandaMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalRwandaMobileMoneyRequest,
                    actualExternalRwandaMobileMoneyRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalTanzaniaMobileMoneyRequest, bool>> SameExternalTanzaniaMobileMoneyRequestAs(
              ExternalTanzaniaMobileMoneyRequest expectedExternalTanzaniaMobileMoneyRequest)
        {
            return actualExternalTanzaniaMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalTanzaniaMobileMoneyRequest,
                    actualExternalTanzaniaMobileMoneyRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalUgandaMobileMoneyRequest, bool>> SameExternalUgandaMobileMoneyRequestAs(
              ExternalUgandaMobileMoneyRequest expectedExternalUgandaMobileMoneyRequest)
        {
            return actualExternalUgandaMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalUgandaMobileMoneyRequest,
                    actualExternalUgandaMobileMoneyRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalUkEuBankAccountsRequest, bool>> SameExternalUkEuBankAccountsRequestAs(
              ExternalUkEuBankAccountsRequest expectedExternalUkEuBankAccountsRequest)
        {
            return actualExternalUkEuBankAccountsRequest =>
                this.compareLogic.Compare(
                    expectedExternalUkEuBankAccountsRequest,
                    actualExternalUkEuBankAccountsRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalUSSDRequest, bool>> SameExternalUSSDRequestAs(
              ExternalUSSDRequest expectedExternalUSSDRequest)
        {
            return actualExternalUSSDRequest =>
                this.compareLogic.Compare(
                    expectedExternalUSSDRequest,
                    actualExternalUSSDRequest)
                        .AreEqual;
        }
        private Expression<Func<ExternalValidateChargeRequest, bool>> SameExternalValidateChargeRequestAs(
              ExternalValidateChargeRequest expectedExternalValidateChargeRequest)
        {
            return actualExternalValidateChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalValidateChargeRequest,
                    actualExternalValidateChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalZambiaMobileMoneyRequest, bool>> SameExternalZambiaMobileMoneyRequestAs(
              ExternalZambiaMobileMoneyRequest expectedExternalZambiaMobileMoneyRequest)
        {
            return actualExternalZambiaMobileMoneyRequest =>
                this.compareLogic.Compare(
                    expectedExternalZambiaMobileMoneyRequest,
                    actualExternalZambiaMobileMoneyRequest)
                        .AreEqual;
        }


        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static string GetRandomLengthyString() =>
          new MnemonicString(1, 24, 24).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();




        #region ACHPaymentRequestProperties

        private static dynamic CreateRandomACHPaymentsRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Country = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                RedirectUrl = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Meta = GetACHPaymentsMeta(),

            };
        }

        private static dynamic GetACHPaymentsMeta()
        {
            return new
            {


                FlightID = GetRandomString(),

            };
        }



        #endregion

        #region ACHPaymentsResponseProperties

        private static dynamic CreateRandomACHPaymentsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomACHPaymentsData()
            };
        }


        private static dynamic GetRandomACHPaymentsData()
        {

            return new
            {

                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                AuthUrl = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                RedirectUrl = GetRandomString(),
                Customer = GetRandomCustomer(),


            };

        }

        private static dynamic GetRandomCustomer()
        {

            return new
            {


                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),

            };

        }

        #endregion

        #region ApplePayRequestProperties

        private static dynamic CreateRandomApplePayRequestProperties()
        {
            return new
            {



                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                Fullname = GetRandomString(),
                Narration = GetRandomString(),
                RedirectUrl = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                BillingZip = GetRandomString(),
                BillingCity = GetRandomString(),
                BillingAddress = GetRandomString(),
                BillingState = GetRandomString(),
                BillingCountry = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Meta = GetApplePayMeta(),


            };
        }

        private static dynamic GetApplePayMeta()
        {
            return new
            {


                Metaname = GetRandomString(),
                Metavalue = GetRandomString(),

            };
        }

        #endregion

        #region ApplePayResponseProperties

        private static dynamic CreateRandomApplePayResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomApplePayData()
            };
        }


        private static dynamic GetRandomApplePayData()
        {

            return new
            {


                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomApplePayCustomer(),
                Meta = GetRandomApplePayMeta(),


            };



        }

        private static dynamic GetRandomApplePayCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),



            };
        }

        private static dynamic GetRandomApplePayAuthorization()
        {

            return new
            {

                Mode = GetRandomString(),
                Redirect = GetRandomString(),





            };

        }

        private static dynamic GetRandomApplePayMeta()
        {

            return new
            {


                Authorization = GetRandomApplePayAuthorization(),


            };

        }


        #endregion

        #region BankTransferRequestProperties

        private static dynamic CreateRandomBankTransferRequestProperties()
        {
            return new
            {

                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Currency = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Narration = GetRandomString(),
                IsPermanent = GetRandomBoolean(),


            };
        }



        #endregion

        #region BankTransferPayResponseProperties

        private static dynamic CreateRandomBankTransferResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomBankTransferResponseMeta()
            };
        }

        private static dynamic GetRandomBankTransferResponseAuthorization()
        {

            return new
            {

                TransferReference = GetRandomString(),
                TransferAccount = GetRandomString(),
                TransferBank = GetRandomString(),
                AccountExpiration = GetRandomString(),
                TransferNote = GetRandomString(),
                TransferAmount = GetRandomString(),
                Mode = GetRandomString(),
            };
        }

        private static dynamic GetRandomBankTransferResponseMeta()
        {

            return new
            {
                Authorization = GetRandomBankTransferResponseAuthorization(),
            };

        }


        #endregion

        #region CardChargeRequestProperties

        private static dynamic CreateRandomCardChargeRequestProperties()
        {
            return new
            {

                CardNumber = GetRandomString(),
                Cvv = GetRandomString(),
                ExpiryMonth = GetRandomNumber(),
                ExpiryYear = GetRandomNumber(),
                Amount = GetRandomNumber(),
                FullName = GetRandomString(),
                TxRef = GetRandomString(),
                Currency = GetRandomString(),
                Country = GetRandomString(),
                Email = GetRandomString(),
                RedirectUrl = GetRandomString(),
                Meta = GetRandomCreateChargeMeta(),
                Preauthorize = GetRandomBoolean(),
                PaymentPlan = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                ClientIp = GetRandomString(),
                Authorization = GetRandomAuthorizationData(),

            };
        }



        private static dynamic GetRandomAuthorizationData()
        {
            return new
            {
                Mode = GetRandomString(),
                Pin = GetRandomNumber(),
                City = GetRandomString(),
                Address = GetRandomString(),
                State = GetRandomString(),
                Country = GetRandomString(),
                ZipCode = GetRandomString(),



            };
        }

        private static dynamic GetRandomCreateChargeMeta()
        {
            return new
            {
                FlightId = GetRandomString(),
                SideNote = GetRandomString(),


            };
        }

        #endregion

        #region EncryptedChargeRequestProperties

        private static dynamic CreateRandomEncryptedChargeRequestProperties()
        {
            return new
            {

                Client = GetRandomLengthyString(),

            };
        }



        #endregion

        #region CardChargeResponseProperties

        private static dynamic CreateRandomCardChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCardChargeResponseData(),
                Meta = GetRandomCardChargeResponseMeta(),
            };
        }


        private static dynamic GetRandomCardChargeResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomCardChargeCustomer(),
                Card = GetRandomCardChargeCard(),



            };



        }

        private static dynamic GetRandomCardChargeCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = new object(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),
            };
        }

        private static dynamic GetRandomCardChargeCard()
        {

            return new
            {
                First6digits = GetRandomString(),
                Last4digits = GetRandomString(),
                Issuer = GetRandomString(),
                Country = GetRandomString(),
                Type = GetRandomString(),
                Expiry = GetRandomString(),
            };
        }

        private static dynamic GetRandomCardChargeResponseAuthorization()
        {

            return new
            {
                Mode = GetRandomString(),
                Endpoint = GetRandomString(),
            };

        }

        private static dynamic GetRandomCardChargeResponseMeta()
        {

            return new
            {
                Authorization = GetRandomCardChargeResponseAuthorization(),
            };

        }


        #endregion

        #region ENairaRequestProperties

        private static dynamic CreateRandomENairaRequestProperties()
        {
            return new
            {

                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                Fullname = GetRandomString(),
                PhoneNumber = GetRandomString(),
                RedirectUrl = GetRandomString(),




            };
        }



        #endregion

        #region ENairaResponseProperties

        private static dynamic CreateRandomENairaResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomApplePayData(),

            };
        }


        private static dynamic GetRandomENairaResponseData()
        {

            return new
            {


                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomENairaCustomer(),
                Meta = GetRandomENairaResponseMeta(),

            };



        }

        private static dynamic GetRandomENairaCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }


        private static dynamic GetRandomENairaResponseAuthorization()
        {

            return new
            {
                Mode = GetRandomString(),
                Redirect = GetRandomString(),
            };

        }

        private static dynamic GetRandomENairaResponseMeta()
        {

            return new
            {


                Authorization = GetRandomENairaResponseAuthorization(),


            };

        }


        #endregion

        #region FawryRequestProperties

        private static dynamic CreateRandomFawryRequestProperties()
        {
            return new
            {

                Name = GetRandomString(),
                Tools = GetRandomString(),
                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Email = GetRandomString(),
                Currency = GetRandomString(),
                PhoneNumber = GetRandomString(),
                RedirectUrl = GetRandomString(),
                Meta = GetRandomFawryMeta(),





            };
        }

        private static dynamic GetRandomFawryMeta()
        {
            return new
            {

                Name = GetRandomString(),
                Tools = GetRandomString(),

            };
        }


        #endregion

        #region FawryResponseProperties

        private static dynamic CreateRandomFawryResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFawryResponseData(),
                Meta = GetRandomFawryResponseMeta()

            };
        }


        private static dynamic GetRandomFawryResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                OrderRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                Currency = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomFawryCustomer(),


            };



        }

        private static dynamic GetRandomFawryCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }


        private static dynamic GetRandomFawryResponseAuthorization()
        {
            return new
            {
                Mode = GetRandomString(),
                Instruction = GetRandomString(),
            };
        }

        private static dynamic GetRandomFawryResponseMeta()
        {

            return new
            {


                Authorization = GetRandomFawryResponseAuthorization(),


            };

        }


        #endregion

        #region FrancophoneMobileMoneyRequestProperties

        private static dynamic CreateRandomFrancophoneMobileMoneyRequestProperties()
        {
            return new
            {

                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Country = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),


            };
        }




        #endregion

        #region FrancophoneMobileMoneyResponseProperties

        private static dynamic CreateRandomFrancophoneMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFrancophoneMobileMoneyResponseData(),
                Meta = GetRandomFrancophoneMobileMoneyResponseMeta()

            };
        }


        private static dynamic GetRandomFrancophoneMobileMoneyResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                OrderId = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomFrancophoneMobileMoneyCustomer(),
                ProcessorResponse = GetRandomString(),



            };



        }

        private static dynamic GetRandomFrancophoneMobileMoneyCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }


        private static dynamic GetRandomFrancophoneMobileMoneyResponseAuthorization()
        {
            return new
            {
                Mode = GetRandomString(),
                RedirectUrl = GetRandomString(),
            };
        }

        private static dynamic GetRandomFrancophoneMobileMoneyResponseMeta()
        {

            return new
            {


                Authorization = GetRandomFrancophoneMobileMoneyResponseAuthorization(),


            };

        }


        #endregion

        #region GhanaMobileMoneyRequestProperties

        private static dynamic CreateRandomGhanaMobileMoneyRequestProperties()
        {
            return new
            {

                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Voucher = GetRandomString(),
                Network = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Meta = GetRandomGhanaMobileMoneyMeta(),




            };
        }

        private static dynamic GetRandomGhanaMobileMoneyMeta()
        {
            return new
            {


                FlightID = GetRandomString(),



            };
        }


        #endregion

        #region GhanaMobileMoneyResponseProperties

        private static dynamic CreateRandomGhanaMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomGhanaMobileMoneyResponseMeta()

            };
        }


        private static dynamic GetRandomGhanaMobileMoneyResponseAuthorization()
        {
            return new
            {
                Mode = GetRandomString(),
                Redirect = GetRandomString(),
            };
        }

        private static dynamic GetRandomGhanaMobileMoneyResponseMeta()
        {

            return new
            {
                Authorization = GetRandomGhanaMobileMoneyResponseAuthorization(),
            };

        }


        #endregion

        #region GooglePayRequestProperties

        private static dynamic CreateRandomGooglePayRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                Fullname = GetRandomString(),
                Narration = GetRandomString(),
                RedirectUrl = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                BillingZip = GetRandomString(),
                BillingCity = GetRandomString(),
                BillingAddress = GetRandomString(),
                BillingState = GetRandomString(),
                BillingCountry = GetRandomString(),
                Meta = GetRandomGooglePayMeta(),





            };
        }

        private static dynamic GetRandomGooglePayMeta()
        {
            return new
            {


                Metaname = GetRandomString(),
                Metavalue = GetRandomString(),



            };
        }


        #endregion

        #region GooglePayResponseProperties

        private static dynamic CreateRandomGooglePayResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomGooglePayResponseData(),
                Meta = GetRandomGooglePayResponseMeta()

            };
        }


        private static dynamic GetRandomGooglePayResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomGooglePayCustomer(),
                Meta = GetRandomGooglePayMeta(),

            };



        }

        private static dynamic GetRandomGooglePayCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = new object(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }


        private static dynamic GetRandomGooglePayResponseAuthorization()
        {
            return new
            {
                Mode = GetRandomString(),
                RedirectUrl = GetRandomString(),
            };
        }

        private static dynamic GetRandomGooglePayResponseMeta()
        {

            return new
            {


                Authorization = GetRandomGooglePayResponseAuthorization(),


            };

        }


        #endregion

        #region MpesaRequestProperties

        private static dynamic CreateRandomMpesaRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),






            };
        }



        #endregion

        #region MpesaResponseProperties

        private static dynamic CreateRandomMpesaResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomMpesaResponseData(),

            };
        }


        private static dynamic GetRandomMpesaResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomMpesaCustomer(),



            };



        }

        private static dynamic GetRandomMpesaCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),
            };
        }

        private static dynamic GetRandomMpesaAccount()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }




        #endregion

        #region NGBankAccountsRequestProperties

        private static dynamic CreateRandomNGBankAccountsRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                AccountBank = GetRandomString(),
                AccountNumber = GetRandomString(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),




            };
        }



        #endregion

        #region NGBankAccountsResponseProperties

        private static dynamic CreateRandomNGBankAccountsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomNGBankAccountsResponseData(),

            };
        }


        private static dynamic GetRandomNGBankAccountsResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomNGBankAccountsCustomer(),
                Account = GetRandomNGBankAccountsAccount(),
                Meta = GetRandomNGBankAccountsResponseMeta(),



            };



        }

        private static dynamic GetRandomNGBankAccountsCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                Email = GetRandomString(),



            };
        }

        private static dynamic GetRandomNGBankAccountsAccount()
        {

            return new
            {
                AccountNumber = GetRandomString(),
                BankCode = GetRandomString(),
                AccountName = GetRandomString(),




            };
        }



        private static dynamic GetRandomNGBankAccountsResponseMeta()
        {

            return new
            {
                Mode = GetRandomString(),
                ValidateInstructions = GetRandomString(),
            };

        }


        #endregion

        #region PayPalRequestProperties

        private static dynamic CreateRandomPayPalRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Country = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                RedirectUrl = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                BillingAddress = GetRandomString(),
                BillingCity = GetRandomString(),
                BillingZip = GetRandomString(),
                BillingState = GetRandomString(),
                BillingCountry = GetRandomString(),
                ShippingName = GetRandomString(),
                ShippingAddress = GetRandomString(),
                ShippingCity = GetRandomString(),
                ShippingZip = GetRandomString(),
                ShippingState = GetRandomString(),
                ShippingCountry = GetRandomString(),





            };
        }



        #endregion

        #region PayPalResponseProperties

        private static dynamic CreateRandomPayPalResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomPayPalResponseData(),

            };
        }


        private static dynamic GetRandomPayPalResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomPayPalCustomer(),
                Meta = GetRandomPayPalResponseMeta(),

            };

        }

        private static dynamic GetRandomPayPalCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Name = GetRandomString(),
                PhoneNumber = GetRandomString()


            };
        }


        private static dynamic GetRandomPayPalResponseMeta()
        {

            return new
            {
                Mode = GetRandomString(),
                Redirect = GetRandomString(),
            };

        }


        #endregion

        #region RwandaMobileMoneyRequestProperties

        private static dynamic CreateRandomRwandaMobileMoneyRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                OrderId = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),

            };
        }



        #endregion

        #region RwandaMobileMoneyResponseProperties

        private static dynamic CreateRandomRwandaMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomRwandaMobileMoneyResponseMeta(),

            };
        }


        private static dynamic GetRandomRwandaMobileMoneyResponseMeta()
        {

            return new
            {
                Mode = GetRandomString(),
                Redirect = GetRandomString(),
            };

        }


        #endregion

        #region TanzaniaMobileMoneyRequestProperties

        private static dynamic CreateRandomTanzaniaMobileMoneyRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Network = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Meta = GetRandomTanzaniaMobileMoneyMeta(),



            };
        }

        private static dynamic GetRandomTanzaniaMobileMoneyMeta()
        {
            return new
            {

                FlightID = GetRandomString(),

            };
        }

        #endregion

        #region TanzaniaMobileMoneyResponseProperties

        private static dynamic CreateRandomTanzaniaMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomTanzaniaMobileMoneyResponseData(),

            };
        }


        private static dynamic GetRandomTanzaniaMobileMoneyResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomTanzaniaMobileMoneyCustomer(),


            };

        }

        private static dynamic GetRandomTanzaniaMobileMoneyCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),




            };
        }





        #endregion

        #region UgandaMobileMoneyRequestProperties

        private static dynamic CreateRandomUgandaMobileMoneyRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Voucher = GetRandomNumber(),
                Network = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Meta = GetRandomUgandaMobileMoneyMeta(),





            };
        }

        private static dynamic GetRandomUgandaMobileMoneyMeta()
        {
            return new
            {

                FlightID = GetRandomString(),

            };
        }

        #endregion

        #region UgandaMobileMoneyResponseProperties

        private static dynamic CreateRandomUgandaMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomUgandaMobileMoneyResponseMeta(),

            };
        }


        private static dynamic GetRandomUgandaMobileMoneyResponseMeta()
        {

            return new
            {
                Authorization = GetRandomUgandaMobileMoneyAuthorization(),


            };

        }

        private static dynamic GetRandomUgandaMobileMoneyAuthorization()
        {

            return new
            {
                Redirect = GetRandomString(),
                Mode = GetRandomString(),

            };
        }





        #endregion

        #region UkEuBankAccountsRequestProperties

        private static dynamic CreateRandomUkEuBankAccountsRequestProperties()
        {
            return new
            {


                Currency = GetRandomString(),
                RedirectUrl = GetRandomString(),
                Amount = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Email = GetRandomString(),
                TxRef = GetRandomString(),
                Fullname = GetRandomString(),
                IsTokenIo = GetRandomNumber(),

            };
        }



        #endregion

        #region UkEuBankAccountsResponseProperties

        private static dynamic CreateRandomUkEuBankAccountsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomUkEuBankAccountsResponseMeta(),
                Data = GetRandomUkEuBankAccountsResponseData()

            };
        }


        private static dynamic GetRandomUkEuBankAccountsResponseMeta()
        {

            return new
            {
                Authorization = GetRandomUkEuBankAccountsAuthorization(),


            };

        }

        private static dynamic GetRandomUkEuBankAccountsResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomUKEuBankAccountsResponseCustomer(),



            };

        }

        private static dynamic GetRandomUkEuBankAccountsAuthorization()
        {

            return new
            {
                Redirect = GetRandomString(),
                Mode = GetRandomString(),

            };
        }

        private static dynamic GetRandomUKEuBankAccountsResponseCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = new object(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }



        #endregion

        #region USSDRequestProperties

        private static dynamic CreateRandomUSSDRequestProperties()
        {
            return new
            {


                TxRef = GetRandomString(),
                AccountBank = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),


            };
        }

        #endregion

        #region USSDResponseProperties

        private static dynamic CreateRandomUSSDResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomUSSDResponseMeta(),
                Data = GetRandomUSSDResponseData()

            };
        }


        private static dynamic GetRandomUSSDResponseMeta()
        {

            return new
            {
                Authorization = GetRandomUSSDAuthorization(),


            };

        }

        private static dynamic GetRandomUSSDResponseData()
        {

            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomUSSDResponseCustomer(),
                PaymentCode = GetRandomString(),

            };

        }

        private static dynamic GetRandomUSSDAuthorization()
        {

            return new
            {
                Note = GetRandomString(),
                Mode = GetRandomString(),

            };
        }

        private static dynamic GetRandomUSSDResponseCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }



        #endregion

        #region ValidateChargeRequestProperties

        private static dynamic CreateRandomValidateChargeRequestProperties()
        {
            return new
            {


                Otp = GetRandomString(),
                FlwRef = GetRandomString(),
                Type = GetRandomString(),


            };
        }



        #endregion

        #region ValidateChargeResponseProperties

        private static dynamic CreateRandomValidateChargeProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomValidateChargeResponseData()

            };
        }


        private static dynamic GetRandomValidateChargeResponseData()
        {

            return new
            {
                DeviceFingerprint = GetRandomString(),
                ChargeType = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                AuthUrl = GetRandomString(),
                PaymentType = GetRandomString(),
                FraudStatus = GetRandomString(),
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomValidateChargeResponseCustomer(),
                Card = GetRandomValidateChargeResponseCard(),


            };

        }

        private static dynamic GetRandomValidateChargeResponseCard()
        {

            return new
            {
                First6digits = GetRandomString(),
                Last4digits = GetRandomString(),
                Issuer = GetRandomString(),
                Country = GetRandomString(),
                Type = GetRandomString(),
                Expiry = GetRandomString(),


            };
        }

        private static dynamic GetRandomValidateChargeResponseCustomer()
        {

            return new
            {
                Id = GetRandomNumber(),
                PhoneNumber = new object(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }


        #endregion

        #region ZambiaMobileMoneyRequestProperties

        private static dynamic CreateRandomZambiaMobileMoneyRequestProperties()
        {
            return new
            {
                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                OrderId = GetRandomString(),
                Network = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Fullname = GetRandomString(),
                ClientIp = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Meta = GetRandomZambiaMobileMoneyMeta(),

            };
        }

        private static dynamic GetRandomZambiaMobileMoneyMeta()
        {
            return new
            {

                FlightID = GetRandomString(),
            };
        }

        #endregion

        #region ZambiaMobileMoneyResponseProperties

        private static dynamic CreateRandomZambiaMobileMoneyResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Meta = GetRandomZambiaMobileMoneyResponseMeta()

            };
        }




        private static dynamic GetRandomZambiaMobileMoneyResponseAuthorization()
        {

            return new
            {
                Redirect = GetRandomString(),
                Mode = GetRandomString(),



            };

        }



        private static dynamic GetRandomZambiaMobileMoneyResponseMeta()
        {

            return new
            {
                Authorization = GetRandomZambiaMobileMoneyResponseAuthorization(),



            };
        }



        #endregion





        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }

        private static Filler<ACHPayments> CreateACHPaymentsFiller()
        {
            var filler = new Filler<ACHPayments>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ApplePay> CreateApplePayFiller()
        {
            var filler = new Filler<ApplePay>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<BankTransfer> CreateBankTransferFiller()
        {
            var filler = new Filler<BankTransfer>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CardCharge> CreateCardChargeFiller()
        {
            var filler = new Filler<CardCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ENaira> CreateENairaFiller()
        {
            var filler = new Filler<ENaira>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<Fawry> CreateFawryFiller()
        {
            var filler = new Filler<Fawry>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<FrancophoneMobileMoney> CreateFrancophoneMobileMoneyFiller()
        {
            var filler = new Filler<FrancophoneMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<TanzaniaMobileMoney> CreateTanzaniaMobileMoneyFiller()
        {
            var filler = new Filler<TanzaniaMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<GhanaMobileMoney> CreateGhanaMobileMoneyFiller()
        {
            var filler = new Filler<GhanaMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<GooglePay> CreateGooglePayFiller()
        {
            var filler = new Filler<GooglePay>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<Mpesa> CreateMpesaFiller()
        {
            var filler = new Filler<Mpesa>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<NGBankAccounts> CreateNGBankAccountsFiller()
        {
            var filler = new Filler<NGBankAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<PayPal> CreatePayPalFiller()
        {
            var filler = new Filler<PayPal>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<RwandaMobileMoney> CreateRwandaMobileMoneyFiller()
        {
            var filler = new Filler<RwandaMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<UgandaMobileMoney> CreateUgandaMobileMoneyFiller()
        {
            var filler = new Filler<UgandaMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<UkEuBankAccounts> CreateUkEuBankAccountsFiller()
        {
            var filler = new Filler<UkEuBankAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<USSD> CreateUSSDFiller()
        {
            var filler = new Filler<USSD>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<ValidateCharge> CreateValidateChargeFiller()
        {
            var filler = new Filler<ValidateCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<ZambiaMobileMoney> CreateZambiaMobileMoneyFiller()
        {
            var filler = new Filler<ZambiaMobileMoney>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}

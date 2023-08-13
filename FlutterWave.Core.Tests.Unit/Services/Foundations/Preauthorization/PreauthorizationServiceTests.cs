using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IPreauthorizationService preauthorizationService;

        public PreauthorizationServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.preauthorizationService = new PreauthorizationService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCaptureChargeRequest, bool>> SameExternalCaptureChargeRequestAs(
            ExternalCaptureChargeRequest expectedExternalCaptureChargeRequest)
        {
            return actualExternalCaptureChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalCaptureChargeRequest,
                    actualExternalCaptureChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCapturePayPalChargeRequest, bool>> SameExternalCapturePaypalChargeRequestAs(
          ExternalCapturePayPalChargeRequest expectedExternalCapturePaypalChargeRequest)
        {
            return actualExternalCapturePaypalChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalCapturePaypalChargeRequest,
                    actualExternalCapturePaypalChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateChargeRequest, bool>> SameExternalCreateChargeRequestAs(
        ExternalCreateChargeRequest expectedExternalCreateChargeRequest)
        {
            return actualExternalCreateChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateChargeRequest,
                    actualExternalCreateChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreatePreauthorizationRefundRequest, bool>> SameExternalCreatePreauthorizationRefundRequestAs(
        ExternalCreatePreauthorizationRefundRequest expectedExternalCreatePreauthorizationRefundRequest)
        {
            return actualExternalCreatePreauthorizationRefundRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreatePreauthorizationRefundRequest,
                    actualExternalCreatePreauthorizationRefundRequest)
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

        private static CaptureCharge CreateRandomCaptureCharge() =>
           CreateCaptureChargeFiller().Create();

        private static CapturePayPalCharge CreateRandomCapturePayPalCharge() =>
            CreateCapturePayPalChargeFiller().Create();

        private static CreateCharge CreateRandomCreateCharge() =>
          CreateCreateChargeFiller().Create();

        private static CreatePreauthorizationRefund CreateRandomCreatePreauthorizationRefund() =>
          CreateCreatePreauthorizationRefundFiller().Create();

        #region CaptureChargeRequestProperties

        private static dynamic CreateRandomCaptureChargeRequestProperties()
        {
            return new
            {
                Amount = GetRandomNumber(),
            };
        }


        #endregion  

        #region CapturePaypalChargeRequestProperties

        private static dynamic CreateRandomCapturePayPalChargeRequestProperties()
        {
            return new
            {
                FlwRef = GetRandomString(),
            };
        }


        #endregion

        #region CreateChargeRequestProperties

        private static dynamic CreateRandomCreateChargeRequestProperties()
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
                UseSecureAuth = GetRandomBoolean(),
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

        #region CreatePreauthorizationRefundRequestProperties

        private static dynamic CreateRandomCreatePreauthorizationRefundRequestProperties()
        {
            return new
            {
                Amount = GetRandomNumber(),
            };
        }


        #endregion  


        #region CaptureChargeResponseProperties

        private static dynamic CreateRandomCaptureChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCaptureChargeResponseData()
            };
        }


        private static dynamic GetRandomCaptureChargeResponseData()
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
                Plan = GetRandomString(),
                FraudStatus = GetRandomString(),
                ChargeType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomCaptureChargeCustomer(),
                Card = GetRandomCaptureChargeCard(),



            };

        }

        private static dynamic GetRandomCaptureChargeCustomer()
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

        private static dynamic GetRandomCaptureChargeCard()
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
        #endregion

        #region CapturePayPalChargeResponseProperties

        private static dynamic CreateRandomCapturePayPalChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCapturePayPalChargeResponseData()
            };
        }


        private static dynamic GetRandomCapturePayPalChargeResponseData()
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
                Customer = GetRandomCapturePayPalChargeCustomer(),


            };

        }

        private static dynamic GetRandomCapturePayPalChargeCustomer()
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

        #region CreateChargeResponseProperties

        private static dynamic CreateRandomCreateChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object()
            };
        }



        #endregion

        #region CreatePreauthorizationRefundResponseProperties

        private static dynamic CreateRandomCreatePreauthorizationRefundResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreatePreauthorizationRefundResponseData()
            };
        }


        private static dynamic GetRandomCreatePreauthorizationRefundResponseData()
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
                Customer = GetRandomCreatePreauthorizationRefundCustomer(),
                Card = GetRandomCreatePreauthorizationRefundCard(),


            };

        }

        private static dynamic GetRandomCreatePreauthorizationRefundCustomer()
        {

            return new
            {

                Id = GetRandomNumber(),
                Phone = GetRandomString(),
                FullName = GetRandomString(),
                Customertoken = new object(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),
                DeletedAt = new object(),
                AccountId = GetRandomNumber(),


            };

        }

        private static dynamic GetRandomCreatePreauthorizationRefundCard()
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

        #endregion

        #region VoidChargeResponseProperties

        private static dynamic CreateRandomVoidChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomVoidChargeResponseData()
            };
        }


        private static dynamic GetRandomVoidChargeResponseData()
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
                Customer = GetRandomVoidChargeCustomer(),
                Card = GetRandomVoidChargeCard(),
                OrderId = GetRandomString(),

            };

        }

        private static dynamic GetRandomVoidChargeCustomer()
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

        private static dynamic GetRandomVoidChargeCard()
        {

            return new
            {

                First6digits = GetRandomNumber(),
                Last4digits = GetRandomNumber(),
                Issuer = GetRandomString(),
                Country = GetRandomString(),
                Type = GetRandomString(),
                Expiry = GetRandomString(),

            };

        }

        #endregion

        #region VoidPayPalChargeResponseProperties

        private static dynamic CreateRandomVoidPayPalChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomVoidPayPalChargeResponseData()
            };
        }


        private static dynamic GetRandomVoidPayPalChargeResponseData()
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
                Customer = GetRandomVoidPayPalChargeCustomer(),



            };

        }

        private static dynamic GetRandomVoidPayPalChargeCustomer()
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



        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }

        private static Filler<CreatePreauthorizationRefund> CreateCreatePreauthorizationRefundFiller()
        {
            var filler = new Filler<CreatePreauthorizationRefund>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CaptureCharge> CreateCaptureChargeFiller()
        {
            var filler = new Filler<CaptureCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CreateCharge> CreateCreateChargeFiller()
        {
            var filler = new Filler<CreateCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CapturePayPalCharge> CreateCapturePayPalChargeFiller()
        {
            var filler = new Filler<CapturePayPalCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}

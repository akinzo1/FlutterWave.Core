using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService
{
    internal partial class BillPaymentService : IBillPaymentService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public BillPaymentService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<BillCategories> GetBillCategoriesAsync() =>
        TryCatch(async () =>
        {

            ExternalBillCategoriesResponse externalBillCategoriesResponse =
            await flutterWaveBroker.GetBillCategoriesAsync();
            return ConvertToBillPaymentResponse(externalBillCategoriesResponse);
        });

        public ValueTask<ValidateBillService> GetValidateBillServiceAsync(string itemCode, string code, string customer) =>
        TryCatch(async () =>
        {
            ValidateBillServiceParameters(itemCode);
            ValidateBillServiceParameters(code);
            ValidateBillServiceParameters(customer);
            ExternalValidateBillServiceResponse externalValidateBillServiceResponse =
            await flutterWaveBroker.GetValidateBillServiceAsync(itemCode, code, customer);
            return ConvertToBillPaymentResponse(externalValidateBillServiceResponse);
        });

        public ValueTask<PostBillPayments> PostCreateBillPaymentAsync(PostBillPayments billPayments) =>
        TryCatch(async () =>
        {
            ValidateCreateBillPayment(billPayments);
            ExternalCreateBillPaymentRequest externalCreateBillPayment =
            ConvertToBillPaymentRequest(billPayments);
            ExternalCreateBillPaymentResponse externalCreateBillPaymentResponse =
            await flutterWaveBroker.PostCreateBillPaymentAsync(externalCreateBillPayment);
            return ConvertToBillPaymentResponse(billPayments, externalCreateBillPaymentResponse);
        });

        public ValueTask<BulkBillPayments> PostCreateBulkBillAsync(BulkBillPayments billPayments) =>
        TryCatch(async () =>
        {
            ValidateBulkBillPayments(billPayments);
            ExternalBulkBillPaymentsRequest externalBulkBillPaymentsRequest =
            ConvertToBulkBillPaymentRequest(billPayments);
            ExternalBulkBillPaymentsResponse externalBulkBillPaymentsResponse =
            await flutterWaveBroker.PostCreateBulkBillAsync(externalBulkBillPaymentsRequest);
            return ConvertToBillPaymentResponse(billPayments, externalBulkBillPaymentsResponse);
        });
        public ValueTask<BillPaymentsStatus> GetBillStatusPaymentAsync(string reference) =>
        TryCatch(async () =>
        {
            ValidateBillPaymentStatusParameters(reference);
            ExternalBillStatusPaymentResponse externalBillStatusPaymentResponse =
            await flutterWaveBroker.GetBillStatusPaymentAsync(reference);
            return ConvertToBillPaymentResponse(externalBillStatusPaymentResponse);
        });

        public ValueTask<BillPayments> GetBillPaymentsAsync() =>
        TryCatch(async () =>
        {

            ExternalBillPaymentsResponse externalBillPaymentsResponse =
            await flutterWaveBroker.GetBillPaymentsAsync();
            return ConvertToBillPaymentResponse(externalBillPaymentsResponse);
        });

        private static ExternalBulkBillPaymentsRequest ConvertToBulkBillPaymentRequest(BulkBillPayments billPayments)
        {

            return new ExternalBulkBillPaymentsRequest
            {
                BulkData = billPayments.Request.BulkData.Select(data =>
                {
                    return new ExternalBulkBillPaymentsRequest.BulkDatum
                    {
                        Amount = data.Amount,
                        Country = data.Country,
                        Customer = data.Customer,
                        Recurrence = data.Recurrence,
                        Reference = data.Reference,
                        Type = data.Type,
                    };
                }).ToList(),
                BulkReference = billPayments.Request.BulkReference,
                CallbackUrl = billPayments.Request.CallbackUrl
            };


        }
        private static ExternalCreateBillPaymentRequest ConvertToBillPaymentRequest(PostBillPayments billPayments)
        {

            return new ExternalCreateBillPaymentRequest
            {
                Amount = billPayments.Request.Amount,
                BillerName = billPayments.Request.BillerName,
                Country = billPayments.Request.Country,
                Customer = billPayments.Request.Customer,
                Recurrence = billPayments.Request.Recurrence,
                Reference = billPayments.Request.Reference,
                Type = billPayments.Request.Type
            };


        }

        private static PostBillPayments ConvertToBillPaymentResponse(PostBillPayments postBillPayments, ExternalCreateBillPaymentResponse externalCreateBillPaymentResponse)
        {
            postBillPayments.Response = new CreateBillPaymentResponse
            {
                Message = externalCreateBillPaymentResponse.Message,
                Status = externalCreateBillPaymentResponse.Status,
                Data = new CreateBillPaymentResponse.Datum
                {
                    Amount = externalCreateBillPaymentResponse.Data.Amount,
                    FlwRef = externalCreateBillPaymentResponse.Data.FlwRef,
                    Network = externalCreateBillPaymentResponse.Data.Network,
                    TxRef = externalCreateBillPaymentResponse.Data.TxRef,
                    PhoneNumber = externalCreateBillPaymentResponse.Data.PhoneNumber,
                    Reference = externalCreateBillPaymentResponse.Data.Reference

                }
            };
            return postBillPayments;

        }

        private static BillPayments ConvertToBillPaymentResponse(ExternalBillPaymentsResponse externalBillPaymentsResponse)
        {

            return new BillPayments
            {
                Response = new BillPaymentsResponse
                {
                    Message = externalBillPaymentsResponse.Message,
                    Status = externalBillPaymentsResponse.Status,
                    Data = new BillPaymentsResponse.Datum
                    {
                        Reference = externalBillPaymentsResponse.Data.Reference,
                        TotalPages = externalBillPaymentsResponse.Data.TotalPages,
                        Summary = externalBillPaymentsResponse.Data.Summary.Select(summary =>
                        {
                            return new BillPaymentsResponse.Summary
                            {
                                CountAirtime = summary.CountAirtime,
                                CountDstv = summary.CountDstv,
                                Currency = summary.Currency,
                                SumAirtime = summary.SumAirtime,
                                SumBills = summary.SumBills,
                                SumCommission = summary.SumCommission,
                                SumDstv = summary.SumDstv,

                            };
                        }).ToList(),
                        Total = externalBillPaymentsResponse.Data.Total
                    }



                }
            };


        }

        private static BillPaymentsStatus ConvertToBillPaymentResponse(ExternalBillStatusPaymentResponse externalBillStatusPaymentResponse)
        {

            return new BillPaymentsStatus
            {
                Response = new BillStatusPaymentResponse
                {
                    Message = externalBillStatusPaymentResponse.Message,
                    Status = externalBillStatusPaymentResponse.Status,
                    Data = new BillStatusPaymentResponse.Datum
                    {
                        Amount = externalBillStatusPaymentResponse.Data.Amount,
                        Currency = externalBillStatusPaymentResponse.Data.Currency,
                        Extra = externalBillStatusPaymentResponse.Data.Extra,
                        Fee = externalBillStatusPaymentResponse.Data.Fee,
                        FlwRef = externalBillStatusPaymentResponse.Data.Fee,
                        Token = externalBillStatusPaymentResponse.Data.Fee,
                        TxRef = externalBillStatusPaymentResponse.Data.TxRef
                    }



                }
            };


        }

        private static BulkBillPayments ConvertToBillPaymentResponse(BulkBillPayments bulkBillPayments, ExternalBulkBillPaymentsResponse externalBulkBillPaymentsResponse)
        {
            bulkBillPayments.Response = new BulkBillPaymentsResponse
            {
                Message = externalBulkBillPaymentsResponse.Message,
                Status = externalBulkBillPaymentsResponse.Status,
                Data = new BulkBillPaymentsResponse.Datum
                {
                    BatchReference = externalBulkBillPaymentsResponse.Data.BatchReference,

                }
            };

            return bulkBillPayments;

        }


        private static ValidateBillService ConvertToBillPaymentResponse(ExternalValidateBillServiceResponse externalValidateBillServiceResponse)
        {

            return new ValidateBillService
            {
                Response = new ValidateBillServiceResponse
                {
                    Data = new ValidateBillServiceResponse.Datum
                    {
                        Address = externalValidateBillServiceResponse.Data.Address,
                        BillerCode = externalValidateBillServiceResponse.Data.BillerCode,
                        Customer = externalValidateBillServiceResponse.Data.Customer,
                        Email = externalValidateBillServiceResponse.Data.Email,
                        Fee = externalValidateBillServiceResponse.Data.Fee,
                        Maximum = externalValidateBillServiceResponse.Data.Maximum,
                        Minimum = externalValidateBillServiceResponse.Data.Minimum,
                        Name = externalValidateBillServiceResponse.Data.Name,
                        ProductCode = externalValidateBillServiceResponse.Data.ProductCode,
                        ResponseCode = externalValidateBillServiceResponse.Data.ResponseCode,
                        ResponseMessage = externalValidateBillServiceResponse.Data.ResponseMessage,

                    },
                    Message = externalValidateBillServiceResponse.Message,
                    Status = externalValidateBillServiceResponse.Status,
                }
            };


        }

        private static BillCategories ConvertToBillPaymentResponse(ExternalBillCategoriesResponse externalBillCategoriesResponse)
        {

            return new BillCategories
            {
                Response = new BillCategoriesResponse
                {
                    Data = externalBillCategoriesResponse.Data.Select(data =>
                    {
                        return new BillCategoriesResponse.Datum
                        {
                            Amount = data.Amount,
                            BillerCode = data.BillerCode,
                            BillerName = data.BillerName,
                            CommissionOnFee = data.CommissionOnFee,
                            Country = data.Country,
                            DateAdded = data.DateAdded,
                            DefaultCommission = data.DefaultCommission,
                            Fee = data.Fee,
                            Id = data.Id,
                            IsAirtime = data.IsAirtime,
                            ItemCode = data.ItemCode,
                            LabelName = data.LabelName,
                            Name = data.Name,
                            ShortName = data.ShortName,
                        };

                    }).ToList(),
                    Message = externalBillCategoriesResponse.Message,
                    Status = externalBillCategoriesResponse.Status,
                }
            };


        }


    }
}

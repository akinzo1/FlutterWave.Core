using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService
{
    internal partial class ChargeBackService : IChargeBackService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ChargeBackService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<AllChargeBacks> GetAllChargeBacksAsync() =>
        TryCatch(async () =>
        {

            ExternalChargeBacksResponse externalChargeBacksResponse =
            await flutterWaveBroker.GetAllChargeBacksAsync();
            return ConvertToChargeBackResponse(externalChargeBacksResponse);
        });

        public ValueTask<AcceptDeclineChargeBack> PostAcceptDeclineChargeBacksAsync(
            string chargeBackId, AcceptDeclineChargeBack chargeBack) =>
        TryCatch(async () =>
        {
            //ValidateAcceptDeclineChargeBackId(chargeBackId);
            ValidateChargeBack(chargeBackId, chargeBack);
            ExternalAcceptDeclineChargeBackRequest externalAcceptDeclineChargeBackRequest =
            ConvertToAcceptDeclineRequest(chargeBack);
            ExternalAcceptDeclineChargeBackResponse externalAcceptDeclineChargeBackResponse =
            await flutterWaveBroker.CreateAcceptDeclineChargeBacksAsync(chargeBackId, externalAcceptDeclineChargeBackRequest);
            return ConvertToChargeBackResponse(chargeBack, externalAcceptDeclineChargeBackResponse);
        });

        public ValueTask<ChargeBack> GetChargeBackAsync(string flutterWaveReference) =>
        TryCatch(async () =>
        {
            ValidateChargeBackId(flutterWaveReference);
            ExternalChargeBackResponse externalChargeBackResponse =
            await flutterWaveBroker.GetChargeBackAsync(flutterWaveReference);
            return ConvertToChargeBackResponse(externalChargeBackResponse);
        });


        private static ExternalAcceptDeclineChargeBackRequest ConvertToAcceptDeclineRequest(AcceptDeclineChargeBack chargeBack)
        {
            return new ExternalAcceptDeclineChargeBackRequest
            {
                Action = chargeBack.Request.Action,
                Comment = chargeBack.Request.Comment,
            };
        }
        private static AllChargeBacks ConvertToChargeBackResponse(ExternalChargeBacksResponse externalChargeBacksResponse)
        {

            return new AllChargeBacks
            {
                Response = new AllChargeBacksResponse
                {
                    Status = externalChargeBacksResponse.Status,
                    Message = externalChargeBacksResponse.Message,
                    Data = externalChargeBacksResponse.Data.Select(data =>
                    {
                        return new AllChargeBacksResponse.Datum
                        {
                            DueDate = data.DueDate,
                            CreatedAt = data.CreatedAt,
                            Comment = data.Comment,
                            FlwRef = data.FlwRef,
                            Amount = data.Amount,
                            Id = data.Id,
                            SettlementId = data.SettlementId,
                            Stage = data.Stage,
                            Status = data.Status,
                            TransactionId = data.TransactionId,
                            TxRef = data.TxRef,
                            Meta = new AllChargeBacksResponse.ChargeBacksMeta
                            {
                                History = data.Meta.History.Select(history =>
                                {
                                    return new AllChargeBacksResponse.History
                                    {
                                        Stage = history.Stage,
                                        Action = history.Action,
                                        Date = history.Date,
                                        Description = history.Description,
                                        Initiator = history.Initiator,
                                        Source = history.Source,
                                    };
                                }).ToList(),
                                PageInfo = new AllChargeBacksResponse.PageInfo
                                {
                                    CurrentPage = data.Meta.PageInfo.CurrentPage,
                                    PageSize = data.Meta.PageInfo.PageSize,
                                    Total = data.Meta.PageInfo.Total,
                                    TotalPages = data.Meta.PageInfo.TotalPages,
                                },
                                UploadedProof = data.Meta.UploadedProof,

                            }
                        };

                    }).ToList(),
                    Meta = new AllChargeBacksResponse.PageInfo
                    {
                        CurrentPage = externalChargeBacksResponse.Meta.CurrentPage,
                        PageSize = externalChargeBacksResponse.Meta.PageSize,
                        Total = externalChargeBacksResponse.Meta.Total,
                        TotalPages = externalChargeBacksResponse.Meta.TotalPages,
                    }






                }
            };
        }
        private static AcceptDeclineChargeBack ConvertToChargeBackResponse(AcceptDeclineChargeBack acceptDeclineChargeBack, ExternalAcceptDeclineChargeBackResponse externalAcceptDeclineChargeBackResponse)
        {
            acceptDeclineChargeBack.Response = new AcceptDeclineChargeBackResponse
            {

                Data = externalAcceptDeclineChargeBackResponse.Data,
                Message = externalAcceptDeclineChargeBackResponse.Message,
                Status = externalAcceptDeclineChargeBackResponse.Status,

            };
            return acceptDeclineChargeBack;


        }
        private static ChargeBack ConvertToChargeBackResponse(ExternalChargeBackResponse externalChargeBackResponse)
        {

            return new ChargeBack
            {
                Response = new ChargeBackResponse
                {
                    Data = externalChargeBackResponse.Data.Select(data =>
                    {
                        return new ChargeBackResponse.Datum
                        {
                            Amount = data.Amount,
                            Comment = data.Comment,
                            CreatedAt = data.CreatedAt,
                            DueDate = data.DueDate,
                            FlwRef = data.FlwRef,
                            Id = data.Id,
                            Meta = new ChargeBackResponse.ChargebackMeta
                            {
                                PageInfo = new ChargeBackResponse.PageInfo
                                {
                                    TotalPages = data.Meta.PageInfo.TotalPages,
                                    Total = data.Meta.PageInfo.Total,
                                    CurrentPage = data.Meta.PageInfo.CurrentPage,
                                    PageSize = data.Meta.PageInfo.PageSize,
                                },
                                History = data.Meta.History.Select(history =>
                                {
                                    return new ChargeBackResponse.History
                                    {
                                        Stage = history.Stage,
                                        Action = history.Action,
                                        Date = history.Date,
                                        Description = history.Description,
                                        Initiator = history.Initiator,
                                        Source = history.Source,
                                    };
                                }).ToList(),
                                UploadedProof = data.Meta.UploadedProof
                            },
                            SettlementId = data.SettlementId,
                            Stage = data.Stage,
                            Status = data.Status,
                            TransactionId = data.TransactionId,
                            TxRef = data.TxRef,
                        };
                    }).ToList(),
                    Message = externalChargeBackResponse.Message,
                    Status = externalChargeBackResponse.Status,
                    Meta = new ChargeBackResponse.PageInfo
                    {
                        TotalPages = externalChargeBackResponse.Meta.TotalPages,
                        Total = externalChargeBackResponse.Meta.Total,
                        CurrentPage = externalChargeBackResponse.Meta.CurrentPage,
                        PageSize = externalChargeBackResponse.Meta.PageSize,
                    }

                }
            };


        }


    }
}

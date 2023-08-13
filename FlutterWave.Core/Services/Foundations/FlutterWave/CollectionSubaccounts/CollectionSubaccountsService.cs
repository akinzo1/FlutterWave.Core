using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using System.Linq;
using System.Threading.Tasks;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService
{
    internal partial class CollectionSubaccountsService : ICollectionSubaccountsService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public CollectionSubaccountsService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<CreateCollectionSubaccount> PostCreateCollectionSubaccountRequestAsync(CreateCollectionSubaccount createCollectionSubaccount) =>
          TryCatch(async () =>
        {

            ValidateCreateCollectionSubaccount(createCollectionSubaccount);
            ExternalCreateCollectionSubaccountRequest externalCreateCollectionSubaccountRequest = ConvertToCollectionSubaccountRequest(createCollectionSubaccount);
            ExternalCreateCollectionSubaccountResponse externalCreateCollectionSubaccountResponse = await flutterWaveBroker.PostCreateCollectionSubaccountAsync(
                externalCreateCollectionSubaccountRequest);
            return ConvertToCollectionSubaccountResponse(createCollectionSubaccount, externalCreateCollectionSubaccountResponse);
        });

        public ValueTask<FetchSubaccounts> GetSubaccountsRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalFetchSubaccountsResponse externalFetchSubaccountsResponse = await flutterWaveBroker.GetSubaccountsAsync();
            return ConvertToCollectionSubaccountResponse(externalFetchSubaccountsResponse);
        });

        public ValueTask<FetchSubaccount> GetSubaccountRequestAsync(int subaccountId) =>
        TryCatch(async () =>
        {
            ValidateFetchSubaccountId(subaccountId);
            ExternalFetchSubaccountResponse externalFetchSubaccountResponse = await flutterWaveBroker.GetSubaccountAsync(
               subaccountId);
            return ConvertToCollectionSubaccountResponse(externalFetchSubaccountResponse);
        });

        public ValueTask<UpdateSubaccount> PostUpdateCollectionSubaccountRequestAsync(int subaccountId, UpdateSubaccount updateSubaccount) =>
        TryCatch(async () =>
        {

            ValidateUpdateSubaccount(subaccountId, updateSubaccount);
            ExternalUpdateSubaccountRequest externalUpdateSubaccountRequest = ConvertToCollectionSubaccountRequest(updateSubaccount);
            ExternalUpdateSubaccountResponse externalUpdateSubaccountResponse = await flutterWaveBroker.PostUpdateCollectionSubaccountAsync(
               subaccountId, externalUpdateSubaccountRequest);
            return ConvertToCollectionSubaccountResponse(updateSubaccount, externalUpdateSubaccountResponse);
        });

        public ValueTask<DeleteSubaccount> DeleteCollectionSubaccountRequestAsync(int subaccountId) =>
        TryCatch(async () =>
        {
            ValidateDeleteSubaccountId(subaccountId);
            ExternalDeleteSubaccountResponse externalDeleteSubaccountResponse = await flutterWaveBroker.DeleteCollectionSubaccountAsync(
               subaccountId);
            return ConvertToCollectionSubaccountResponse(externalDeleteSubaccountResponse);
        });





        private FetchSubaccount ConvertToCollectionSubaccountResponse(ExternalFetchSubaccountResponse externalFetchSubaccountResponse)
        {
            return new FetchSubaccount
            {
                Response = new FetchSubaccountResponse
                {
                    Message = externalFetchSubaccountResponse.Message,
                    Data = new FetchSubaccountResponse.FetchSubaccountData
                    {
                        AccountId = externalFetchSubaccountResponse.Data.AccountId,
                        AccountBank = externalFetchSubaccountResponse.Data.AccountBank,
                        AccountNumber = externalFetchSubaccountResponse.Data.AccountNumber,
                        BankName = externalFetchSubaccountResponse.Data.BankName,
                        BusinessName = externalFetchSubaccountResponse.Data.BusinessName,
                        Country = externalFetchSubaccountResponse.Data.Country,
                        CreatedAt = externalFetchSubaccountResponse.Data.CreatedAt,
                        FullName = externalFetchSubaccountResponse.Data.FullName,
                        Id = externalFetchSubaccountResponse.Data.Id,
                        Meta = externalFetchSubaccountResponse.Data.Meta,
                        SplitRatio = externalFetchSubaccountResponse.Data.SplitRatio,
                        SplitType = externalFetchSubaccountResponse.Data.SplitType,
                        SplitValue = externalFetchSubaccountResponse.Data.SplitValue,
                        SubaccountId = externalFetchSubaccountResponse.Data.SubaccountId


                    },
                    Status = externalFetchSubaccountResponse.Status,


                }

            };
        }
        private FetchSubaccounts ConvertToCollectionSubaccountResponse(ExternalFetchSubaccountsResponse externalFetchSubaccountsResponse)
        {
            return new FetchSubaccounts
            {
                Response = new FetchSubaccountsResponse
                {
                    Message = externalFetchSubaccountsResponse.Message,
                    Data = externalFetchSubaccountsResponse.Data.Select(data =>
                    {
                        return new FetchSubaccountsResponse.Datum
                        {
                            AccountId = data.AccountId,
                            SubaccountId = data.SubaccountId,
                            SplitValue = data.SplitValue,
                            SplitType = data.SplitType,
                            SplitRatio = data.SplitRatio,
                            Meta = data.Meta.Select(data =>
                            {
                                return new FetchSubaccountsResponse.Metum
                                {
                                    MetaName = data.MetaName,
                                    MetaValue = data.MetaValue,
                                };
                            }).ToList(),
                            AccountBank = data.AccountBank,
                            AccountNumber = data.AccountNumber,
                            BankName = data.BankName,
                            BusinessName = data.BusinessName,
                            Country = data.Country,
                            CreatedAt = data.CreatedAt,
                            FullName = data.FullName,
                            Id = data.Id
                        };


                    }).ToList(),
                    Meta = new FetchSubaccountsResponse.FetchSubaccountsMeta
                    {
                        MetaName = externalFetchSubaccountsResponse.Meta.MetaName,
                        MetaValue = externalFetchSubaccountsResponse.Meta.MetaValue,
                        SwiftCode = externalFetchSubaccountsResponse.Meta.SwiftCode,
                        PageInfo = new FetchSubaccountsResponse.PageInfo
                        {
                            TotalPages = externalFetchSubaccountsResponse.Meta.PageInfo.TotalPages,
                            Total = externalFetchSubaccountsResponse.Meta.PageInfo.Total,
                            CurrentPage = externalFetchSubaccountsResponse.Meta.PageInfo.CurrentPage
                        }
                    },
                    Status = externalFetchSubaccountsResponse.Status,


                }

            };
        }
        private DeleteSubaccount ConvertToCollectionSubaccountResponse(ExternalDeleteSubaccountResponse externalDeleteSubaccountResponse)
        {
            return new DeleteSubaccount
            {
                Response = new DeleteSubaccountResponse
                {
                    Message = externalDeleteSubaccountResponse.Message,
                    Data = externalDeleteSubaccountResponse.Data,
                    Status = externalDeleteSubaccountResponse.Status,


                }

            };
        }


        private ExternalCreateCollectionSubaccountRequest ConvertToCollectionSubaccountRequest(CreateCollectionSubaccount createCollectionSubaccount)
        {
            return new ExternalCreateCollectionSubaccountRequest
            {
                AccountBank = createCollectionSubaccount.Request.AccountBank,
                SplitValue = createCollectionSubaccount.Request.SplitValue,
                BusinessName = createCollectionSubaccount.Request.BusinessName,
                BusinessMobile = createCollectionSubaccount.Request.BusinessMobile,
                AccountNumber = createCollectionSubaccount.Request.AccountNumber,
                BusinessContact = createCollectionSubaccount.Request.BusinessContact,
                BusinessContactMobile = createCollectionSubaccount.Request.BusinessContactMobile,
                BusinessEmail = createCollectionSubaccount.Request.BusinessEmail,
                Country = createCollectionSubaccount.Request.Country,
                Meta = createCollectionSubaccount.Request.Meta.Select(data =>
                {
                    return new ExternalCreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue,
                    };
                }).ToList(),

                SplitType = createCollectionSubaccount.Request.SplitType,


            };
        }
        private CreateCollectionSubaccount ConvertToCollectionSubaccountResponse(
            CreateCollectionSubaccount createCollectionSubaccount,
            ExternalCreateCollectionSubaccountResponse externalCreateCollectionSubaccountResponse)
        {

            createCollectionSubaccount.Response = new CreateCollectionSubaccountResponse
            {
                Message = externalCreateCollectionSubaccountResponse.Message,
                Data = new CreateCollectionSubaccountResponse.CreateCollectionSubaccountData
                {
                    SplitType = externalCreateCollectionSubaccountResponse.Data.SplitType,
                    AccountBank = externalCreateCollectionSubaccountResponse.Data.AccountBank,
                    AccountNumber = externalCreateCollectionSubaccountResponse.Data.AccountNumber,
                    BankName = externalCreateCollectionSubaccountResponse.Data.BankName,
                    CreatedAt = externalCreateCollectionSubaccountResponse.Data.CreatedAt,
                    FullName = externalCreateCollectionSubaccountResponse.Data.FullName,
                    Id = externalCreateCollectionSubaccountResponse.Data.Id,
                    SplitValue = externalCreateCollectionSubaccountResponse.Data.SplitValue,
                    SubaccountId = externalCreateCollectionSubaccountResponse.Data.SubaccountId


                },

                Status = externalCreateCollectionSubaccountResponse.Status,


            };
            return createCollectionSubaccount;

        }

        private ExternalUpdateSubaccountRequest ConvertToCollectionSubaccountRequest(UpdateSubaccount updateSubaccount)
        {
            return new ExternalUpdateSubaccountRequest
            {
                SplitValue = updateSubaccount.Request.SplitValue,
                AccountBank = updateSubaccount.Request.AccountBank,
                AccountNumber = updateSubaccount.Request.AccountNumber,
                BusinessEmail = updateSubaccount.Request.BusinessEmail,
                BusinessName = updateSubaccount.Request.BusinessName,
                SplitType = updateSubaccount.Request.SplitType,



            };
        }
        private UpdateSubaccount ConvertToCollectionSubaccountResponse(
            UpdateSubaccount updateSubaccount,
            ExternalUpdateSubaccountResponse externalUpdateSubaccountResponse)
        {

            updateSubaccount.Response = new UpdateSubaccountResponse
            {
                Message = externalUpdateSubaccountResponse.Message,
                Data = new UpdateSubaccountResponse.UpdateSubaccountData
                {
                    SplitType = externalUpdateSubaccountResponse.Data.SplitType,
                    BusinessName = externalUpdateSubaccountResponse.Data.BusinessName,
                    AccountNumber = externalUpdateSubaccountResponse.Data.AccountNumber,
                    AccountBank = externalUpdateSubaccountResponse.Data.AccountBank,
                    AccountId = externalUpdateSubaccountResponse.Data.AccountId,
                    BankName = externalUpdateSubaccountResponse.Data.BankName,
                    Country = externalUpdateSubaccountResponse.Data.Country,
                    CreatedAt = externalUpdateSubaccountResponse.Data.CreatedAt,
                    FullName = externalUpdateSubaccountResponse.Data.FullName,
                    Id = externalUpdateSubaccountResponse.Data.Id,
                    Meta = externalUpdateSubaccountResponse.Data.Meta.Select(data =>
                    {
                        return new UpdateSubaccountResponse.Metum
                        {
                            MetaName = data.MetaName,
                            MetaValue = data.MetaValue,
                        };
                    }).ToList(),
                    SplitRatio = externalUpdateSubaccountResponse.Data.SplitRatio,
                    SplitValue = externalUpdateSubaccountResponse.Data.SplitValue,
                    SubaccountId = externalUpdateSubaccountResponse.Data.SubaccountId
                },
                Status = externalUpdateSubaccountResponse.Status,


            };
            return updateSubaccount;

        }


    }



}

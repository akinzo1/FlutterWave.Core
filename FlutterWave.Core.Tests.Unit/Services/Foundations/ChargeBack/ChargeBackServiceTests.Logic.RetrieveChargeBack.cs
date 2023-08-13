using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveChargeBackByReferenceAsync()
        {
            // given 
            string randomRandomReference = GetRandomString();
            string inputReference = randomRandomReference;

            dynamic createRandomChargeBacksProperties =
                CreateRandomAllChargeBackProperties();

            var randomExternalChargeBackResponse = new ExternalChargeBackResponse
            {
                Status = createRandomChargeBacksProperties.Status,
                Meta = new ExternalChargeBackResponse.PageInfo
                {
                    CurrentPage = createRandomChargeBacksProperties.Meta.CurrentPage,
                    PageSize = createRandomChargeBacksProperties.Meta.PageSize,
                    Total = createRandomChargeBacksProperties.Meta.Total,
                    TotalPages = createRandomChargeBacksProperties.Meta.TotalPages
                },
                Message = createRandomChargeBacksProperties.Message,
                Data = ((List<dynamic>)createRandomChargeBacksProperties.Data).Select(data =>
                {
                    return new ExternalChargeBackResponse.Datum
                    {
                        Id = data.Id,
                        Meta = new ExternalChargeBackResponse.ExternalChargebackMeta
                        {
                            PageInfo = new ExternalChargeBackResponse.PageInfo
                            {
                                TotalPages = data.Meta.PageInfo.TotalPages,
                                Total = data.Meta.PageInfo.Total,
                                CurrentPage = data.Meta.PageInfo.CurrentPage,
                                PageSize = data.Meta.PageInfo.PageSize


                            },
                            UploadedProof = data.Meta.UploadedProof,
                            History = ((List<dynamic>)data.Meta.History).Select(history =>
                            {
                                return new ExternalChargeBackResponse.History
                                {
                                    Action = history.Action,
                                    Date = history.Date,
                                    Description = history.Description,
                                    Initiator = history.Initiator,
                                    Source = history.Source,
                                    Stage = history.Stage,
                                };

                            }).ToList(),
                        },
                        FlwRef = data.FlwRef,
                        DueDate = data.DueDate,
                        CreatedAt = data.CreatedAt,
                        Comment = data.Comment,
                        Amount = data.Amount,
                        SettlementId = data.SettlementId,
                        Stage = data.Stage,
                        Status = data.Status,
                        TransactionId = data.TransactionId,
                        TxRef = data.TxRef,

                    };
                }).ToList(),

            };

            var randomExpectedChargeBackResponse = new ChargeBackResponse
            {
                Status = createRandomChargeBacksProperties.Status,
                Meta = new ChargeBackResponse.PageInfo
                {
                    CurrentPage = createRandomChargeBacksProperties.Meta.CurrentPage,
                    PageSize = createRandomChargeBacksProperties.Meta.PageSize,
                    Total = createRandomChargeBacksProperties.Meta.Total,
                    TotalPages = createRandomChargeBacksProperties.Meta.TotalPages
                },
                Message = createRandomChargeBacksProperties.Message,
                Data = ((List<dynamic>)createRandomChargeBacksProperties.Data).Select(data =>
                {
                    return new ChargeBackResponse.Datum
                    {
                        Id = data.Id,
                        Meta = new ChargeBackResponse.ChargebackMeta
                        {
                            PageInfo = new ChargeBackResponse.PageInfo
                            {
                                TotalPages = data.Meta.PageInfo.TotalPages,
                                Total = data.Meta.PageInfo.Total,
                                CurrentPage = data.Meta.PageInfo.CurrentPage,
                                PageSize = data.Meta.PageInfo.PageSize


                            },
                            UploadedProof = data.Meta.UploadedProof,
                            History = ((List<dynamic>)data.Meta.History).Select(history =>
                            {
                                return new ChargeBackResponse.History
                                {
                                    Action = history.Action,
                                    Date = history.Date,
                                    Description = history.Description,
                                    Initiator = history.Initiator,
                                    Source = history.Source,
                                    Stage = history.Stage,
                                };

                            }).ToList(),
                        },
                        FlwRef = data.FlwRef,
                        DueDate = data.DueDate,
                        CreatedAt = data.CreatedAt,
                        Comment = data.Comment,
                        Amount = data.Amount,
                        SettlementId = data.SettlementId,
                        Stage = data.Stage,
                        Status = data.Status,
                        TransactionId = data.TransactionId,
                        TxRef = data.TxRef,

                    };
                }).ToList(),

            };

            var expectedChargeBack = new ChargeBack
            {
                Response = randomExpectedChargeBackResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetChargeBackAsync(inputReference))
                    .ReturnsAsync(randomExternalChargeBackResponse);

            // when
            ChargeBack actualBillPaymentsStatus =
               await this.chargeBackService.GetChargeBackAsync(inputReference);

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedChargeBack);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(inputReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
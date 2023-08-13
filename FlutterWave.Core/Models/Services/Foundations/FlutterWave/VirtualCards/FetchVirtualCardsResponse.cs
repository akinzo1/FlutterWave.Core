using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class FetchVirtualCardsResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("card_hash")]
            public string CardHash { get; set; }

            [JsonProperty("card_pan")]
            public string CardPan { get; set; }

            [JsonProperty("masked_pan")]
            public string MaskedPan { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("address_1")]
            public string Address1 { get; set; }

            [JsonProperty("address_2")]
            public object Address2 { get; set; }

            [JsonProperty("zip_code")]
            public string ZipCode { get; set; }

            [JsonProperty("cvv")]
            public string Cvv { get; set; }

            [JsonProperty("expiration")]
            public string Expiration { get; set; }

            [JsonProperty("send_to")]
            public object SendTo { get; set; }

            [JsonProperty("bin_check_name")]
            public object BinCheckName { get; set; }

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("name_on_card")]
            public string NameOnCard { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("is_active")]
            public bool IsActive { get; set; }

            [JsonProperty("callback_url")]
            public string CallbackUrl { get; set; }
        }






    }
}

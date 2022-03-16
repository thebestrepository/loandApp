using System;
using Newtonsoft.Json;

namespace LoanApp.Api.DTO
{
    public class LoanDTO
    {
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("years")]
        public int Years { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        public LoanDTO()
        {
        }
    }
}

using System;
using Newtonsoft.Json;

public struct MonthlyPaybackDTO
{

    [JsonProperty("totalAmount")]
    public double TotalAmount { get; set; }
    [JsonProperty("interest")]
    public double Interest { get; set; }
    [JsonProperty("principal")]
    public double Principal { get; set; }
    [JsonProperty("unapidBalame")]
    public double UnpaidBalance { get; set; }
    [JsonProperty("paymentDate")]
    public DateTime PaymentDate { get; set; }
}
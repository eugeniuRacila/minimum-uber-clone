using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DriverBlazorWA.Models
{
    public class Order
    {
        [JsonPropertyName("customerId")]
        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("driverId")]
        public int DriverId { get; set; }
        
        [JsonPropertyName("startingPoint")]
        [DataMember(Name = "startingPoint")]
        public string StartingPoint { get; set; }

        [JsonPropertyName("destinationPoint")]
        [DataMember(Name = "destinationPoint")]
        public string DestinationPoint { get; set; }

        [JsonPropertyName("typeOfCar")]
        [DataMember(Name = "typeOfCar")]
        public string TypeOfCar { get; set; }
        
        [JsonPropertyName("amountOfSeats")]
        [DataMember(Name = "amountOfSeats")]
        public int AmountOfSeats { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
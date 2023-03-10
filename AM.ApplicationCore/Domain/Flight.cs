using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public Flight()
        {
        }

        public int FlightId { get; set; }

        [ForeignKey("Plane")]
        public int? PlaneId { get; set; }
        public string? Destination { get; set; }
        public string? Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }

        public Plane? plane { get; set; } //on a ajouter ? pour avoir plane cle nulable   

        public IList<Passenger> Passengers { get; set;}

        public override string ToString()
        {
            return $"FlightId: {PlaneId}, Destination: {Destination}, Departure: {Departure}, FlightDate: {FlightDate}, EffectiveArrival: {EffectiveArrival}, EstimatedDuration: {EstimateDuration}";
        }
    }
}

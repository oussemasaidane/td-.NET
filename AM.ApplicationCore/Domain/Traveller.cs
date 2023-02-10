using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public Traveller() { }
        public string? Healthinformation { get; set; }
        public string? Nationality { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"HealthInformation: {Healthinformation}, Nationality: {Nationality}";
        }

        public virtual void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am Traveller ");
        }

    }
}

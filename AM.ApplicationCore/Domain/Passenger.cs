using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public Passenger()
        {
        }

        public DateTime BirthDate { get; set; }

        [Key]
        public int PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]//controle de saisie
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TelNumber { get; set; }

        public IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"BirthDate: {BirthDate}," +
                $" PassportNumber: {PassportNumber}, " +
                $"EmailAddress: {EmailAddress}," +
                $" FirstName: {FirstName}," +
                $" LastName: {LastName}, " +
                $"TelNumber: {TelNumber}";
        }

        public bool CheckProfile(string nom, string prenom)
        {
            return nom == FirstName && prenom == LastName;
        }

        public bool CheckProfile(string nom, string prenom, string email)
        {
            return nom == FirstName && prenom == LastName && email == EmailAddress;
        }

        public bool CheckProfile1(string nom, string prenom, string email=null)
        {
            if (email != null)
                return nom == FirstName && prenom == LastName && email == EmailAddress;
            else
                return nom == FirstName && prenom == LastName;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger ");
        }
    }
}

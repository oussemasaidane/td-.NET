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
        [DataType(DataType.Date),Display(Name ="Date of Birth")]//controle de saisie

        public DateTime BirthDate { get; set; }

        [Key,MaxLength(7)]
        public int PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]//controle de saisie
        public string? EmailAddress { get; set; }

        //[MinLength(3,ErrorMessage = "n'est pas respecté "),MaxLength(25,ErrorMessage ="n'est pas respecté ")]
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public FullName fullName { get; set; }

        [MinLength(8), MaxLength(8)]

        public int TelNumber { get; set; }

        public IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"BirthDate: {BirthDate}," +
                $" PassportNumber: {PassportNumber}, " +
                $"EmailAddress: {EmailAddress}," +
                //$" FirstName: {FirstName}," +
                //$" LastName: {LastName}, " +
                $"TelNumber: {TelNumber}";
        }

        //public bool CheckProfile(string nom, string prenom)
        //{
        //    return nom == FirstName && prenom == LastName;
        //}

        //public bool CheckProfile(string nom, string prenom, string email)
        //{
        //    return nom == FirstName && prenom == LastName && email == EmailAddress;
        //}

        //public bool CheckProfile1(string nom, string prenom, string email=null)
        //{
        //    if (email != null)
        //        return nom == FirstName && prenom == LastName && email == EmailAddress;
        //    else
        //        return nom == FirstName && prenom == LastName;
        //}

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger ");
        }
    }
}

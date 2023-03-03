// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Personne personne = new Personne();
//personne.Id = 0;
//personne.Nom = "oussema";
//personne.Prenom = "saidane";
//personne.Password= "0000";
//personne.Email = "oussema@esprit.tn";
//personne.DateNaissance= DateTime.Now;
//// ou personne.DateNaissance= new DateTime (2022,12,31,15,45,54);
//Console.WriteLine(personne);

//Personne personne1 = new Personne(1,"ahmed","hmed","hmed@esprit.tn","1111",DateTime.Now);

//Personne personne2 = new Personne(){
//    Id= 2,
//    Nom="aaaa",
//    Prenom="aaaa",
//    DateNaissance= DateTime.Now,
//    Email="aaaa@esprit.tn",
//    Password="2111"

//};


//Personne etudiant =new Etudiant();  
//personne.GetMyType();
//etudiant.GetMyType();

//Plane Plane = new Plane() {
//    PlaneId = 1,
//    Capacity= 1,
//    ManufactureDate= DateTime.Now,
//    PlaneType=PlaneType.Boing,
//    Flights= new List<Flight>() { }

//};

//Plane avion = new Plane(PlaneType.Boing, 1, DateTime.Now);

//Passenger passenger = new Passenger();
//passenger.FirstName = "passenger";
//passenger.LastName = "passenger";
//passenger.PassengerType();


int x = 45;
Console.WriteLine(x.add(4));
Passenger p = new Passenger()
{
    FirstName = "ssss",
    LastName = "ddd"

};

p.UpperFullName();
Console.WriteLine(p);
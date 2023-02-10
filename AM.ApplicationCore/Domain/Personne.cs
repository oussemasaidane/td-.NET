using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Personne
    {
        //ctor pour avoir constructeur vide 
        public Personne()
        {
        }

        public Personne(int id, string nom, string prenom, string email, string password, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            DateNaissance = dateNaissance;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateNaissance { get; set; }

        public bool Login (string nom , string prenom)
        {
            return nom == Nom && prenom == Prenom;
        }

        //public bool Login(string nom, string prenom, string email)
        //{
        //    return nom == Nom && prenom == Prenom && email= Email ;
        //}

        public bool Login(string nom, string prenom , string email=null)
        {
            if (email != null)
                return nom == Nom && prenom == Prenom && email == Email;
            else
                return nom == Nom && prenom == Prenom;
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("I am person ");
        }

        public override string ToString()
        {
            return $"[{Id},{Nom},{Prenom},{Email}]" ;
        }


    }
}

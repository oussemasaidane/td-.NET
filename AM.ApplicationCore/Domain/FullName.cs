using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "n'est pas respecté "), MaxLength(25, ErrorMessage = "n'est pas respecté ")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public FullName() { }

        public FullName(string FirstName, string LastName) {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString()
        {
            return $"FirstName : {FirstName} ,LastName:{LastName}" ;
        }

    }
}

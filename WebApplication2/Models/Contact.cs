using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Knickname { get; set; }

        [NotMapped]
        public string DisplayAs
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, LastName,  Knickname);
            }
        }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}


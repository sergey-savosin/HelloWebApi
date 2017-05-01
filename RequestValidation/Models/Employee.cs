using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestValidation.Models
{
    public class Employee
    {
        [Range(10000,99999)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public int Department { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Resources;
using System.Collections.Generic;
using RequestValidation.Utils;

namespace RequestValidation.Models
{
    public class Employee
    {
        [Range(10000,99999)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessageResourceName = "InvalidLastNameLength",
            ErrorMessageResourceType = typeof(Messages))]
        public string LastName { get; set; }

        [Required]
        [MemberRange(0,9)]
        public List<int> Department { get; set; }
    }
}
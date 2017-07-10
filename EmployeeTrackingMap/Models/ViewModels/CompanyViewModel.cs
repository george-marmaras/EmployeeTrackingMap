using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTrackingMap.Models.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public bool Active { get; set; }
        public string FullCompanyName { get; set; }
        public int LocationId { get; set; }

        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Invalid Latitude")]
        public decimal Latitude { get; set; }

        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Invalid Longitude")]
        public decimal Longitude { get; set; }

        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTrackingMap.Models.ViewModels
{
    public class OfficeViewModel
    {
        public string Name { get; set; }
        public Nullable<int> LocationId { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public string CountryCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
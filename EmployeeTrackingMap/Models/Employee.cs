//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeTrackingMap.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string BusinessAddress { get; set; }
        public string HomeAddress { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public bool Active { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<int> LocationId { get; set; }
        public string CountryCode { get; set; }
        public string Age { get; set; }
        public string Payment { get; set; }
        public int CompanyId { get; set; }
        public int OfficeId { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ReportsTo { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Office Office { get; set; }
    }
}

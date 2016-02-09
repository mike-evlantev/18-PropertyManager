using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_PropertyManager.Models
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }
        public int? AddressId { get; set; }
        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; } //int? = int nullable = could have or not have a value
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public int? NumberOfVehicle { get; set; }

        public AddressModel Address { get; set; }
    }
}
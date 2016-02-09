using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_PropertyManager.Domain
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int? AddressId { get; set; }
        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; } //int? = int nullable = could have or not have a value
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public int? NumberOfVehicle { get; set; }
        // ----- RELATIONSHIP -----
        //virtual - word used for Entity FW - lazy load (load piece by piece instad of loading all of something (eager loading))
        public virtual Address Address { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
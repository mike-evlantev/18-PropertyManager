using _18_PropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_PropertyManager.Domain
{
    public enum RentFrequencies
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly = 4,
        BiAnnually = 5,
        Annually = 6
    }
    public class Lease
    {
        //Properties
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public RentFrequencies RentFrequency { get; set; }
        //Relationships
        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }

        public void Update(LeaseModel modelLease)
        {
            TenantId = modelLease.TenantId;
            PropertyId = modelLease.PropertyId;
            StartDate = modelLease.StartDate;
            EndDate = modelLease.EndDate;
            RentAmount = modelLease.RentAmount;
            RentFrequency = modelLease.RentFrequency;
        }
    }    
}
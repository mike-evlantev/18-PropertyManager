using _18_PropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_PropertyManager.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string UserId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public virtual Address Address { get; set; }
        public virtual PropertyManagerUser User { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public void Update(TenantModel modelTenant)
        {
            AddressId = modelTenant.AddressId;
            FirstName = modelTenant.FirstName;
            LastName = modelTenant.LastName;
            Telephone = modelTenant.Telephone;
            EmailAddress = modelTenant.EmailAddress;
            Address.Update(modelTenant.Address);
        }
    }
}
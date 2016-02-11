using _18_PropertyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_PropertyManager.Domain
{
    public enum Priorities
    {
        Critical = 1,
        Major = 2,
        High = 3,
        Medium = 4,
        Low = 5
    }
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int TenantId { get; set; }
        public string Description { get; set; }
        public Priorities Priority { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }

        public void Update(WorkOrderModel modelWorkOder)
        {
            PropertyId = modelWorkOder.PropertyId;
            TenantId = modelWorkOder.TenantId;            
            Description = modelWorkOder.Description;
            Priority = modelWorkOder.Priority;
            OpenedDate = modelWorkOder.OpenedDate;
            ClosedDate = modelWorkOder.ClosedDate;            
        }
    }
}
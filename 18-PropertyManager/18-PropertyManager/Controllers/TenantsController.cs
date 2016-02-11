using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _18_PropertyManager.Domain;
using _18_PropertyManager.Infrastructure;
using _18_PropertyManager.Models;
using AutoMapper;

namespace _18_PropertyManager.Controllers
{
    public class TenantsController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Tenants
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(db.Tenants);
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        //GET: api/tenants/5/leases
        [Route("api/tenants/{TenantId}/leases")]
        public IEnumerable<LeaseModel> GetLeasesForTenant(int TenantId)
        {
            var leases = db.Leases.Where(l => l.TenantId == TenantId);
            return Mapper.Map<IEnumerable<LeaseModel>>(leases);
        }

        //GET: api/tenants/5/workorders
        [Route("api/tenants/{TenantId}/workorders")]
        public IEnumerable<WorkOrderModel> GetWorkOrdersForProperty(int TenantId)
        {
            var workorders = db.WorkOrders.Where(wo => wo.TenantId == TenantId);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(workorders);
        }

        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel modelTenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelTenant.TenantId)
            {
                return BadRequest();
            }

            // 1. Grab endtry from database by id
            var dbTenant = db.Tenants.Find(id);
            // 2. Update entry fetched from the database
            dbTenant.Update(modelTenant);
            // 3. Mark entry as modified
            db.Entry(dbTenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tenants
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTenant = new Tenant();
            newTenant.Update(tenant);

            db.Tenants.Add(newTenant);
            db.SaveChanges();

            tenant.TenantId = newTenant.TenantId;

            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}
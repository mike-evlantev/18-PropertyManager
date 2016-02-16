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
    [Authorize]
    public class AddressesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Addresses
        public IEnumerable<AddressModel> GetAddresses()
        {
            return Mapper.Map<IEnumerable<AddressModel>>(db.Addresses);
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressModel))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<AddressModel>(address));
        }

        //GET: api/addresses/5/properties
        [Route("api/addresses/{AddressId}/properties")]
        public IEnumerable<PropertyModel> GetPropertiesForAddress(int AddressId)
        {
            var properties = db.Properties.Where(l => l.AddressId == AddressId);
            return Mapper.Map<IEnumerable<PropertyModel>>(properties);
        }

        //GET: api/addresses/5/tenants
        [Route("api/addresses/{AddressId}/tenants")]
        public IEnumerable<TenantModel> GetTenantsForAddress(int AddressId)
        {
            var tenants = db.Tenants.Where(wo => wo.AddressId == AddressId);
            return Mapper.Map<IEnumerable<TenantModel>>(tenants);
        }
        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, AddressModel modelAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelAddress.AddressId)
            {
                return BadRequest();
            }
            #region
            // to be changed
            // 1.Grab the entry from the database
            var dbAddress = db.Addresses.Find(id);

            // 2. Update the entry fetched from the database
            dbAddress.Update(modelAddress);

            // 3. Mark entry as modified
            db.Entry(dbAddress).State = EntityState.Modified;
            #endregion
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(AddressModel))]
        public IHttpActionResult PostAddress(AddressModel address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAddress = new Address();
            newAddress.Update(address);            

            db.Addresses.Add(newAddress);
            db.SaveChanges();

            address.AddressId = newAddress.AddressId;

            return CreatedAtRoute("DefaultApi", new { id = address.AddressId }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(AddressModel))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(Mapper.Map<AddressModel>(address));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.AddressId == id) > 0;
        }
    }
}
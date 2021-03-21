using KodiMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KodiMax.Controllers
{
    public class CandyAPIController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return Ok(db.Candies.ToList());
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return Ok(db.Candies.Find(id));
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public void Post([FromBody] string value)
        {
        }
        public void Put(int id, [FromBody] string value)
        {
        }
        public void Delete(int id)
        {
        }
    }
}
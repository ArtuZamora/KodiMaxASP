using KodiMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KodiMax.Controllers
{
    public class UserAPIController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return Ok(db.Users.ToList());
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
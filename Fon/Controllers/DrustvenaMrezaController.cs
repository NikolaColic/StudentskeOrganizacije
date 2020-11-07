using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FonData.Interface;
using FonData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fon.Controllers
{
    [Route("fon/drustvenamreza")]
    [ApiController]
    [Authorize]

    public class DrustvenaMrezaController : ControllerBase
    {
        private ILibraryDrustveneMreze _mreze;


        public DrustvenaMrezaController(ILibraryDrustveneMreze mreze)
        {
            _mreze = mreze;

        }

        // GET: api/DrustvenaMreza
        [HttpGet]
        public ActionResult<IEnumerable<DrustvenaMreza>> VratiMreze()
        {
            try
            {
                var mreze = _mreze.VratiDrustveneMreze();
                return Ok(mreze);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/DrustvenaMreza/5
        [HttpGet("{id}")]
        public ActionResult<DrustvenaMreza> Get(int id)
        {
            var mreza = _mreze.VratiMrezuId(id);
            if (mreza is null) return NotFound();
            return Ok(mreza);
        }

       
    }
}

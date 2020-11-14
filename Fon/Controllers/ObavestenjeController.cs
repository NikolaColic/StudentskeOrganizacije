using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fon.Controllers
{
    [Route("fon/organizacija/obavestenja")]
    [ApiController]
    [Authorize]
    public class ObavestenjeController : ControllerBase
    {
        private ILibraryObavestenje _obavestenje;


        public ObavestenjeController(ILibraryObavestenje obavestenje)
        {
            _obavestenje = obavestenje;

        }
        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IEnumerable<Obavestenje>> VratiObavestenja()
        {
            var obavestenja = Task.Run( async () =>
            {
                return await _obavestenje.VratiObavestenja();
            });

            if (obavestenja.Result is null) return NotFound();
            return Ok(obavestenja.Result);
        }

    }
}
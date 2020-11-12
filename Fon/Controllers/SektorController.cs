using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fon.Controllers
{
    [Route("fon/organizacija/sektori")]
    [ApiController]
    public class SektorController : ControllerBase
    {
        private ILibrarySektor _sektor;


        public SektorController(ILibrarySektor sektor)
        {
            _sektor = sektor;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sektor>>> VratiObavestenja()
        {
            var obavestenja = await _sektor.VratiSektore();
            if (obavestenja is null) return NotFound();
            return Ok(obavestenja);
        }
    }
}
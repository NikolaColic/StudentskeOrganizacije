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
    [Route("fon/organizacija/projekti")]
    [ApiController]
    [Authorize]
    public class ProjekatController : ControllerBase
    {
        private ILibraryProjekat _projekat;


        public ProjekatController(ILibraryProjekat projekat)
        {
            _projekat = projekat;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Projekat>> VratiProjekte()
        {
            var obavestenja = _projekat.VratiProjekte();
            if (obavestenja is null) return NotFound();
            return Ok(obavestenja);
        }
    }
}
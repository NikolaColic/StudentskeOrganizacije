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
    [Route("fon/organizacija/postovi")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private ILibraryPost _post;


        public PostController(ILibraryPost post)
        {
            _post = post;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Post>> VratiObavestenja()
        {
            var obavestenja = _post.VratiPostove();
            if (obavestenja is null) return NotFound();
            return Ok(obavestenja);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FonData.Interface;
using FonData.Models;
using FonData.Models.SlabeKlase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fon.Controllers
{
    [Route("fon/organizacija")]
    [ApiController]
    [Authorize]
    //[Authorize]
    public class StudentskaOrganizacijaController : ControllerBase
    {
        private ILibraryStudentskaOrganizacija _organizacija;


        public StudentskaOrganizacijaController(ILibraryStudentskaOrganizacija organizacija)
        {
            _organizacija = organizacija;

        }

        // GET: api/StudentskaOrganizacija
        [HttpGet(Name = "VratiOrganizacije")]
        public ActionResult<IEnumerable<StudentskaOrganizacija>> VratiOrganizacije()
        {
            try
            {
                var organizacije = _organizacija.GetOrganizacije();
                return Ok(organizacije);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/StudentskaOrganizacija/5
        [HttpGet("{id}")]
        public ActionResult<StudentskaOrganizacija> Get(int id)
        {
            try
            {
                var organizacija = _organizacija.VratiOrganizacijuId(id);
                if (organizacija is null) return NotFound();
                return Ok(organizacija);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // POST: api/StudentskaOrganizacija
        [HttpPost]
        public ActionResult<IEnumerable<StudentskaOrganizacija>> Post([FromBody] StudentskaOrganizacija organizacija)
        {
            if (_organizacija.AddStudentskuOrganizaciju(organizacija)) return RedirectToRoute("VratiOrganizacije");
            return NotFound();
        }

        // PUT: api/StudentskaOrganizacija/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentskaOrganizacija organizacija)
        {
            if (_organizacija.UpdateStudentskuOrganizaciju(id, organizacija)) return Ok(_organizacija.GetOrganizacije());
            return NotFound();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_organizacija.DeleteStudentskuOrganizaciju(id)) return NoContent();
            return NotFound();
        }

        //Drustvena mreza 
        [HttpGet("{id}/mreze")]
        public ActionResult<IEnumerable<string>> VratiMreze(int id)
        {
            var mreze = _organizacija.VratiUrlMreza(id);
            if (mreze is null) return NotFound();
            return Ok(mreze);
        }
        //Clan 
        [HttpGet("{id}/clanovi")]
        public ActionResult<IEnumerable<string>> VratiClanove(int id)
        {
            var clanovi = _organizacija.VratiClanoveOrganizacije(id);
            if (clanovi is null) return NotFound();
            return Ok(clanovi);
        }
        //Subscribe
        [HttpGet("{id}/subscribe")]
        public ActionResult<IEnumerable<string>> VratiSubscribe(int id)
        {
            var subscribe = _organizacija.VratiSubscribeOrganizacije(id);
            if (subscribe is null) return NotFound();
            return Ok(subscribe);
        }

        

        //Obavestenja 

        [HttpGet("{id}/obavestenja", Name = "VratiObavestenja")]
        public ActionResult<IEnumerable<Obavestenje>> VratiObavestenja(int id)
        {
            var obavestenja = _organizacija.VratiObavestenja(id);
            if (obavestenja is null) return NotFound();
            return Ok(obavestenja);
        }

        [HttpPost("{id}/obavestenja")]
        public ActionResult<IEnumerable<Obavestenje>> AddObavestenja(int id, [FromBody] Obavestenje obavestenje)
        {
            StudentskaOrganizacija org = new StudentskaOrganizacija() { Id = id };
            obavestenje.StudentskaOrganizacija = org;
            if (_organizacija.DodajObavestenje(obavestenje)) return RedirectToRoute("VratiObavestenja", new { id = $"{id}" });
            return NotFound();
        }

        [HttpPut("{id}/obavestenja/{obavestenjeId}")]
        public ActionResult<IEnumerable<Obavestenje>> UpdateObavestenja(int id,int obavestenjeId,[FromBody] Obavestenje obavestenje)
        {
            obavestenje.ObavestenjeId = obavestenjeId;
            if (_organizacija.UpdateObavestenje(id, obavestenje)) return Ok(_organizacija.VratiObavestenja(id));
            return NotFound();
        }

        [HttpDelete("{id}/obavestenja/{obavestenjeId}")]
        public ActionResult DeleteObavestenje(int id, int obavestenjeId)
        {
            StudentskaOrganizacija org = new StudentskaOrganizacija() { Id = id };
            Obavestenje o = new Obavestenje() { ObavestenjeId = obavestenjeId,
                                                 StudentskaOrganizacija = org};
              
            if (_organizacija.ObrisiObavestenje(o)) return NoContent();
            return NotFound();
        }

       

        [HttpGet("{id}/post", Name = "VratiPostove")]
        public ActionResult<IEnumerable<Post>> VratiPostove(int id)
        {
            var poruke = _organizacija.VratiPostove(id);
            if (poruke is null) return NotFound();
            return Ok(poruke);
        }

        [HttpPost("{id}/post")]
        public ActionResult<IEnumerable<Post>> AddPost(int id, [FromBody] Post post)
        {
            StudentskaOrganizacija org = new StudentskaOrganizacija() { Id = id };
            post.StudentskaOrganizacija = org;
            if (_organizacija.DodajPost(post)) return RedirectToRoute("VratiPostove", new { id = $"{id}" });
            return NotFound();
        }

        [HttpPut("{id}/post/{postId}")]
        public ActionResult<IEnumerable<Post>> UpdatePost(int id, int postId,
            [FromBody] Post post)
        {
            StudentskaOrganizacija org = new StudentskaOrganizacija() { Id = id };
            post.StudentskaOrganizacija = org;
            post.PostId = postId;
            if (_organizacija.UpdatePost(post)) return Ok(_organizacija.VratiPostove(id));
            return NotFound();
        }

        [HttpDelete("{id}/post/{postId}")]
        public ActionResult DeletePost(int id, int postId)
        {
            if (_organizacija.DeletePost(id, postId)) return NoContent();
            return NotFound();
        }

        //Projekat

        [HttpGet("{id}/projekat", Name = "VratiProjekte")]
        public ActionResult<IEnumerable<Sektor>> VratiProjekte(int id)
        {
            var projekti = _organizacija.VratiProjekte(id);
            if (projekti is null) return NotFound();
            return Ok(projekti);
        }

        [HttpPost("{id}/projekat")]
        public ActionResult<IEnumerable<Sektor>> AddProjekat(int id, [FromBody] Projekat projekat)
        {
            if (_organizacija.AddProjekat(id, projekat)) return RedirectToRoute("VratiProjekte", new { id = $"{id}" });
            return NotFound();
        }

        [HttpPut("{id}/projekat/{projekatId}")]
        public ActionResult<IEnumerable<Sektor>> UpdateProjekat(int id, int projekatId,
            [FromBody]  Projekat projekat)
        {
            projekat.ProjekatId = projekatId;
            if (_organizacija.UpdateProjekat(id, projekat)) return Ok(_organizacija.VratiProjekte(id));
               
            return NotFound();
        }

        [HttpDelete("{id}/projekat/{projekatId}")]
        public ActionResult DeleteProjekat(int id, int projekatId)
        {
            if (_organizacija.DeleteProjekat(id, projekatId)) return NoContent();
            return NotFound();
        }

       

        //Slika

        [HttpGet("{id}/slike", Name = "VratiSlike")]
        public ActionResult<IEnumerable<Slika>> VratiSlike(int id)
        {
            var projekti = _organizacija.VratiSlike(id);
            if (projekti is null) return NotFound();
            return Ok(projekti);
        }

       

        [HttpGet("{id}/info", Name = "VratiInfo")]
        public ActionResult<IEnumerable<OrganizacijaInfo>> VratiInfo(int id)
        {
            var projekti = _organizacija.VratiOrganizacijaInfo(id);
            if (projekti is null) return NotFound();
            return Ok(projekti);
        }












    }
}

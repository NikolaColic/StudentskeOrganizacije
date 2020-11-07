using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FonData.Interface;
using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fon.Controllers
{
    [Route("fon/clanovi")]
    [ApiController]
    [Authorize]
    public class ClanController : ControllerBase
    {
        private ILibraryClan _clan;

        public ClanController(ILibraryClan clan)
        {
            _clan = clan;

        }


        [HttpGet(Name = "VratiClanove")]
        public ActionResult<IEnumerable<ClanOrganizacije>> VratiClanove()
        {
            var subscribe = _clan.VratiClanove();
            if (subscribe is null) return NotFound();
            return Ok(subscribe);
        }


        [HttpPost]
        public ActionResult AddClan([FromBody] SubscribeCreate subscribe)
        {
            if (_clan.DodajClana(subscribe)) return RedirectToRoute("VratiClanove");
            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_clan.DeleteClan(id)) return NoContent();
            return NotFound();
        }
    }
}
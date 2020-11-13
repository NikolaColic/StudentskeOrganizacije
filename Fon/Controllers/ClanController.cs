using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public async Task<ActionResult<IEnumerable<ClanOrganizacije>>> VratiClanove()
        {
            Thread.Sleep(5000);
            var subscribe = await _clan.VratiClanove();
            if (subscribe is null) return NotFound();
            return Ok(subscribe);
        }


        [HttpPost]
        public async Task<ActionResult> AddClan([FromBody] SubscribeCreate subscribe)
        {
            var rez = false;
            await Task.Run(() =>
            {
                
                rez = _clan.DodajClana(subscribe);
            });
            if (rez) return RedirectToRoute("VratiClanove");
            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _clan.DeleteClan(id)) return NoContent();
            return NotFound();
        }
    }
}
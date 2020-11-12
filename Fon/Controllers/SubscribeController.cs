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
    [Route("fon/subscribe")]
    [ApiController]
    [Authorize]
    public class SubscribeController : ControllerBase
    {
        private ILibrarySubscribe _subscribe;

        public SubscribeController(ILibrarySubscribe subscribe)
        {
            _subscribe = subscribe;

        }

        
        [HttpGet(Name ="VratiSubscribe")]
        public async Task<ActionResult<IEnumerable<Subscribe>>> VratiSubscribe()
        {
            var subscribe = await _subscribe.GetSubscribe();
            if (subscribe is null) return NotFound();
            return Ok(subscribe);
        }

        
        [HttpPost]
        public async Task<ActionResult> AddSubscribe([FromBody] SubscribeCreate subscribe)
        {
            if (await _subscribe.AddSubscribe(subscribe)) return RedirectToRoute("VratiSubscribe");
            return NotFound();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SubscribeCreate subscribe)
        {
            if (await _subscribe.UpdateSubscribe(id,subscribe)) return RedirectToRoute("VratiSubscribe");
            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Subscribe s = new Subscribe() { SubscribeId = id };
            if (await _subscribe.DeleteSubscribe(s)) return Ok(_subscribe.GetSubscribe());
            return NotFound();
        }
    }
}

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
        public ActionResult<IEnumerable<Subscribe>> VratiSubscribe()
        {
            var subscribe = _subscribe.GetSubscribe();
            if (subscribe is null) return NotFound();
            return Ok(subscribe);
        }

        
        [HttpPost]
        public ActionResult AddSubscribe([FromBody] SubscribeCreate subscribe)
        {
            if (_subscribe.AddSubscribe(subscribe)) return RedirectToRoute("VratiSubscribe");
            return NotFound();
        }

        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SubscribeCreate subscribe)
        {
            if (_subscribe.UpdateSubscribe(id,subscribe)) return RedirectToRoute("VratiSubscribe");
            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Subscribe s = new Subscribe() { SubscribeId = id };
            if (_subscribe.DeleteSubscribe(s)) return Ok(_subscribe.GetSubscribe());
            return NotFound();
        }
    }
}

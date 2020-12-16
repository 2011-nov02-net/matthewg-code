using KitchenService.Api.Models;
using KitchenService.Api.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenService.Api.Controllers {
    [Route("api/appliances/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase {

        private readonly Fridge _fridge;

        public FridgeController(Fridge fridge) {
            _fridge = fridge;
        }

        [HttpGet]
        public IActionResult Get() {
            var appliance = new Appliance { Id = _fridge.Id, Name = _fridge.Name };
            return Ok(appliance);
        }

        [HttpGet("contents")]
        public IActionResult GetContents() {
            return Ok(_fridge.Contents);
        }

        [HttpPost("contents")]
        public IActionResult PostContents(FridgeItem item) {
            var success = _fridge.AddItem(item);
            if (success) {
                return CreatedAtAction(
                    actionName: nameof(GetContentsById),
                    routeValues: new { item.Id },
                    value: item);
            }
            // if there was a validation error caught here...
            ModelState.AddModelError("", "");
            return BadRequest();
        }

        [HttpGet("contents/{id}")]
        public IActionResult GetContentsById(int id) {
            if (_fridge.Contents.FirstOrDefault(x => x.Id == id) is FridgeItem item) {
                return Ok(item);
            }
            return NotFound(); // 404, when the requested URL doesn't correspond to an existing resource
        }
    }
}

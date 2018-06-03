using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beacons.AP.Model;
using Beacons.AP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Beacons.AP.Controllers
{
    [Route("api/beacons")]
    public class BeaconsController : Controller
    {
        /// <summary>
        /// The beacon service
        /// </summary>
        private readonly IBeaconService beaconService;

        public BeaconsController(IBeaconService beaconService)
        {
            this.beaconService = beaconService ?? throw new ArgumentNullException(nameof(beaconService));
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<BeaconViewModel>> Get()
        {
            return await beaconService.GetAll();
        }


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            BeaconViewModel beaconViewModel = await beaconService.GetById(id);

            return new ObjectResult(beaconViewModel);
        }


        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TELDAProject1.Models;
using TELDAProject1.DataAccess;

namespace TELDAProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public RegionsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return _dataAccessProvider.GetRegions();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Region region)
        {
            if (ModelState.IsValid)
            {
                /*Guid obj = Guid.NewGuid();
                region.id = obj.ToString();*/
                _dataAccessProvider.AddRegionRecord(region);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Region Details(int id)
        {
            return _dataAccessProvider.GetSingleRegion(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Region patient)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateRegionRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetSingleRegion(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteRegionRecord(id);
            return Ok();
        }
    }
}

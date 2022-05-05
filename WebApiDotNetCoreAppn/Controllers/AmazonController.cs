using Business_Layer2;
using Domain_Layer2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDotNetCoreAppn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonController : ControllerBase
    {
        private readonly ILogger<AmazonController> _logger;
        private readonly IAmazonBusiness _amazonBusiness;

        public AmazonController(ILogger<AmazonController> logger, IAmazonBusiness amazonBusiness)
        {
            _logger = logger;
            _amazonBusiness = amazonBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonDto>))]
        [Route("get-allAmazonCountries")]
        public async Task<ActionResult<IEnumerable<AmazonDto>>> GetAll()
        {
            try
            {
                var resp = await _amazonBusiness.GetAllAmazonCountries();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(AmazonDto))]
        [Route("get-amazonCountryById")]
        public async Task<ActionResult<AmazonDto>> GetAmazonCountryById(int id)
        {
            try
            {
                var resp = await _amazonBusiness.GetAmazonCountryById(id);

                if (resp == null)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("insert-amazonCountry")]
        public async Task<ActionResult> InsertEmployee([FromBody] AmazonDto amazon)
        {
            try
            {
                await _amazonBusiness.InsertAmazonCountry(amazon);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update-amazonCountry")]
        public async Task<ActionResult> UpdateAmazonCountry([FromBody] AmazonDto amazon)
        {
            try
            {
                await _amazonBusiness.UpdateAmazonCountry(amazon);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete-amazonCountryById")]
        public async Task<ActionResult> DeleteAmazonCountryById(int id)
        {
            try
            {
                await _amazonBusiness.DeleteAmazonCountryById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

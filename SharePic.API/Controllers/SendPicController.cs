using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharePic.Application.Interfaces;
using SharePic.Application.Models;
using SharePic.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharePic.API.ViewModels;
using System.Net.Mime;

namespace SharePic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharePicController : ControllerBase
    {
        private readonly ISharePicService _SharePicService;

        public SharePicController(ISharePicService sharePicService)
        {
            this._SharePicService = sharePicService;
        }

        //// GET: api/Banking
        //[HttpGet]
        //public ActionResult<IEnumerable<Account>> Get()
        //{
        //    return Ok(_SharePicService.GetAccounts());
        //}

        /// <summary>
        /// Envia uma foto para outro us
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "From": "b89d67d4-0c1d-4f18-b027-85baa3b8cdc3",
        ///        "To": "c20c7a9f-0e40-4b6d-9520-c2b74647dbbc",
        ///        "Pic": "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",
        ///        "Duration": 60
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] SharePicViewModel model)
        {
            try
            {
                _SharePicService.SharePic(model.From, model.To, model.Pic, model.Duration);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

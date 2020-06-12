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
using Domain.Core.Entities;

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

        /// <summary>
        /// Envia uma foto para outro us
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[Produces("application/json")]
        [ProducesResponseType(typeof(SharePicViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(SharePicViewModel model)
        {
            try
            {
                await _SharePicService.SharePic(model.From, model.To, model.Pic, model.Duration);
                return Created(nameof(SharePicViewModel), model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

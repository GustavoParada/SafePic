using Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharePic.API.ViewModels;
using SharePic.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SharePic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharePicController : ControllerBase
    {
        private readonly ISharePicService _SharePicService;
        private readonly ILogger<SharePicController> _logger;


        public SharePicController(ISharePicService sharePicService, ILogger<SharePicController> logger)
        {
            _logger = logger;
            logger.LogWarning("injected");
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
                _logger.LogWarning("post called");
                await _SharePicService.SharePic(model.From, model.To, model.Pic, model.Duration);

                return Created(nameof(SharePicViewModel), model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new HttpErrorResponse()
                {
                    Error = "Erro no servidor.",
                    Trace = ex.Message
                });
            }
        }
    }
}

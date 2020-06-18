using Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using SharePic.API.ViewModels;
using SharePic.Application.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                return StatusCode(500, new HttpErrorResponse()
                {
                    Trace = ex.Message
                });
            }
        }

        /// <summary>
        /// Retorna a lista de imagens
        /// </summary>
        /// <param name="userId">Usuário logado</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<SharedPic>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<SharedPic>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(HttpErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult> Get(Guid userId)
        {
            try
            {
                var resp = await _SharePicService.GetSharedByUser(userId);

                if (resp == null || !resp.Any())
                    return NoContent();

                return Ok(resp);
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

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _SharePicService.DeleteShared(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new HttpErrorResponse()
                {
                    Trace = ex.Message
                });
            }
        }
    }
}

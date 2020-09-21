using System.Collections.Generic;
using ApplicationGetter.Application.Commands.Application;
using ApplicationGetter.WebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplicationGetter.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {

        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationCommands _applicationCommands;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationCommands applicationCommands)
        {
            _logger = logger;
            _applicationCommands = applicationCommands;
        }

        /// <summary>
        /// Busca a lista de aplicações.
        /// </summary>
        /// <returns></returns>
        [Route("GetList")]
        [HttpGet]
        public ActionResult<List<Domain.Application.Application>> GetList()
        {
            var result = _applicationCommands.ExecuteGetList();

            if (result.IsFaulted)
                return StatusCode(500, result.Exception.GetBaseException());

            return Ok(result.Result);
        }

        /// <summary>
        /// Busca uma aplicação pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ApplicationModel> Get([FromQuery]int id)
        {
            var result = _applicationCommands.ExecuteGet(id);

            return Ok(new ApplicationModel(result.Result));
        }

        /// <summary>
        /// Atualiza a aplicação.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Update([FromBody]ApplicationModel application)
        {
            var result = _applicationCommands.ExecuteUpdate(new Domain.Application.Application(application.Id, application.Url, application.PathLocal, application.DebuggingMode));

            if (result.IsFaulted)
                return StatusCode(500, result.Exception.GetBaseException());

            return StatusCode(204);
        }

        /// <summary>
        /// Adiciona uma nova aplicação.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add([FromBody]ApplicationModel application)
        {
            var result = _applicationCommands.ExecuteAdd(new Domain.Application.Application(application.Url, application.PathLocal, application.DebuggingMode));

            if (result.IsFaulted)
                return StatusCode(500, result.Exception.GetBaseException());

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta a aplicação.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete([FromBody]ApplicationModel application)
        {
            var result = _applicationCommands.ExecuteDelete(new Domain.Application.Application(application.Id, application.Url, application.PathLocal, application.DebuggingMode));

            if (result.IsFaulted)
                return StatusCode(500, result.Exception.GetBaseException());

            return StatusCode(204);
        }
    }
}

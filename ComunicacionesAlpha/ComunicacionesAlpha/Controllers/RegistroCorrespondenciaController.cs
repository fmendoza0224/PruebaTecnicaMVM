using ComunicacionesAlpha.Api.Excepciones;
using ComunicacionesAlpha.Aplicacion.Dtos;
using ComunicacionesAlpha.Aplicacion.Interfaces;
using ComunicacionesAlpha.Transversal;
using ComunicacionesAlpha.Transversal.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroCorrespondenciaController : ControllerBase
    {
        private readonly IRegistroCorrespondenciaAplicacion _registroCorrespondenciaAplicacion;
        private readonly ILog _log;

        public RegistroCorrespondenciaController(IRegistroCorrespondenciaAplicacion registroCorrespondenciaAplicacion, ILog log)
        {
            _registroCorrespondenciaAplicacion = registroCorrespondenciaAplicacion;
            _log = log;
        }

        /// <summary>
        /// CrearRegistroCorrespondencia
        /// </summary>
        /// <param name="registroCorrespondenciaDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CrearRegistroCorrespondencia([FromBody] RegistroCorrespondenciaDto registroCorrespondenciaDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log.GuardarLog(NivelSeveridad.Info.ToString(), "Inicia Crear Registro Correspondencia");

                    await _registroCorrespondenciaAplicacion.CrearRegistroYAuditoria(registroCorrespondenciaDto);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                throw new ModelException(Constantes.MENSAJE_ERROR_DATOS);
            }
            catch (Exception ex)
            {
                return RetornarException(ex);
            }
        }

        /// <summary>
        /// ConsultarRegistroCorrespondencia
        /// </summary>
        /// <param name="numeroDocumentoRemitente"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarRegistroCorrespondencia(long numeroDocumentoRemitente)
        {
            try
            {
                _log.GuardarLog(NivelSeveridad.Info.ToString(), "Inicia Consultar Registro Correspondencia");
                return StatusCode(StatusCodes.Status200OK, _registroCorrespondenciaAplicacion.ConsultarRegistroCorrespondencia(numeroDocumentoRemitente));
            }
            catch (Exception ex)
            {
                return RetornarException(ex);
            }
        }

        /// <summary>
        /// ModificarRegistroCorrespondencia
        /// </summary>
        /// <param name="registroYAuditoriaDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ModificarRegistroCorrespondencia([FromBody] RegistroYAuditoriaDto registroYAuditoriaDto)
        {
            try
            {
                _log.GuardarLog(NivelSeveridad.Info.ToString(), "Inicia Modificar Registro Correspondencia");
                _registroCorrespondenciaAplicacion.ModificarRegistro(registroYAuditoriaDto);
                return StatusCode(StatusCodes.Status200OK, Constantes.MENSAJE_EXITOSO);
            }
            catch (Exception ex)
            {
                return RetornarException(ex);
            }
        }

        private ObjectResult RetornarException(Exception ex)
        {
            string innerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            _log.GuardarLog(NivelSeveridad.Error.ToString(), $"{ex.Message}{Environment.NewLine}{innerException}");
            return StatusCode(StatusCodes.Status500InternalServerError, Constantes.MENSAJE_ERROR);
        }
    }
}

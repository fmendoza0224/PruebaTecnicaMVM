using AutoMapper;
using ComunicacionesAlpha.Api.Excepciones;
using ComunicacionesAlpha.Aplicacion.Dtos;
using ComunicacionesAlpha.Aplicacion.Interfaces;
using ComunicacionesAlpha.Dominio.Entidades.Modelos;
using ComunicacionesAlpha.Dominio.Servicios.Interfaces;
using ComunicacionesAlpha.Infraestructura.Models;
using ComunicacionesAlpha.Transversal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Aplicacion
{
    public class RegistroCorrespondenciaAplicacion : IRegistroCorrespondenciaAplicacion
    {
        private readonly IRegistroCorrespondenciaDominio _registroCorrespondenciaDominio;
        private readonly IMapper iMapper;

        public RegistroCorrespondenciaAplicacion(IRegistroCorrespondenciaDominio registroCorrespondenciaDominio)
        {
            _registroCorrespondenciaDominio = registroCorrespondenciaDominio;

            MapperConfiguration configuracion = new MapperConfiguration(config =>
            {
                config.CreateMap<RegistroCorrespondenciaDto, RegistroCorrespondencium>();
                config.CreateMap<RegistroCorrespondencium, RegistroCorrespondenciaDto>();
                config.CreateMap<RegistroYAuditoriaDto, RegistroYAuditoria>();
            });

            iMapper = configuracion.CreateMapper();
        }

        public async Task CrearRegistroYAuditoria(RegistroCorrespondenciaDto registroCorrespondenciaDto)
        {
            if (!registroCorrespondenciaDto.Consecutivo.Equals("CE") && !registroCorrespondenciaDto.Consecutivo.Equals("CI"))
                throw new ModelException(Constantes.MENSAJE_ERROR_TIPO_CORRESPONDENCIA);

            RegistroCorrespondencium registroCorrespondencium = iMapper.Map<RegistroCorrespondenciaDto, RegistroCorrespondencium>(registroCorrespondenciaDto);
            await _registroCorrespondenciaDominio.CrearRegistroYAuditoria(registroCorrespondencium, registroCorrespondenciaDto.IdEmpleado);
        }

        public List<RegistroCorrespondenciaDto> ConsultarRegistroCorrespondencia(long numeroDocumentoRemitente)
        {
            List<RegistroCorrespondencium> registroCorrespondencium = _registroCorrespondenciaDominio.ConsultarRegistroCorrespondencia(numeroDocumentoRemitente);
            return iMapper.Map<List<RegistroCorrespondenciaDto>>(registroCorrespondencium);
        }

        public async Task ModificarRegistro(RegistroYAuditoriaDto registroAuditoriaDto)
        {
            RegistroYAuditoria registroAuditoria = iMapper.Map<RegistroYAuditoriaDto, RegistroYAuditoria>(registroAuditoriaDto);
            await _registroCorrespondenciaDominio.ModificarRegistro(registroAuditoria);
        }
    }
}

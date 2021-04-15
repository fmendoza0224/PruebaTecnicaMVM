using ComunicacionesAlpha.Datos.Interfaces;
using ComunicacionesAlpha.Dominio.Entidades.Modelos;
using ComunicacionesAlpha.Dominio.Servicios.Interfaces;
using ComunicacionesAlpha.Infraestructura.Interfaces;
using ComunicacionesAlpha.Infraestructura.Models;
using ComunicacionesAlpha.Transversal.Enums;
using ComunicacionesAlpha.Transversal.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Dominio
{
    public class RegistroCorrespondenciaDominio : IRegistroCorrespondenciaDominio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IRegistroCorrespondenciaSP _registroCorrespondenciaSP;

        public RegistroCorrespondenciaDominio(IUnidadDeTrabajo unidadDeTrabajo, IRegistroCorrespondenciaSP registroCorrespondenciaSP)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _registroCorrespondenciaSP = registroCorrespondenciaSP;
        }

        public List<RegistroCorrespondencium> ConsultarRegistroCorrespondencia(long numeroDocumentoRemitente)
        {
            return _unidadDeTrabajo.RegistroCorrespondenciaRepository.Get(x => x.NumeroDocumentoRemitente.Equals(numeroDocumentoRemitente)).ToList();
        }

        public async Task CrearRegistroYAuditoria(RegistroCorrespondencium registroCorrespondencium, long idEmpleado)
        {
            int idRegistro = 0;

            using (var transaction = _unidadDeTrabajo.BeginTransaction())
            {
                try
                {
                    idRegistro = await CrearRegistroCorrespondencia(registroCorrespondencium);
                    await GuardarAuditoria(idRegistro, idEmpleado);

                    transaction.Commit();
                }
                catch (TechnicalException ex)
                {
                    transaction.Rollback();
                    throw new TechnicalException(ex.Message, ex.InnerException);
                }
            }
        }

        public async Task ModificarRegistro(RegistroYAuditoria registroAuditoria)
        {
            await _registroCorrespondenciaSP.ActualizarRegistro(registroAuditoria);
        }

        private async Task<int> CrearRegistroCorrespondencia(RegistroCorrespondencium registroCorrespondencium)
        {
            int idRegistro = _unidadDeTrabajo.RegistroCorrespondenciaRepository.GetMaxId(x => x.IdRegistroCorrespondencia) + 1;
            registroCorrespondencium.Consecutivo = $"{registroCorrespondencium.Consecutivo}{idRegistro.ToString("D8")}";
            _unidadDeTrabajo.RegistroCorrespondenciaRepository.Insert(registroCorrespondencium);
            await _unidadDeTrabajo.SaveAsync();

            return idRegistro;
        }

        private async Task GuardarAuditoria(int idRegistro, long idEmpleado)
        {
            AuditoriaCorrespondencium auditoriaCorrespondencium = new AuditoriaCorrespondencium()
            {
                IdRegistroCorrespondencia = idRegistro,
                IdEstadoCorrespondencia = Convert.ToInt32(EstadosCorrespondencia.EnCentroServicio),
                FechaHoraRegistro = DateTime.Now,
                IdEmpleado = idEmpleado
            };

            _unidadDeTrabajo.AuditoriaCorrespondenciaRepository.Insert(auditoriaCorrespondencium);
            await _unidadDeTrabajo.SaveAsync();
        }
    }
}

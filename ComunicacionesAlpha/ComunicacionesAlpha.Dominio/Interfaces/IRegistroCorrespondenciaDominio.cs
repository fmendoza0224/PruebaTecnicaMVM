using ComunicacionesAlpha.Dominio.Entidades.Modelos;
using ComunicacionesAlpha.Infraestructura.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Dominio.Servicios.Interfaces
{
    public interface IRegistroCorrespondenciaDominio
    {
        Task CrearRegistroYAuditoria(RegistroCorrespondencium registroCorrespondencium, long idEmpleado);
        List<RegistroCorrespondencium> ConsultarRegistroCorrespondencia(long numeroDocumentoRemitente);
        Task ModificarRegistro(RegistroYAuditoria registroAuditoria);
    }
}

using ComunicacionesAlpha.Aplicacion.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Aplicacion.Interfaces
{
    public interface IRegistroCorrespondenciaAplicacion
    {
        Task CrearRegistroYAuditoria(RegistroCorrespondenciaDto registroCorrespondenciaDto);
        List<RegistroCorrespondenciaDto> ConsultarRegistroCorrespondencia(long numeroDocumentoRemitente);
        Task ModificarRegistro(RegistroYAuditoriaDto registroAuditoriaDto);
    }
}

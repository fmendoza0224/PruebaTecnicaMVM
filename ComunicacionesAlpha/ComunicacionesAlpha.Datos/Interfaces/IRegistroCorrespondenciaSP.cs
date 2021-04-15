using ComunicacionesAlpha.Dominio.Entidades.Modelos;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Infraestructura.Interfaces
{
    public interface IRegistroCorrespondenciaSP
    {
        Task ActualizarRegistro(RegistroYAuditoria registroAuditoria);
    }
}

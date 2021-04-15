using ComunicacionesAlpha.Dominio.Entidades.Modelos;
using ComunicacionesAlpha.Infraestructura.Interfaces;
using ComunicacionesAlpha.Transversal;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Infraestructura.StoreProcedures
{
    public class RegistroCorrespondenciaSP : IRegistroCorrespondenciaSP
    {
        public async Task ActualizarRegistro(RegistroYAuditoria registroAuditoria)
        {

            using (SqlConnection con = new SqlConnection(Contexto.Configuracion.ConexionBaseDatos))
            {
                using (SqlCommand cmd = new SqlCommand("OperacionesRegistroCorrespondenciaSP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmailDestinatario", SqlDbType.VarChar).Value = registroAuditoria.EmailDestinatario;
                    cmd.Parameters.Add("@TelefonoDestinatario", SqlDbType.VarChar).Value = registroAuditoria.TelefonoDestinatario;
                    cmd.Parameters.Add("@DireccionDestinatario", SqlDbType.VarChar).Value = registroAuditoria.DireccionDestinatario;
                    cmd.Parameters.Add("@DocumentoDigital", SqlDbType.Text).Value = registroAuditoria.DocumentoDigital;
                    cmd.Parameters.Add("@Consecutivo", SqlDbType.VarChar).Value = registroAuditoria.Consecutivo;
                    cmd.Parameters.Add("@IdRegistroCorrespondencia", SqlDbType.Int).Value = registroAuditoria.IdRegistroCorrespondencia;
                    cmd.Parameters.Add("@IdEstadoCorrespondencia", SqlDbType.Int).Value = registroAuditoria.IdEstadoCorrespondencia;
                    cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = registroAuditoria.IdEmpleado;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

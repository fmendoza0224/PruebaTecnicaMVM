using ComunicacionesAlpha.Infraestructura.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Datos.Interfaces
{
    public interface IUnidadDeTrabajo
    {
        IRepositorioGenerico<AuditoriaCorrespondencium> AuditoriaCorrespondenciaRepository { get; }

        IRepositorioGenerico<Cargo> CargoRepository { get; }

        IRepositorioGenerico<Empleado> EmpleadoRepository { get; }

        IRepositorioGenerico<EstadosCorrespondencium> EstadosCorrespondenciaRepository { get; }

        IRepositorioGenerico<RegistroCorrespondencium> RegistroCorrespondenciaRepository { get; }

        IRepositorioGenerico<Role> RolesRepository { get; }

        void Save();

        Task SaveAsync();

        IDbContextTransaction BeginTransaction();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}

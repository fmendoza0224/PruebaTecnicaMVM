using ComunicacionesAlpha.Datos.Interfaces;
using ComunicacionesAlpha.Infraestructura.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Datos
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        private readonly ContextoBD _contexto;
        private RepositorioGenerico<AuditoriaCorrespondencium> auditoriaCorrespondenciaRepository;
        private RepositorioGenerico<Cargo> cargoRepository;
        private RepositorioGenerico<Empleado> empleadoRepository;
        private RepositorioGenerico<EstadosCorrespondencium> estadosCorrespondenciaRepository;
        private RepositorioGenerico<RegistroCorrespondencium> registroCorrespondenciaRepository;
        private RepositorioGenerico<Role> rolesRepository;

        public UnidadDeTrabajo(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        public IRepositorioGenerico<AuditoriaCorrespondencium> AuditoriaCorrespondenciaRepository
        {
            get
            {
                if (this.auditoriaCorrespondenciaRepository == null)
                {
                    this.auditoriaCorrespondenciaRepository = new RepositorioGenerico<AuditoriaCorrespondencium>(_contexto);
                }
                return auditoriaCorrespondenciaRepository;
            }
        }

        public IRepositorioGenerico<Cargo> CargoRepository
        {
            get
            {
                if (this.cargoRepository == null)
                {
                    this.cargoRepository = new RepositorioGenerico<Cargo>(_contexto);
                }
                return cargoRepository;
            }
        }

        public IRepositorioGenerico<Empleado> EmpleadoRepository
        {
            get
            {
                if (this.empleadoRepository == null)
                {
                    this.empleadoRepository = new RepositorioGenerico<Empleado>(_contexto);
                }
                return empleadoRepository;
            }
        }

        public IRepositorioGenerico<EstadosCorrespondencium> EstadosCorrespondenciaRepository
        {
            get
            {
                if (this.estadosCorrespondenciaRepository == null)
                {
                    this.estadosCorrespondenciaRepository = new RepositorioGenerico<EstadosCorrespondencium>(_contexto);
                }
                return estadosCorrespondenciaRepository;
            }
        }

        public IRepositorioGenerico<RegistroCorrespondencium> RegistroCorrespondenciaRepository
        {
            get
            {
                if (this.registroCorrespondenciaRepository == null)
                {
                    this.registroCorrespondenciaRepository = new RepositorioGenerico<RegistroCorrespondencium>(_contexto);
                }
                return registroCorrespondenciaRepository;
            }
        }

        public IRepositorioGenerico<Role> RolesRepository
        {
            get
            {
                if (this.rolesRepository == null)
                {
                    this.rolesRepository = new RepositorioGenerico<Role>(_contexto);
                }
                return rolesRepository;
            }
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _contexto.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _contexto.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _contexto.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _contexto.Database.BeginTransactionAsync();
        }
    }
}

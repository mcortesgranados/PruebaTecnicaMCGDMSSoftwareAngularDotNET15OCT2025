using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    /// <summary>
    /// Servicio para gestión de Lugares y asociaciones con Recuerdos.
    /// 
    /// Rol en arquitectura hexagonal:
    /// - Capa Application (Application Services), actúa como "orquestador" de la lógica de negocio.
    /// - Recibe DTOs de la capa externa (controladores), valida y transforma datos, y utiliza repositorios para persistencia.
    /// - Permite que la capa de dominio permanezca independiente de detalles de infraestructura.
    /// - Cumple SRP y OCP de SOLID: tiene responsabilidad única de coordinar casos de uso.
    /// </summary>
    public class LugarService
    {
        private readonly LugarRepository _lugarRepo;
        private readonly RecuerdoLugarRepository _rlRepo;

        public LugarService(LugarRepository lugarRepo, RecuerdoLugarRepository rlRepo)
        {
            _lugarRepo = lugarRepo;
            _rlRepo = rlRepo;
        }

        /// <summary>
        /// Crea un nuevo lugar en el sistema.
        /// </summary>
        public async Task<Lugar> CrearLugarAsync(CreateLugarRequest request)
        {
            var lugar = new Lugar
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Direccion = request.Direccion,
                CreadorId = request.CreadorId
            };
            return await _lugarRepo.AddAsync(lugar);
        }

        /// <summary>
        /// Asocia un lugar existente a un recuerdo.
        /// </summary>
        public async Task<RecuerdoLugar> AsociarLugarAsync(AsociarLugarRecuerdoRequest request)
        {
            var rl = new RecuerdoLugar
            {
                RecuerdoId = request.RecuerdoId,
                LugarId = request.LugarId,
                AsociadoPorId = request.AsociadoPorId
            };
            return await _rlRepo.AddAsync(rl);
        }
    }
}

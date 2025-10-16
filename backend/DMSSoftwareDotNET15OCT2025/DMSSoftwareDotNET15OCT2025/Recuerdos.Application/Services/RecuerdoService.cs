
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.DTOs;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;


namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services
{
    public class RecuerdoService
    {
        private readonly IRecuerdoRepository _repository;

        public RecuerdoService(IRecuerdoRepository repository)
        {
            _repository = repository;
        }

        public async Task<RecuerdoResponse> CrearRecuerdoAsync(CreateRecuerdoRequest request)
        {
            var recuerdo = new Recuerdo
            {
                Titulo = request.Titulo,
                Situacion = request.Situacion,
                FechaOcurrencia = request.FechaOcurrencia,
                CreadorId = request.CreadorId,
                Estado = request.Estado,
                ConfirmadoPorId = request.ConfirmadoPorId,
                FechaConfirmacion = request.FechaConfirmacion
            };

            var creado = await _repository.AddAsync(recuerdo);

            return new RecuerdoResponse
            {
                Id = creado.Id,
                CreadorId = creado.CreadorId,
                FechaCreacion = creado.FechaCreacion,
                FechaOcurrencia = creado.FechaOcurrencia,
                Situacion = creado.Situacion,
                Estado = creado.Estado.ToString()
            };
        }


        /// <summary>
        /// Busca recuerdos por palabra clave
        /// </summary>
        public async Task<IEnumerable<Recuerdo>> BuscarRecuerdosAsync(string palabraClave)
        {
            if (string.IsNullOrWhiteSpace(palabraClave))
                return new List<Recuerdo>();

            return await _repository.BuscarRecuerdosAsync(palabraClave);
        }

        public async Task<List<RecuerdoAmigoDto>> ListarRecuerdosDeAmigoAsync(int amigoId)
        {
            return await _repository.GetRecuerdosByAmigoIdAsync(amigoId);
        }
    }
}

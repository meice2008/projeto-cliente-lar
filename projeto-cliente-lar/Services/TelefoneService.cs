using AutoMapper;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepositorio _repositorio;
        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task AddAsync(TelefoneRequest telefoneRequest)
        {
            try
            {
                var telefone = _mapper.Map<Telefone>(telefoneRequest);
                await _repositorio.AddAsync(telefone);
            }
            catch (Exception)
            {
                // tratamento simples inicial
            }
        }

        public async Task<bool> DeleteAsync(string numero)
        {
            try
            {
                return await _repositorio.DeleteAsync(numero);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Telefone>> GetAllAsync()
        {
            try
            {
                return await _repositorio.GetAllAsync();
            }
            catch (Exception)
            {
                return Array.Empty<Telefone>();
            }
        }

        public async Task<Telefone?> GetByNumeroAsync(string numero)
        {
            try
            {
                return await _repositorio.GetByNumeroAsync(numero);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(TelefoneRequest telefoneRequest)
        {
            try
            {
                var telefone = _mapper.Map<Telefone>(telefoneRequest);
                return await _repositorio.UpdateAsync(telefone);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

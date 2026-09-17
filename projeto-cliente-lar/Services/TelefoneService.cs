using AutoMapper;
using Microsoft.Extensions.Logging;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<TelefoneService> _logger;

        public TelefoneService(ITelefoneRepositorio repositorio, IMapper mapper, ILogger<TelefoneService> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(TelefoneRequest telefoneRequest)
        {
            try
            {
                var telefone = _mapper.Map<Telefone>(telefoneRequest);
                _logger.LogInformation("Adicionando telefone {Numero} Tipo {Tipo}", telefone.Numero, telefone.Tipo);
                await _repositorio.AddAsync(telefone);
                _logger.LogInformation("Telefone adicionado: {Numero}", telefone.Numero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar telefone {Numero}", telefoneRequest.Numero);
            }
        }

        public async Task<bool> DeleteAsync(string numero)
        {
            try
            {
                _logger.LogInformation("Removendo telefone {Numero}", numero);
                var result = await _repositorio.DeleteAsync(numero);
                if (result)
                    _logger.LogInformation("Telefone removido: {Numero}", numero);
                else
                    _logger.LogWarning("Telefone nao encontrado para remoção: {Numero}", numero);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover telefone {Numero}", numero);
                return false;
            }
        }

        public async Task<IEnumerable<Telefone>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Obtendo todos os telefones");
                return await _repositorio.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter telefones");
                return Array.Empty<Telefone>();
            }
        }

        public async Task<Telefone?> GetByNumeroAsync(string numero)
        {
            try
            {
                _logger.LogDebug("Obtendo telefone por numero {Numero}", numero);
                return await _repositorio.GetByNumeroAsync(numero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter telefone por numero {Numero}", numero);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(TelefoneRequest telefoneRequest)
        {
            try
            {
                var telefone = _mapper.Map<Telefone>(telefoneRequest);
                _logger.LogInformation("Atualizando telefone {Numero}", telefone.Numero);
                var result = await _repositorio.UpdateAsync(telefone);
                if (result)
                    _logger.LogInformation("Telefone atualizado: {Numero}", telefone.Numero);
                else
                    _logger.LogWarning("Telefone nao encontrado para atualização: {Numero}", telefone.Numero);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar telefone {Numero}", telefoneRequest.Numero);
                return false;
            }
        }
    }
}

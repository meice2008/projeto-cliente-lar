using AutoMapper;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<PessoaService> _logger;

        public PessoaService(IPessoaRepositorio repositorio, IMapper mapper, ILogger<PessoaService> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(PessoaRequest pessoaRequest)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequest);

            try
            {
                _logger.LogInformation("Adicionando pessoa com CPF {Cpf}", pessoa.Cpf);
                await _repositorio.AddAsync(pessoa);
                _logger.LogInformation("Pessoa adicionada: {Cpf}", pessoa.Cpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar pessoa com CPF {Cpf}", pessoa.Cpf);
                // tratamento simples inicial: ignorar/propagar conforme necessário
            }
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            try
            {
                _logger.LogInformation("Removendo pessoa com CPF {Cpf}", cpf);
                var result = await _repositorio.DeleteAsync(cpf);
                if (result)
                    _logger.LogInformation("Pessoa removida: {Cpf}", cpf);
                else
                    _logger.LogWarning("Pessoa não encontrada para remoção: {Cpf}", cpf);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover pessoa com CPF {Cpf}", cpf);
                return false;
            }
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Obtendo todas as pessoas");
                return await _repositorio.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as pessoas");
                return Array.Empty<Pessoa>();
            }
        }

        public async Task<Pessoa?> GetByCpfAsync(string cpf)
        {
            try
            {
                _logger.LogDebug("Obtendo pessoa por CPF {Cpf}", cpf);
                return await _repositorio.GetByCpfAsync(cpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter pessoa por CPF {Cpf}", cpf);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(PessoaRequest pessoaRequest)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequest);

            try
            {
                _logger.LogInformation("Atualizando pessoa com CPF {Cpf}", pessoa.Cpf);
                var result = await _repositorio.UpdateAsync(pessoa);
                if (result)
                    _logger.LogInformation("Pessoa atualizada: {Cpf}", pessoa.Cpf);
                else
                    _logger.LogWarning("Pessoa não encontrada para atualização: {Cpf}", pessoa.Cpf);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pessoa com CPF {Cpf}", pessoa.Cpf);
                return false;
            }
        }
    }
}

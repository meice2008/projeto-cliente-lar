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

        public PessoaService(IPessoaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task AddAsync(PessoaRequest pessoaRequest)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequest);

            try
            {
                await _repositorio.AddAsync(pessoa);
            }
            catch (Exception)
            {
                // tratamento simples inicial: ignorar/propagar conforme necessário
            }
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            try
            {
                return await _repositorio.DeleteAsync(cpf);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            try
            {
                return await _repositorio.GetAllAsync();
            }
            catch (Exception)
            {
                return Array.Empty<Pessoa>();
            }
        }

        public async Task<Pessoa?> GetByCpfAsync(string cpf)
        {
            try
            {
                return await _repositorio.GetByCpfAsync(cpf);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(PessoaRequest pessoaRequest)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequest);

            try
            {
                return await _repositorio.UpdateAsync(pessoa);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

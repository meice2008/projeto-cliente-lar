using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Repositories
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly List<Pessoa> _pessoas = new List<Pessoa>();

        public Task AddAsync(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(string cpf)
        {
            var existing = _pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (existing == null) 
                return Task.FromResult(false);

            _pessoas.Remove(existing);

            return Task.FromResult(true);
        }

        public Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Pessoa>>(_pessoas.ToList());
        }

        public Task<Pessoa?> GetByCpfAsync(string cpf)
        {
            var pessoa = _pessoas.FirstOrDefault(p => p.Cpf == cpf);
            return Task.FromResult(pessoa);
        }

        public Task<bool> UpdateAsync(Pessoa pessoa)
        {
            var existing = _pessoas.FirstOrDefault(p => p.Cpf == pessoa.Cpf);

            if (existing == null) 
                return Task.FromResult(false);

            existing.Nome = pessoa.Nome;
            existing.DataDeNascimento = pessoa.DataDeNascimento;
            existing.Ativo = pessoa.Ativo;

            return Task.FromResult(true);
        }
    }
}

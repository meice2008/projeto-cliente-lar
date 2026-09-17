using Microsoft.EntityFrameworkCore;
using projeto_cliente_lar.Data;
using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Repositories
{
    public class PessoaRepositorioEf : IPessoaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PessoaRepositorioEf(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Pessoa pessoa)
        {
            if (pessoa.Id == Guid.Empty) pessoa.Id = Guid.NewGuid();
            _db.Pessoas.Add(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            var existing = await _db.Pessoas.FirstOrDefaultAsync(p => p.Cpf == cpf);
            if (existing == null) return false;
            _db.Pessoas.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _db.Pessoas.Include(p => p.Telefones).ToListAsync();
        }

        public async Task<Pessoa?> GetByCpfAsync(string cpf)
        {
            return await _db.Pessoas.Include(p => p.Telefones).FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<bool> UpdateAsync(Pessoa pessoa)
        {
            var existing = await _db.Pessoas.FirstOrDefaultAsync(p => p.Cpf == pessoa.Cpf);
            if (existing == null) return false;
            existing.Nome = pessoa.Nome;
            existing.DataDeNascimento = pessoa.DataDeNascimento;
            existing.Ativo = pessoa.Ativo;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

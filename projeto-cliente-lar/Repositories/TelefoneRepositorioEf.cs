using Microsoft.EntityFrameworkCore;
using projeto_cliente_lar.Data;
using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Repositories
{
    public class TelefoneRepositorioEf : ITelefoneRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TelefoneRepositorioEf(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Telefone telefone)
        {
            if (telefone.Id == Guid.Empty) telefone.Id = Guid.NewGuid();
            _db.Telefones.Add(telefone);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string numero)
        {
            var existing = await _db.Telefones.FirstOrDefaultAsync(t => t.Numero == numero);
            if (existing == null) return false;
            _db.Telefones.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Telefone>> GetAllAsync()
        {
            return await _db.Telefones.Include(t => t.Pessoa).ToListAsync();
        }

        public async Task<Telefone?> GetByNumeroAsync(string numero)
        {
            return await _db.Telefones.Include(t => t.Pessoa).FirstOrDefaultAsync(t => t.Numero == numero);
        }

        public async Task<bool> UpdateAsync(Telefone telefone)
        {
            var existing = await _db.Telefones.FirstOrDefaultAsync(t => t.Id == telefone.Id || t.Numero == telefone.Numero);
            if (existing == null) return false;
            existing.Tipo = telefone.Tipo;
            existing.PessoaId = telefone.PessoaId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

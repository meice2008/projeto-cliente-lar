using projeto_cliente_lar.Entities;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Repositories
{
    public class TelefoneRepositorio //: ITelefoneRepositorio
    {
        private readonly List<Telefone> _telefones = new();

        public Task AddAsync(Telefone telefone)
        {
            _telefones.Add(telefone);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(string numero)
        {
            var existing = _telefones.FirstOrDefault(t => t.Numero == numero);

            if (existing == null) 
                return Task.FromResult(false);

            _telefones.Remove(existing);

            return Task.FromResult(true);
        }

        public Task<IEnumerable<Telefone>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Telefone>>(_telefones.ToList());
        }

        public Task<Telefone?> GetByNumeroAsync(string numero)
        {
            var tel = _telefones.FirstOrDefault(t => t.Numero == numero);
            return Task.FromResult(tel);
        }

        public Task<bool> UpdateAsync(Telefone telefone)
        {
            var existing = _telefones.FirstOrDefault(t => t.Numero == telefone.Numero);

            if (existing == null) 
                return Task.FromResult(false);

            existing.Tipo = telefone.Tipo;

            return Task.FromResult(true);
        }
    }
}

using projeto_cliente_lar.Entities;

namespace projeto_cliente_lar.Interfaces
{
    public interface ITelefoneRepositorio
    {
        Task<IEnumerable<Telefone>> GetAllAsync();
        Task<Telefone?> GetByNumeroAsync(string numero);
        Task AddAsync(Telefone telefone);
        Task<bool> UpdateAsync(Telefone telefone);
        Task<bool> DeleteAsync(string numero);
    }
}

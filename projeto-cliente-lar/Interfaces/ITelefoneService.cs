using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;

namespace projeto_cliente_lar.Interfaces
{
    public interface ITelefoneService
    {
        Task<IEnumerable<Telefone>> GetAllAsync();
        Task<Telefone?> GetByNumeroAsync(string numero);
        Task AddAsync(TelefoneRequest telefoneRequest);
        Task<bool> UpdateAsync(TelefoneRequest telefoneRequest);
        Task<bool> DeleteAsync(string numero);
    }
}

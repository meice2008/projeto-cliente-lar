using projeto_cliente_lar.Entities;

namespace projeto_cliente_lar.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa?> GetByCpfAsync(string cpf);
        Task AddAsync(Pessoa pessoa);
        Task<bool> UpdateAsync(Pessoa pessoa);
        Task<bool> DeleteAsync(string cpf);
    }
}

using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto_cliente_lar.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa?> GetByCpfAsync(string cpf);
        Task AddAsync(PessoaRequest pessoa);
        Task<bool> UpdateAsync(PessoaRequest pessoa);
        Task<bool> DeleteAsync(string cpf);
    }
}

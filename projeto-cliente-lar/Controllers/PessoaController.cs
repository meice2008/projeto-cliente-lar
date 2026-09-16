using Microsoft.AspNetCore.Mvc;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as pessoas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();

            if (lista == null || !lista.Any())
                return NotFound();

            return Ok(lista);
        }

        /// <summary>
        /// Retorna uma pessoa pelo CPF.
        /// </summary>
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            if (cpf == null || string.IsNullOrEmpty(cpf))
                return BadRequest();

            var pessoa = await _service.GetByCpfAsync(cpf);

            if (pessoa == null) 
                return NotFound();

            return Ok(pessoa);
        }

        /// <summary>
        /// Cria uma nova pessoa.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PessoaRequest pessoa)
        {
            if (pessoa == null 
                       || string.IsNullOrEmpty(pessoa.Cpf) 
                       || string.IsNullOrEmpty(pessoa.Nome))
                return BadRequest();

            await _service.AddAsync(pessoa);
            return CreatedAtAction(nameof(GetByCpf), new { cpf = pessoa.Cpf }, pessoa);
        }

        /// <summary>
        /// Atualiza uma pessoa existente.
        /// </summary>
        [HttpPut("{cpf}")]
        public async Task<IActionResult> Update(string cpf, [FromBody] PessoaRequest pessoa)
        {
            if (pessoa == null 
                       || pessoa.Cpf != cpf || string.IsNullOrEmpty(pessoa.Cpf) 
                       || string.IsNullOrEmpty(pessoa.Nome) 
                       || pessoa.DataDeNascimento is null)
                return BadRequest();

            var updated = await _service.UpdateAsync(pessoa);

            if (!updated) 
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Remove uma pessoa pelo CPF.
        /// </summary>
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            if (cpf == null || string.IsNullOrEmpty(cpf))
                return BadRequest();

            var deleted = await _service.DeleteAsync(cpf);

            if (!deleted) 
                return NotFound();

            return NoContent();
        }
    }
}

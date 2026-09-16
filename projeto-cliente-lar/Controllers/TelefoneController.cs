using Microsoft.AspNetCore.Mvc;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Interfaces;

namespace projeto_cliente_lar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _service;

        public TelefoneController(ITelefoneService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os telefones.
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
        /// Retorna um telefone pelo número.
        /// </summary>
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetByNumero(string numero)
        {
            if (numero == null || string.IsNullOrEmpty(numero))
                return BadRequest();

            var tel = await _service.GetByNumeroAsync(numero);

            if (tel == null || string.IsNullOrEmpty(tel.Numero)) 
                return NotFound();

            return Ok(tel);
        }

        /// <summary>
        /// Cria um novo telefone.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelefoneRequest telefone)
        {
            if (telefone == null
                       || string.IsNullOrEmpty(telefone.Numero)
                       || telefone.Tipo is null
                       || !Enum.IsDefined<TipoTelefone>(telefone.Tipo.Value))
                return BadRequest();

            await _service.AddAsync(telefone);
            return CreatedAtAction(nameof(GetByNumero), new { numero = telefone.Numero }, telefone);
        }

        /// <summary>
        /// Atualiza um telefone existente.
        /// </summary>
        [HttpPut("{numero}")]
        public async Task<IActionResult> Update(string numero, [FromBody] TelefoneRequest telefone)
        {
            if (telefone == null || numero == null
                         || string.IsNullOrEmpty(numero)
                         || string.IsNullOrEmpty(telefone.Numero)
                         || telefone.Tipo is null
                         || !Enum.IsDefined<TipoTelefone>(telefone.Tipo.Value))
                return BadRequest();

            var updated = await _service.UpdateAsync(telefone);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        /// <summary>   
        /// Remove um telefone pelo número.
        /// </summary>
        [HttpDelete("{numero}")]
        public async Task<IActionResult> Delete(string numero)
        {
            if (numero == null || string.IsNullOrEmpty(numero))
                return BadRequest();

            var deleted = await _service.DeleteAsync(numero);

            if (!deleted) 
                return NotFound();

            return NoContent();
        }
    }
}

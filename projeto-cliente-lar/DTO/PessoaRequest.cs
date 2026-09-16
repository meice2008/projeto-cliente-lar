namespace projeto_cliente_lar.DTO
{
    public class PessoaRequest
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public bool? Ativo { get; set; }
    }
}

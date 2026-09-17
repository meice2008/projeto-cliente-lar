namespace projeto_cliente_lar.Entities
{
    public class Pessoa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public bool? Ativo { get; set; }
        public ICollection<Telefone>? Telefones { get; set; }
    }
}

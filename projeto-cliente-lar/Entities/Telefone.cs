namespace projeto_cliente_lar.Entities
{
    public class Telefone
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
        // FK para Pessoa (Id)
        public Guid? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }

    public enum TipoTelefone
    {
        Residencial,
        Comercial,
        Celular
    }
}

namespace projeto_cliente_lar.Entities
{
    public class Telefone
    {
        public string? Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }

    public enum TipoTelefone
    {
        Residencial,
        Comercial,
        Celular
    }
}

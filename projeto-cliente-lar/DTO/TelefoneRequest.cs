namespace projeto_cliente_lar.DTO
{
    public class TelefoneRequest
    {
        public string? Numero { get; set; }
        public TipoTelefone? Tipo { get; set; }
    }

    public enum TipoTelefone
    {
        Residencial,
        Celular,
        Comercial
    }
}

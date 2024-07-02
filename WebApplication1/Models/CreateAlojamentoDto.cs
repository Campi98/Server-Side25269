public class CreateAlojamentoDto
{
    public string Nome { get; set; }
    public string Localizacao { get; set; }
    public int Capacidade { get; set; }
    public int PrecoPorNoite { get; set; }
    public string Descricao { get; set; }
    public DateTime DataDisponivel { get; set; }
    public string Proprietario { get; set; }
    public string TelefoneProprietario { get; set; }
    public int Id_da_Viagem { get; set; }
}
